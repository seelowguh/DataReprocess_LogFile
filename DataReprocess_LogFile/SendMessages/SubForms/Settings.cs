using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataReprocess_LogFile.Forms
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            //LoadSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //  Set settings
            Properties.Settings.Default.EventName = txtEvent.Text;
            Properties.Settings.Default.Installation = txtInstallation.Text;
            if (radLX.Checked)
                Properties.Settings.Default.Execution = "LX";
            else
                Properties.Settings.Default.Execution = "RX";

            if (radSQYes.Checked)
                Properties.Settings.Default.SpecificQueues = true;
            else
                Properties.Settings.Default.SpecificQueues = false;

            if (radRQYes.Checked)
                Properties.Settings.Default.RotateQueues = true;
            else
                Properties.Settings.Default.RotateQueues = false;

            if (Convert.ToInt32(txtQN.Text) > 10 || Convert.ToInt32(txtQN.Text) < 2 || (!IsNumeric(txtQN.Text)))
                Properties.Settings.Default.QueueNumber = 1;
            else
                Properties.Settings.Default.QueueNumber = Convert.ToInt32(txtQN.Text);
            
            //  Save settings
            Properties.Settings.Default.Save();
            lblResponse.Text = string.Format("{0} Setting Saved.", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"));
        }

        public static bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        private void LoadSettings()
        {
            txtEvent.Text = Properties.Settings.Default.EventName;
            txtInstallation.Text = Properties.Settings.Default.Installation;
            switch (Properties.Settings.Default.Execution)
            {
                case "LX":
                    radLX.Checked = true;
                    radRX.Checked = false;
                    break;
                case "RX":
                    radLX.Checked = false;
                    radRX.Checked = true;
                    break;
                default:
                    radLX.Checked = false;
                    radRX.Checked = false;
                    break;
            }

            switch (Properties.Settings.Default.SpecificQueues)
            {
                case true:
                    radSQYes.Checked = true;
                    radSQNo.Checked = false;
                    txtQN.Enabled = true;
                    txtQN.Text = Properties.Settings.Default.QueueNumber.ToString();
                    break;
                default:
                    radSQYes.Checked = false;
                    radSQNo.Checked = true;
                    txtQN.Enabled = false;
                    break;
            }

            switch (Properties.Settings.Default.RotateQueues)
            {
                case true:
                    radRQYes.Checked = true;
                    radRQNo.Checked = false;
                    break;
                default:
                    radRQYes.Checked = false;
                    radRQNo.Checked = true;
                    break;
            }
            


        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            //  Load previous settings
            LoadSettings();
        }

        private void radSQYes_CheckedChanged(object sender, EventArgs e)
        {
            txtQN.Enabled = radSQYes.Checked;
        }

        private void radSQNo_CheckedChanged(object sender, EventArgs e)
        {
            txtQN.Enabled = radSQNo.Checked;
        }
    }
}
