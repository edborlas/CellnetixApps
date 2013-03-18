using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CellNetixApps.Source.Embed.Forms;
using CellNetixApps.Source.Path.Forms;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Distribute;
using CellNetixApps.Source.Block_Print;
using RFIDeas_pcProxAPI;
using CellNetixApps.Source.Lab;
using CellNetixApps.Source.Acc;

namespace CellNetixApps.Source.Forms
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        Timer timer;
        Enums.Mode currentMode;
        const int BADGE_WAIT = 200;//200 milisecs
        const int IDLE_WAIT = 3600000; // 20 minute
        public frmLogin()
        {
            InitializeComponent();

            Program.frmLogin = this;

            this.lVersion.Text = cMethods.Version;
            this.tiEmbed.ItemClick += tiEmbed_ItemClick;
            this.tiCut.ItemClick += tiCut_ItemClick;
            this.tiDistribute.ItemClick += tiDistribute_ItemClick;
            this.tiPath.ItemClick += tiPath_ItemClick;
            this.tiTicket.ItemClick += tiTicket_ItemClick;

            tcLogin.AppearanceItem.Normal.BackColor = Program.ColorLink;//the default color of the tiles
            bool needsBageToLogin = true;

            foreach (int att in Program.Machine.Attributes)
            {
                if (att == (int)Enums.MachineAttribtues.AutoLogin)
                    needsBageToLogin = false;
            }
            if (needsBageToLogin)
            {
                int rec = pcProxDLLAPI.usbConnect();
                if (timer == null)
                {
                    timer = new Timer();
                    timer.Enabled = true;
                    timer.Interval = BADGE_WAIT;
                    timer.Tick += new EventHandler(timer_Tick);
                }
            }
            Initalize(Enums.Mode.Logout);
            //Add all buttons that the machine has an attribute for
            tgLogin.Items.Clear();

            foreach (int att in Program.Machine.Attributes)
            {
                switch (att)
                {
                    case (int)Enums.MachineAttribtues.Cut:
                        tgLogin.Items.Add(tiCut);
                        break;
                    case (int)Enums.MachineAttribtues.Emebed:
                        tgLogin.Items.Add(tiEmbed);
                        break;
                    case (int)Enums.MachineAttribtues.Distribution:
                        tgLogin.Items.Add(tiDistribute);
                        break;
                    case (int)Enums.MachineAttribtues.BlockPrint:
                        tgLogin.Items.Add(tiBlockPrint);
                        break;
                    case (int)Enums.MachineAttribtues.ManualDistribute:
                        tgLogin.Items.Add(tiManualDistribute);
                        break;
                    case (int)Enums.MachineAttribtues.Worklist:
                        tgLogin.Items.Add(tiWorklist);
                        break;
                    case (int)Enums.MachineAttribtues.Admin:
                        //show all
                        tgLogin.Items.Add(tiCut);
                        tgLogin.Items.Add(tiEmbed);
                        tgLogin.Items.Add(tiPath);
                        tgLogin.Items.Add(tiDistribute);
                        tgLogin.Items.Add(tiTicket);
                        tgLogin.Items.Add(tiBlockPrint);
                        tgLogin.Items.Add(tiManualDistribute);
                        tgLogin.Items.Add(tiWorklist);
                        tgLogin.Items.Add(tiAccession);
                        bAdmin.Visible = true;
                        break;
                    case (int)Enums.MachineAttribtues.AutoLogin:
                        Program.User = cMethods.CreateUser(Enums.UserCreationType.Login, Environment.UserName);
                        cMethods.SetDefaultPrinter();
                        if (timer == null)
                        {
                            timer = new Timer();
                            timer.Tick +=new EventHandler(timer_Tick);
                        }
                        Initalize(Enums.Mode.Login);
                        needsBageToLogin = false;
                        break;
                }
            }

            //center things so it looks nice
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;

            int center = (screenWidth - this.lTitle.Size.Width) / 2;
            Point newLoc = new Point(center, 10);
            this.lTitle.Location = newLoc;


            int center2 = (screenWidth - this.tcLogin.Size.Width) / 2;
            Point newLoc2 = new Point(center2, 300);
            this.tcLogin.Location = newLoc2;

        }

        void tiTicket_ItemClick(object sender, TileItemEventArgs e)
        {
            if (currentMode == Enums.Mode.Login)
            {
                frmTicketMainMenu frm = new frmTicketMainMenu();
                this.Visible = false;
                frm.ShowDialog();
            }
        }

        void tiPath_ItemClick(object sender, TileItemEventArgs e)
        {
            if (currentMode == Enums.Mode.Login)
            {
                Program.User.PPuserID = 374;
                Program.User.UserID = 822;
          //      MessageBox.Show("You are being logged in as test pathologist");
                frmPath frm = new frmPath();
                this.Visible = false;
                frm.ShowDialog();
            }
        }

        void tiEmbed_ItemClick(object sender, TileItemEventArgs e)
        {
            if (currentMode == Enums.Mode.Login)
            {
                frmEmbed frm = new frmEmbed(Enums.Mode.Embed);
                this.Visible = false;
                frm.ShowDialog();
            }
            //Application.Run(new frmLogin());
            //   this.Close();
        }

        void tiDistribute_ItemClick(object sender, TileItemEventArgs e)
        {
            if (currentMode == Enums.Mode.Login)
            {
                if (Program.frmDistribute == null)
                {
                    frmDistribute frmDist = new frmDistribute();
                    this.Visible = false;
                    frmDist.ShowDialog();
                }
                else
                {
                    frmDistribute frmDist = Program.frmDistribute;
                    frmDist.ReloadForm(false);
                    this.Visible = false;
                    frmDist.ShowDialog();

                }
            }
        }



        void tiCut_ItemClick(object sender, TileItemEventArgs e)
        {
            if (currentMode == Enums.Mode.Login)
            {
                frmCut frm = new frmCut();
                this.Visible = false;
                frm.ShowDialog();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
           // const int IDLE_TIME = -60;
            if (Program.User == null)
            {
                int bNumber = ProximityReader.ReadBadge();
                if (bNumber != 0)
                {
                    Program.User = cMethods.CreateUser(Enums.UserCreationType.Badge, bNumber);
                    cMethods.SetDefaultPrinter();

                    Program.User.BadgeNumber = bNumber;

                    Initalize(Enums.Mode.Login);
                }
            }
            //else if (Program.LastAction < DateTime.Now.AddMinutes(IDLE_TIME))
            //{//idled for too long
            //    Initalize(Enums.Mode.Logout);
            //}
        }
        public void LogOut()
        {
            //Close all open windows
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != this.Name)
                    Application.OpenForms[i].Close();
            }
            //set login screen back to visible
            this.Visible = true;
            //Initialize all Program things to null
            Program.User = null;
            Program.Acc = null;
            Program.Blocks = null;
            Program.Slides = null;
            //So every form doesn't have to set its corresponding program.frmname to null.
            Program.frmEmbed = null;
            Program.frmCut = null;
            Program.frmCut = null;
            this.bLogSomeoneIn.Visible = false;
            currentMode = Enums.Mode.Logout;
            this.lTitle.Text = "Scan Badge To Login";

            //if they are autologin keep them signed in
            bool badgeNeeded = true;
            foreach (int att in Program.Machine.Attributes)
            {
                switch (att)
                {
                    case (int)Enums.MachineAttribtues.AutoLogin:
                        Program.User = cMethods.CreateUser(Enums.UserCreationType.Login, Environment.UserName);
                        cMethods.SetDefaultPrinter();
                        Initalize(Enums.Mode.Login);
                        badgeNeeded = false;
                        break;
                }
            }
            if (badgeNeeded)
                timer.Interval = BADGE_WAIT;
        }

        public void Initalize(Enums.Mode m)
        {
            switch (m)
            {
                case Enums.Mode.Logout:
                    LogOut();
                    break;
                case Enums.Mode.Login:

                    currentMode = Enums.Mode.Login;
                    if (timer == null)
                    {//this is kind of a cop-out. There is probably a way to reduce this since it's in like 5 spots....
                        timer = new Timer();
                        timer.Enabled = true;
                        timer.Tick += new EventHandler(timer_Tick);
                    }
                    timer.Interval = IDLE_WAIT;
                    Program.UpdateApplication();//Won't do anything if there isn't an update.
                    this.lTitle.Text = "Hello " + Program.User.Name;

                    int count = Program.User.Roles.Where(x => x.RoleID == (int)Enums.Roles.HistologyLead).Count();
                    if (count != 0)
                    {
                        bLogSomeoneIn.Visible = true;
                    }
                    else if (tgLogin.Items.Count == 1)
                    {
                        if (Program.User.Machine.Attributes.Count > 1) //multi purpose computer dont auto login
                            return;
                        foreach (int i in Program.User.Machine.Attributes)
                        {
                            switch (i)
                            {
                                case (int)Enums.MachineAttribtues.Cut:
                                    if (Program.frmCut == null)
                                    {
                                        frmCut frmCut = new frmCut();
                                        this.Visible = false;
                                        frmCut.ShowDialog();
                                    }
                                    else
                                    {
                                        frmCut frmCut = Program.frmCut;
                                        this.Visible = false;
                                        frmCut.ShowDialog();
                                    }
                                    return;
                                case (int)Enums.MachineAttribtues.Emebed:
                                    if (Program.frmEmbed == null)
                                    {
                                        frmEmbed frmEmbed = new frmEmbed(Enums.Mode.Embed);
                                        this.Visible = false;
                                        frmEmbed.ShowDialog();
                                    }
                                    else
                                    {
                                        frmEmbed frmEmbed = Program.frmEmbed;
                                        this.Visible = false;
                                        frmEmbed.ShowDialog();
                                    }
                                    return;

                                case (int)Enums.MachineAttribtues.Distribution:
                                    if (Program.frmDistribute == null)
                                    {
                                        frmDistribute frmDist = new frmDistribute();
                                        this.Visible = false;
                                        frmDist.ShowDialog();
                                    }
                                    else
                                    {
                                        frmDistribute frmDist = Program.frmDistribute;
                                        frmDist.ReloadForm(false);
                                        this.Visible = false;
                                        frmDist.ShowDialog();
                                    }
                                    return;
                                case (int)Enums.MachineAttribtues.Pathologist:
                                    break;
                            }

                        }
                    }
                    break;
            }
        }

        private void bAdmin_Click(object sender, EventArgs e)
        {

            var query = from li in Program.Machine.Attributes
                        where li == (int)Enums.MachineAttribtues.Admin
                        select li;
            if (query != null && query.Count() > 0)
            {
                string userName = Environment.UserName;
                Program.User = cMethods.CreateUser(Enums.UserCreationType.Login, userName);
                cMethods.SetDefaultPrinter();

                Initalize(Enums.Mode.Login);

            }
        }

        private void bLogSomeoneIn_Click(object sender, MouseEventArgs e)
        {
            try
            {
                frmTextEnteringPopup getUserID = new frmTextEnteringPopup("Enter the new user's employee number", true, false);
                getUserID.ShowDialog();
                if (getUserID.whatTheUserEntered != "")
                {
                    int employeeNumber = Convert.ToInt32(getUserID.whatTheUserEntered);
                    cUser forgetfulEmployee = cMethods.CreateUser(Enums.UserCreationType.EmployeeNumber, employeeNumber);
                    if (forgetfulEmployee.Name == null)
                    {
                        frmSimplePopup pop = new frmSimplePopup("Employee not found.", true);
                        pop.ShowDialog();
                    }
                    else
                    {
                        bLogSomeoneIn.Visible = false;
                        Program.User = forgetfulEmployee;
                        Initalize(Enums.Mode.Login);
                    }
                }
            }
            catch (Exception)
            {}//die silently
        }

        private void tiBlockPrint_ItemClick(object sender, TileItemEventArgs e)
        {
            if (currentMode == Enums.Mode.Login)
            {
                frmBlockPrint frm = new frmBlockPrint();
                this.Visible = false;
                frm.ShowDialog();
            }
        }

        private void tiManualDistribute_ItemClick(object sender, TileItemEventArgs e)
        {
            if (currentMode == Enums.Mode.Login)
            {
                frmManualDistribute frm = new frmManualDistribute();
                this.Visible = false;
                frm.ShowDialog();
            }
        }

        private void tiWorklist_ItemClick(object sender, TileItemEventArgs e)
        {
            if (currentMode == Enums.Mode.Login)
            {
                frmWorklist frm = new frmWorklist();
                this.Visible = false;
                frm.ShowDialog();
            }
        }

        private void tiAccession_ItemPress(object sender, TileItemEventArgs e)
        {
            if (currentMode == Enums.Mode.Login)
            {
                frmAcc frm = new frmAcc();
              //  frmSearch frm = new frmSearch(Enums.FormControls.frmSearch);
                this.Visible = false;
                frm.ShowDialog();
            }
        }
    }
}