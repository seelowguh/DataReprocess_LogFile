using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DataReprocess_LogFile.Functions;
using SchraderElectronics.SEL_InterfaceLibrary;

namespace DataReprocess_LogFile
{
    public partial class frmReprocessLogFile : Form
    {
        private string Eventname = string.Empty;
        private string Installation = String.Empty;
        private string Execution = string.Empty;
        private string QueueType = string.Empty;
        private int[] QueueNumbers = null;

        private bool xSendData = Properties.Settings.Default.SendData;

        private int QueueNumberSize = 0;

        public frmReprocessLogFile()
        {
            InitializeComponent();
            Eventname = "GenericData_Create2";
            LogConfig("Ev: {0}", Eventname);
            Installation = "SEL050050D";
            LogConfig("In: {0}",Installation);
            Execution = "RX";
            LogConfig("Ex: {0}", Execution);
            QueueType = "PVQ";
            LogConfig("Qt: {0}", QueueType);
            QueueNumbers = new int[3];
            QueueNumbers[0] = 8;
            QueueNumbers[1] = 9;
            QueueNumbers[2] = 10;

            string _queueNumbers = string.Empty;
            foreach (int i in QueueNumbers)
            {
                _queueNumbers += string.Format("[{0}]", i);
            }

            LogConfig("Qn: {0}", _queueNumbers);
            LogConfig("SD: {0}", xSendData);

            listView2.Enabled = xSendData;

            QueueNumberSize = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == string.Empty) || !File.Exists(textBox1.Text))
            {
                OpenFileDialog of = new OpenFileDialog();
                of.InitialDirectory = @"C:\Schrader Log\";
                of.DefaultExt = ".txt";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = of.FileName;
                }
                else
                {
                    of.Dispose();
                    return;
                }

