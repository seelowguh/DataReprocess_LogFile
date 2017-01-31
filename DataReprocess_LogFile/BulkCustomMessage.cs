using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SchraderElectronics.SEL_InterfaceLibrary;

namespace DataReprocess_LogFile
{
    public partial class BulkCustomMessage : Form
    {
        public BulkCustomMessage()
        {
            InitializeComponent();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            lstMessages.Items.Clear();
            txtMessage.BackColor = Color.White;
            txtIDs.BackColor = Color.White;

            if (txtMessage.Text == string.Empty)
            {
                txtMessage.BackColor = Color.Red;
                return;
            }

            if (txtIDs.Text == string.Empty)
            {
                txtIDs.BackColor = Color.Red;
                return;
            }

            foreach (string id in txtIDs.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                if(id != string.Empty)
                    lstMessages.Items.Add(string.Format(txtMessage.Text, id));

            txtIDs.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = lstMessages.Items.Count;
            toolStripStatusLabel1.Text = toolStripProgressBar1.Value.ToString();

            // Process Messages
            if (
                MessageBox.Show("Are you ready to send these messages?", "Are you ready?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (object t in lstMessages.Items)
                {
                    string msg = t.ToString();

                    if (txtQueueNumber.Text == string.Empty)
                        clsClarifi.TriggerAgent(txtEventName.Text, txtInstallation.Text, msg, "RX", "PVQ");
                    else
                        clsClarifi.TriggerAgent(txtEventName.Text, txtInstallation.Text, msg, "RX", "PVQ",
                            (Convert.ToInt32(txtQueueNumber.Text) > 0 && Convert.ToInt32(txtQueueNumber.Text) < 10) ? Convert.ToInt32(txtQueueNumber.Text) : 1);

                    toolStripProgressBar1.Increment(1);
                    toolStripStatusLabel1.Text = toolStripProgressBar1.Value.ToString();
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = @"C:\Temp\";
            if (of.ShowDialog() == DialogResult.OK)
            {
                lstMessages.Items.Clear();
                using (StreamReader sr = new StreamReader(of.FileName))
                {
                    while (sr.Peek() != -1)
                    {
                        string r = sr.ReadLine();
                        if (r!= string.Empty)
                            lstMessages.Items.Add(r);
                    }
                }

            }
        }

        private void BulkCustomMessage_Load(object sender, EventArgs e)
        {

        }

        private void clearIDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtIDs.Clear();
        }

        private void clearMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstMessages.Items.Clear();
        }
    }
}
