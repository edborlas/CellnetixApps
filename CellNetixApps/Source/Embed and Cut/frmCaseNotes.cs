using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CellNetixApps.Source.Classes;
using CellNetixApps.Source.Database;
using CellNetixApps.Source.Forms;//for frmTextEnteringPopup
using DevExpress.XtraEditors;

namespace CellNetixApps.Source.Embed_and_Cut
{
    public partial class frmCaseNotes : DevExpress.XtraEditors.XtraForm
    {
        private TileItem clickedTopic;
        public frmCaseNotes()
        {
            InitializeComponent();
            //color tiles
            cMethods.ColorTiles(tcTopics, Program.ColorToggledOff);
            tiSubmit.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
            tiCancel.AppearanceItem.Normal.BackColor = Program.ColorLink;
            tiKeyboard.AppearanceItem.Normal.BackColor = Program.ColorLink;
            //adds all the topics
            List<cNoteTopic> lTopics = new List<cNoteTopic>();
            CellappsDataContext db = new CellappsDataContext();
            var query = from note in db.Note_Topics
                        orderby note.Description
                        select note;
            foreach (var note in query)
            {
                cNoteTopic topic = new cNoteTopic();
                topic.NoteTopicID = note.Note_Topic_ID;
                topic.Description = note.Description;
                lTopics.Add(topic);
            }

            foreach (cNoteTopic note in lTopics)
            {
                TileItem ci = new TileItem();
                ci.Text = note.Description;
                ci.Tag = note.NoteTopicID;
                tgTopics.Items.Add(ci);
                ci.ItemClick += tiTopic_ItemClick;
            }
            //Nothing clicked, can't submit
            clickedTopic = null;
            tiSubmit.Tag = false;

            //get the case if there isn't already one
            if (Program.Acc == null)
            {
                frmTextEnteringPopup getPLNo = new frmTextEnteringPopup("Please Enter the Case Number: ", true, true);
                getPLNo.ShowDialog();
            }
            lAccessionNo.Text = Program.Acc.AccessionNo;
        }
        private void tiTopic_ItemClick(object sender, TileItemEventArgs e)
        {
            if (clickedTopic != null)
            {//turn off old topic
                clickedTopic.Checked = false;
                clickedTopic.AppearanceItem.Normal.BackColor = Program.ColorToggledOff;
                clickedTopic = null;
            }
            clickedTopic = e.Item;
            clickedTopic.Checked = true;
            clickedTopic.AppearanceItem.Normal.BackColor = Program.ColorToggledOn;
            this.ActiveControl = meNotes;
            if (meNotes.Text.Length > 1)
                EnableSubmit();
        }
        private void tiSubmit_ItemClick(object sender, TileItemEventArgs e)
        {
            if ((bool)tiSubmit.Tag)
            {
                cMethods.StopOSK();
                //to get into this if these have to be non-null already so don't check.
                string note = meNotes.Text;
                string topic = clickedTopic.Text;
                //submit note
                PowerPathDataContext pdb = new PowerPathDataContext();
                pdb.stprc_clntx_path_add_note_logic(Program.Acc.AccID, Program.User.PPuserID, topic, note, (char)Enums.Note.Insert, null);
            }
            this.Close();
        }

        private void tiKeyboard_ItemClick(object sender, TileItemEventArgs e)
        { cMethods.StartOSK(); }

        private void tiCancel_ItemClick(object sender, TileItemEventArgs e)
        {
            cMethods.StopOSK();
            this.Close();
        }

        private void meNotes_TextChanged(object sender, EventArgs e)
        {
            //will be hit everytime the user stops to think about what they are writing... oh well.
            if (meNotes.Text.Length > 0 && clickedTopic != null)
                EnableSubmit();
            else
                DisableSubmit();
        }
        //submit's tag controls whether its pressed action should occur
        private void EnableSubmit()
        {
            tiSubmit.Tag = true;
            tiSubmit.AppearanceItem.Normal.BackColor = Program.ColorLink;
        }
        private void DisableSubmit()
        {
            tiSubmit.Tag = false;
            tiSubmit.AppearanceItem.Normal.BackColor = Program.ColorDisabled;
        }
    }
}