                of.Dispose();
            }

            if (File.Exists(textBox1.Text))
            {
                string MachineName = "Enter Machine Name";
                if (CustomWindowsFunctions.InputDialog(ref MachineName) != DialogResult.OK)
                {
                    return;
                }

                string xOutputFileName = string.Empty;
                string xDefaultFilePath = @"C:\Temp\Output.txt";
                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.InitialDirectory = @"C:\Temp\";
                sfDialog.DefaultExt = ".txt";
                sfDialog.AddExtension = true;
                if (sfDialog.ShowDialog() == DialogResult.OK)
                    xOutputFileName = sfDialog.FileName;
                else
                {
                    xOutputFileName = xDefaultFilePath;
                    MessageBox.Show("Default will be used: " + xOutputFileName);
                }
                string _optionalLogPath = string.Empty;
                StreamReader sr = new StreamReader(textBox1.Text);
                while (!sr.EndOfStream)
                {
                    string _Line = sr.ReadLine();
                    
                    string _Valvebody = string.Empty;
                    string _TestTime = string.Empty;
                    string _Process = string.Empty;
                    if (_Line != string.Empty)
                    {
                        _Line = StructureData(_Line, ref _Valvebody, ref _TestTime, ref _Process, MachineName);

                        if (WriteToDB(_Valvebody, _TestTime, _Process))
                        {
                            if(xSendData)
                                SendData(_Line, ref _optionalLogPath);
                            else
                                clsClarifi.LogMessage(xOutputFileName, _Line);
                        }
                    }
                }
                if(_optionalLogPath != String.Empty)
                    LogMessage("logged to File: {0}", _optionalLogPath);
                sr.Dispose();
            }
            else
            {
                LogMessage("File doesn't exist");
            }
            MessageBox.Show("Finito");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = @"C:\Schrader Log\";
            of.DefaultExt = ".txt";
            if (of.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = of.FileName;
            }

            of.Dispose();
        }

        private void LogConfig(string _Message)
        {
            listView2.Items.Add(_Message);
        }

        private void LogConfig(string _Message, params object[] _params)
        {
            LogConfig(string.Format(_Message, _params));
        }

        private void LogMessage(string _Message)
        {
            //  Add to log view    
            listView1.Items.Insert(0, _Message);
        }

        private void LogMessage(string _Message, params object[] _params)
        {
            LogMessage(string.Format(_Message, _params));
        }

        private void SendData(string _Message, ref string _LogPath)
        {
            if (clsClarifi.CheckAgentStatus() == clsClarifi.AgentStatus.Started)
            {
                if (QueueNumbers != null)
                    clsClarifi.TriggerAgent(Eventname, Installation, _Message, Execution, QueueType);
                else
                {
                    clsClarifi.TriggerAgent(Eventname, Installation, _Message, Execution, QueueType,
                        QueueNumbers[QueueNumberSize - 1]);

                    if (QueueNumberSize >= QueueNumbers.Length)
                        QueueNumberSize = 0;
                    else
                        QueueNumberSize ++;
                }
            }
            else
            {
                _LogPath = @"C:\Temp\ResultsFile.txt";
                LogMessage(string.Format("Agent turned off, saving to file {0}", _LogPath));
                clsClarifi.LogMessage(_LogPath, _Message);
            }
        }

        private string StructureData(string _Message, ref string _Valve, ref string _tTime, ref string Process, string MachineName)
        {
            string returnMessage = string.Empty;
            try
            {
                int iPassFail = 0;
                string pNode = string.Empty, sProcess = string.Empty, sContents = string.Empty;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(_Message);
                XmlNodeReader r = new XmlNodeReader(doc);

                returnMessage += "<Message><TestData>";

                while (r.Read())
                {
                    if (r.NodeType == XmlNodeType.Element)
                    {
                        pNode = r.Name;
                        r.MoveToContent();
                    }

                    if (r.NodeType == XmlNodeType.Text)
                    {
                        if (pNode == "Process")
                        {
                            switch (r.Value.ToUpper())
                            {
                                case "LEAK TEST 1":
                                case "LEAK TEST 2":
                                case "LEAK 1":
                                case "LEAK 2":
                                    Process = "LWELD_LWELD_LEAK";
                                    returnMessage += String.Format("<{0}>{1}</{0}>", "Process", Process);
                                    break;
                                case "LASER WELDING 1":
                                case "LASER WELDING 2":
                                case "LASER 1":
                                case "LASER 2":
                                    Process = "LWELD_WELDING";
                                    returnMessage += String.Format("<{0}>{1}</{0}>", "Process", Process);
                                    break;
                                case "LID CHECK":
                                case "LID ASSEMBLY":
                                    Process = "LWELD_LID_ASSY";
                                    returnMessage += String.Format("<{0}>{1}</{0}>", "Process", Process);
                                    break;
                            }
                        }

                        if (pNode == "TestTime")
                        {
                            _tTime = r.Value;
                            returnMessage += string.Format("<{0}>{1}</{0}>", "TestTime", r.Value);
                        }

                        if (pNode == "TestCell")
                        {
                            returnMessage += string.Format("<{0}>{1}</{0}>", "TestCell", r.Value);
                        }

                        if (pNode == "PassFail")
                        {
                            iPassFail = Convert.ToInt32(r.Value);
                            returnMessage += string.Format("<{0}>{1}</{0}>", "PassFail", r.Value);
                        }

                        if (pNode == "FailReason")
                        {
                            returnMessage += string.Format("<{0}>{1}</{0}>", "FailReason", r.Value);
                        }

                        if (pNode == "ValveBodyID")
                        {
                            _Valve = r.Value;
                            returnMessage += string.Format("<{0}>{1}</{0}>", "ValvebodyID", r.Value);
                        }

                        if (pNode == "Data")
                        {
                            returnMessage += string.Format("<{0}>{1}</{0}>", "Data", r.Value);
                        }

                        if (pNode == "WCID")
                        {
                            returnMessage += string.Format("<{0}>{1}</{0}>", "WCID", r.Value);
                        }
                    }
                }

                returnMessage +=
                    string.Format(
                        "<PanelID>N/A</PanelID><ASICID>0</ASICID><PCB_Position>0</PCB_Position><SerialNumber>N/A</SerialNumber><Operator>{0}</Operator><DataType>3</DataType>",
                        MachineName);
                string sContainment = "LASERWELD";
                string sContainmenttype = string.Empty;
                if (iPassFail == 1)
                {
                    sContainmenttype = "Remove Containment";
                }
                else
                {
                    sContainmenttype = "Set Containment";
                }
                returnMessage += "<Containment>" + sContainment + "</Containment><ContainmentType>" + sContainmenttype +
                                 "</ContainmentType>";
                returnMessage += "</TestData></Message>";
            }
            catch (XmlException ex)
            {
                returnMessage = string.Empty;
            }
            catch (Exception ex)
            {
                returnMessage = string.Empty;
            }
            return returnMessage;
        }

        private bool WriteToDB(string _V, string _Tt, string _P)
        {
            return true;
            bool _returnValue = false;

            try
            {
                OdbcConnection conn = clsDataConnections.GetODBCConnection(clsDataConnections.Connection.Central);
                OdbcCommand cmd = new OdbcCommand(string.Format("SELECT COUNT(*) FROM tbl_0000000031 WHERE FK_AS0000000091 = {0} AND Process = {2} AND TestTime >= {1}", _V, _Tt, _P), conn);
                OdbcDataReader dr = cmd.ExecuteReader();
                switch (dr.GetInt32(0))
                {
                    case 0:
                        _returnValue = false;
                        break;
                    default:
                        _returnValue =  true;
                        break;
                }
                dr.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
            catch (OdbcException ex)
            {
                LogMessage(ex.Message);
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }


            return _returnValue;
        }

        private void findGenericDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindRecords fRecords = new frmFindRecords();
            fRecords.ShowDialog();
        }



    }
}
