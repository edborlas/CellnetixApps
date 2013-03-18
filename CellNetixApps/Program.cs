using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CellNetixApps.Source.Forms;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using System.Linq;
using CellNetixApps.Source.Path.Forms;
using CellNetixApps.Source.Embed.Forms;
using CellNetixApps.Source.Distribute;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using CellNetixApps.Source.Controls;
using System.Drawing;
using CellNetixApps.Source.Acc;
using CellNetixApps.Source.Lab;
using System.Runtime.InteropServices;
using CellNetixApps.Source.Rules;

namespace CellNetixApps
{
    static class Program
    {


        public const int PORT_NUMBER = 134;
        public const string EMAIL_SERVER = "CEL-EXC-003";
        public static string Root = System.IO.Path.GetPathRoot(Environment.SystemDirectory);
        public static string SlideFileName = string.Empty;
        public const string TrayPrefix = "BT";
        public static string ConferenceFolder = @"\\cel-fil-001\Conferences\" + Environment.UserName;
        public static string imageLocation = Root + @"CellNetixApps\pic.jpg";
        public static string imageThumbLocation = Root + @"CellNetixApps\pic_thumb.jpg";
        public static int KeypadResult { get; set; }
        public static Conference Conference { get; set; }
        public static DateTime LastAction { get; set; }
        public static cUser User { get; set; }
        public static cAcc Acc { get; set; }
        public static cMachine Machine { get; set; }
        public static frmDistribute frmDistribute { get; set; }
        public static frmLogin frmLogin { get; set; }
        public static frmCut frmCut { get; set; }
        public static frmEmbed frmEmbed { get; set; }
        public static frmPath frmPath { get; set; }
        public static cConference cConference { get; set; }
        public static List<cForms> Forms { get; set; }
        public static List<cSpecimen> Specimens { get; set; }
        public static List<cBlock> Blocks { get; set; }
        public static List<cSlide> Slides { get; set; }
        public static List<cTicketError> TicketErrors { get; set; }
        public static List<cCharge> CaseCharges { get; set; }
        public static List<cICD9> CaseICD9s { get; set; }
        public static List<cCaseNote> CaseNotes { get; set; }
        public static List<cImage> CaseSlideImages { get; set; }
        public static List<cImage> Images { get; set; }
        public static List<cPhoneNumbers> PhoneNumbers { get; set; }
        public static List<cTraySlot> TraySlots { get; set; }
        public static List<cLocation> lDestinations { get; set; }
        public static List<cUser> lPathologists { get; set; }
        public static List<cOverride> lOverrides { get; set; }
        public static List<cTemplate> Templates { get; set; }
        public static List<cTemplateData> TemplateData { get; set; }
        public static List<Division> lDivisions { get; set; }
        public static Color ColorToggledOff = Color.FromArgb(229, 20, 0);
        public static Color ColorToggledOn = Color.FromArgb(27, 161, 226);
        public static Color ColorLink = Color.FromArgb(25, 153, 0);
        // public static Color ColorBrown = Color.FromArgb(99, 47, 0);
        public static Color ColorDisabled = Color.FromArgb(105, 105, 105);

        static Mutex m;
        static System.Windows.Forms.Timer tStatus;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool first = false;

            m = new Mutex(true, Application.ProductName.ToString(), out first);
            if ((first))
            {

                FileInfo serverFile = new FileInfo(@"\\cel-fil-001\software\custom_apps\CellNetixApps\cellnetixapps.exe");
                FileInfo localFile = new FileInfo(Root + @"CellNetixApps\cellnetixapps.exe");


                copyDlls();



                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");

                tStatus = new System.Windows.Forms.Timer();
                tStatus.Interval = 30000;
                tStatus.Tick += tStatus_Tick;
                tStatus.Start();
                //Basically UpdateApp() but without the textbox so the user won't know on start up.
                DateTime serverFileTime = serverFile.LastWriteTime;
                DateTime localFileTime = localFile.LastWriteTime;
                if (serverFileTime > localFileTime) //if there is a new file on the server, copy it down. otherwise start the app
                {
                    bool err = false;
                    try
                    {
                        //rename cellnetixapp.exe
                        Rename(localFile);
                        // copy new version
                        File.Copy(serverFile.FullName, localFile.FullName);
                        // Launch new app
                        Process.Start(localFile.FullName);
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        err = true;
                        MessageBox.Show("Update Failed. Please Try again then contact IT\n" + ex.Message);
                    }
                    finally
                    {
                        if (!err)
                            Application.Exit();
                    }
                }
                else
                {

                    try
                    {
                        Machine = cMethods.GetMachine();
                    }
                    catch (Exception)
                    {
                        //quick fix to make sure the program launches
                        //if it contains wks it is probably a path machine, if it is aio it is probably cutting
                        int attributeTypeID = (int)Enums.MachineAttribtues.Cut;
                        if (Environment.MachineName.ToUpper().Contains("WKS"))
                            attributeTypeID = (int)Enums.MachineAttribtues.Pathologist;
                        cMethods.InsertMachineAttribute(attributeTypeID);
                        Machine = cMethods.GetMachine();
                    }

                    LastAction = DateTime.Now;
                    var query = from li in Program.Machine.Attributes
                                where li == (int)Enums.MachineAttribtues.Pathologist
                                select li;

                    int count = query.Count();
                    if (query == null || count == 0) //auto open the application if it is a pathologist
                    {
                        mapNetworkDrive();
                        Application.Run(new frmLogin());
                        //Application.Run(new frmRule());
                        //Application.Run(new frmWorklist());
                        // Application.Run(new frmSearch(Enums.FormControls.frmSearch));
                    }
                    else
                    {
                        if (!Directory.Exists(Program.ConferenceFolder))
                        {
                            Directory.CreateDirectory(Program.ConferenceFolder);
                        }
                        string userName = Environment.UserName;
                        Program.User = cMethods.CreateUser(Enums.UserCreationType.Login, userName);
                        cMethods.SetDefaultPrinter();

                        Application.Run(new frmPath());
                    }
                }
                m.ReleaseMutex();
            }
        }



