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
using DataReprocess_LogFile.SendMessages;
using DataReprocess_LogFile;

namespace DataReprocess_LogFile
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFindRecords frm = new frmFindRecords();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReprocessLogFile frm = new frmReprocessLogFile();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = frmFindRecords.initialFolderPath;
            if (o.ShowDialog() == DialogResult.OK)
            {
                frmFindRecords.initialFolderPath = Directory.GetParent(o.FileName).FullName;
                frmSendMessages sn = new frmSendMessages(o.FileName);
                sn.ShowDialog();
                if(File.Exists(o.FileName))
                    if (MessageBox.Show(string.Format("Do you want to delete file {0}", o.FileName), "Complete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        File.Delete(o.FileName);
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            BulkCustomMessage frm = new BulkCustomMessage();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProcessLWDatabase frm = new ProcessLWDatabase();
            frm.ShowDialog();
        }



    }
}
