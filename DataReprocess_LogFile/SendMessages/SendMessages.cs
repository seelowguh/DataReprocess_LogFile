using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataReprocess_LogFile.Forms;
using DataReprocess_LogFile.Functions;
using DataReprocess_LogFile.Properties;

namespace DataReprocess_LogFile.SendMessages
{
    public partial class frmSendMessages : Form
    {
        private string _FilePath;
        private ReadAndSend rs;
        private Thread OperatingThread = null;
        public static bool RunThread = false;

        public frmSendMessages(string FilePath)
        {
            InitializeComponent();
            _FilePath = FilePath;
            rs = new ReadAndSend(_FilePath);
            OperatingThread = new Thread(rs.ReadMessages);
            OperatingThread.IsBackground = true;
        }

        private void frmSendMessages_Load(object sender, EventArgs e)
        {
            lstOutput.View = View.Details;
            lstSettings.View = View.Details;

            lstOutput.Columns.Add("Messages", lstOutput.Width - 4, HorizontalAlignment.Left);
            lstSettings.Columns.Add("", lstSettings.Width - 4, HorizontalAlignment.Left);

            LoadSettings();

            lblFilePath.Text = _FilePath;

            rs.FinishedTask += Finish;
            rs.RaiseMessage += RsOnRaiseMessage;
            rs.RecordCounter += RsOnRecordCounter;
        }

        private void RsOnRecordCounter(int counts)
        {
            lblRecord.Invoke((MethodInvoker) (() => lblRecord.Text = counts.ToString()));
        }

        private void RsOnRaiseMessage(string message)
        {
            WriteToListView(lstOutput, message);
        }

        private void LoadSettings()
        {
            ReadAndSend.ClarifiDetails cd = new ReadAndSend.ClarifiDetails();

            cd = rs.LoadSettings();
            ClearListView(lstSettings);
            WriteToListView(lstSettings, string.Format("Ev: {0}", cd.EventName));
            WriteToListView(lstSettings, string.Format("In: {0}", cd.Installation));
            WriteToListView(lstSettings, string.Format("Qt: {0}", cd.QueueType));
            WriteToListView(lstSettings, string.Format("Ex: {0}", cd.Execution));
            WriteToListView(lstSettings, string.Format("Sq: {0}", cd.IsSpecificQueues));
            WriteToListView(lstSettings, string.Format("Qn: {0}", cd.QueueNumber));
            WriteToListView(lstSettings, string.Format("Rq: {0}", cd.RotateQueues));
        }

        private void WriteToListView(ListView l, string s)
        {
            l.Invoke((MethodInvoker) (() => l.Items.Insert(0, s)));
            //l.Items.Insert(0, s);
        }

        private void ClearListView(ListView l)
        {
            l.Invoke((MethodInvoker)(() => l.Items.Clear())); 
            //l.Items.Clear();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //rs.ReadMessages();
                RunThread = true;
                if(OperatingThread.ThreadState == ThreadState.Stopped)
                    OperatingThread = new Thread(rs.ReadMessages);
                if(OperatingThread.ThreadState != ThreadState.Running)
                    OperatingThread.Start();
            }
            catch (ClarifiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Finish(string sFilePath, bool xComplete)
        {
            if (xComplete)
            {
                MessageBox.Show("Finito");
                if (File.Exists(sFilePath))
                    if (MessageBox.Show(string.Format("Do you want to delete file {0}", sFilePath), "Complete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(sFilePath);
                        this.Invoke((MethodInvoker) (() => this.Close()));
                    }
            }
            else
            {
                MessageBox.Show("Error - See output log");
            }
        }

        private void lstSettings_DoubleClick(object sender, EventArgs e)
        {
            frmSettings _Settings = new frmSettings();
            _Settings.ShowDialog();
            LoadSettings();
        }
    }
}