        private static void copyDlls()
        {
            DirectoryInfo localDirectory = new DirectoryInfo(Root + @"CellNetixApps\");

            DirectoryInfo serverDirectory = new DirectoryInfo(@"\\cel-fil-001\software\custom_apps\CellNetixApps\Dlls\");

            FileInfo[] localFiles = localDirectory.GetFiles("*.dll");

            FileInfo[] serverFiles = serverDirectory.GetFiles("*.dll");

            foreach (FileInfo fi in serverFiles)
            {

                FileInfo file = localFiles.Where(f => f.Name == fi.Name).FirstOrDefault();

                if (file == null)
                {
                    File.Copy(fi.FullName, localDirectory.FullName + fi.Name);
                }

            }
            copyReports();
        }

        private static void copyReports()
        {
            DirectoryInfo localDirectory = new DirectoryInfo(Root + @"CellNetixApps\");

            DirectoryInfo serverDirectory = new DirectoryInfo(@"\\cel-fil-001\software\custom_apps\CellNetixApps\Reports\");

            FileInfo[] localFiles = localDirectory.GetFiles("*.rpt");

            FileInfo[] serverFiles = serverDirectory.GetFiles("*.rpt");

            foreach (FileInfo fi in serverFiles)
            {

                FileInfo file = localFiles.Where(f => f.Name == fi.Name).FirstOrDefault();

                if (file == null)
                {
                    File.Copy(fi.FullName, localDirectory.FullName + fi.Name);
                }

            }
        }

        /// <summary>Checks for an updated version. If found will automatically update the version. Else it will return false. This function will never return true.</summary>
        public static bool UpdateApplication()
        {
            FileInfo serverFile = new FileInfo(@"\\cel-fil-001\software\custom_apps\CellNetixApps\cellnetixapps.exe");
            FileInfo localFile = new FileInfo(Root + @"CellNetixApps\cellnetixapps.exe");
            DateTime serverFileTime = serverFile.LastWriteTime;
            DateTime localFileTime = localFile.LastWriteTime;
            if (serverFileTime > localFileTime) //if there is a new file on the server, copy it down. otherwise start the app
            {
                bool err = false;
                try
                {
                    DialogResult dr = MessageBox.Show("Update available. Press OK to upgrade.", "New Version", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        //rename cellnetixapp.exe
                        Rename(localFile);
                        // copy new version
                        File.Copy(serverFile.FullName, localFile.FullName);
                        // Launch new app
                        Process.Start(serverFile.FullName);
                        Application.Exit();
                    }
                }
                catch (Exception)
                {
                    err = true;
                    MessageBox.Show("Update Failed. Please Try again then contact IT");
                }
                finally
                {
                    if (!err)
                        Application.Exit();
                }
            }
            return false;
        }

        public static void mapNetworkDrive()
        {
            Process.Start("net.exe", @"USE w: \\cel-fil-001\software\custom_apps\CellNetixApps /user:cellnetix\uuser zxc1234! /persistent:yes");
        }

        public static bool Rename(FileInfo localF)
        {
            string currentName = localF.FullName;
            string newName = localF.FullName + ".old";
            if (File.Exists(newName))
            {
                File.Delete(newName);
            }
            File.Move(currentName, newName);
            return true;
        }


        static void tStatus_Tick(object sender, EventArgs e)
        {
            if (Program.User != null && LastAction > DateTime.Now.AddHours(-1)) //stop inserting after 1 hour.
                cMethods.Insert_User_Status(GetLastInputTime());
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }

        public static int GetLastInputTime()
        {
            uint idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            uint envTicks = (uint)Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTick = lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }

            return (int)((idleTime > 0) ? (idleTime / 1000) : 0);
        }
    }


}