using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using DataReprocess_LogFile.Functions;
using DataReprocess_LogFile.SendMessages;
using SchraderElectronics.SEL_InterfaceLibrary;

namespace DataReprocess_LogFile
{
    public partial class frmFindRecords : Form
    {
        public static string initialFolderPath = @"C:\";

        private string IDFilePath = string.Empty;
        private string DataFilePath = string.Empty;
        private string OutputFilePath = string.Empty;

        public frmFindRecords()
        {
            InitializeComponent();
        }

        private void btnIDFilepath_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = initialFolderPath;
            if (o.ShowDialog() == DialogResult.OK)
            {
                initialFolderPath = Path.GetDirectoryName(o.FileName);
                txtIDs.Text = o.FileName;
            }
        }

        private void btnDataFilepath_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = initialFolderPath;
            if (o.ShowDialog() == DialogResult.OK)
            {
                initialFolderPath = Path.GetDirectoryName(o.FileName);
                txtData.Text = o.FileName;
            }
        }

        private void btnOutputFilePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog o = new SaveFileDialog();
            o.InitialDirectory = initialFolderPath;
            if (o.ShowDialog() == DialogResult.OK)
            {
                initialFolderPath = Path.GetDirectoryName(o.FileName);
                if (Path.GetExtension(o.FileName) == null)
                    o.FileName += ".txt";
                txtOutput.Text = o.FileName;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            IDFilePath = txtIDs.Text;
            DataFilePath = txtData.Text;
            OutputFilePath = txtOutput.Text;

            string _Error = string.Empty;
            SearchAndStore sas = new SearchAndStore();
            switch (sas.ProcessFiles(IDFilePath, DataFilePath, OutputFilePath, ref _Error, chkCreateDeclaration.Checked, lblSQLTablePath.Text))
            {
                case true:
                    MessageBox.Show("Finito");
                    if (MessageBox.Show("Do you want to send the data?", "Reprocess Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        frmSendMessages sn = new frmSendMessages(OutputFilePath);
                        sn.ShowDialog();
                        if (
    MessageBox.Show(string.Format("Do you want to delete file {0}", OutputFilePath), "Complete",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            File.Delete(OutputFilePath);
                        }
                    }
                    break;
                case false:
                    MessageBox.Show(_Error);
                    break;
            }

        }

        private void chkCreateDeclaration_CheckedChanged(object sender, EventArgs e)
        {
            lblSQLTablePath.Text = string.Format(@"C:\Temp\SQLTable_{0}", DateTime.Now);
        }

    }
}
