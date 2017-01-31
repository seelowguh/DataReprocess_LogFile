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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Logging;
using SchraderElectronics.SEL_InterfaceLibrary;
using System.Data.SqlClient;

namespace DataReprocess_LogFile
{
    public partial class ProcessLWDatabase : Form
    {
        public ProcessLWDatabase()
        {
            InitializeComponent();
        }

        private string ConnectionString { get { return txtConnection.Text; } set { txtConnection.Text = value; } }
        private string Query { get { return txtQuery.Text; } set { txtQuery.Text = value; } }
        private string PCName { get { return txtPcName.Text; } set { txtPcName.Text = value; } }

        private int FileCount = 0;
        private int RecordCount = 0;
        private int RecordCountToFile = 5000;
        private string StandardFilePath = @"C:\Temp\GenericData{0}.dat";
        private string CurrentFilePath = string.Empty;

        private bool RunThread = true;
        private Thread operatingThread = null;
        
        private void ProcessLWDatabase_Load(object sender, EventArgs e)
        {
            Query = "SELECT Process, TestTime, TestCell, PassFail, FailReason, ValveBodyID, TestData, WCID FROM dbo.Get_LW_TestData()";
            PCName = "selalsw02";
            ConnectionString = "Data Source="+ PCName + @"\sqlexpress;Initial Catalog=IPTE-FM13403;Persist Security Info=True;User ID=sa;Password=ipte";

            lstOutput.Columns.Add("Message", lstOutput.Width - 10);

            operatingThread = new Thread(GetRecords);
            operatingThread.IsBackground = true;
        }

        private void GetRecords()
        {
            if (PCName == string.Empty)
            {
                LogToGUI("Enter PC Name");
                return;
            }

            if (!RunThread)
                operatingThread.Join();

            try
            {
                using (SqlConnection sCONN = new SqlConnection(ConnectionString))
                {
                    sCONN.Open();
                    using (SqlCommand sCMD = new SqlCommand(Query, sCONN))
                    {
                        using (SqlDataReader sDR = sCMD.ExecuteReader())
                        {
                            while (sDR.Read() && RunThread)
                            {
                                ProcessRecord(Strings.RTrim( sDR.GetString(0)), Strings.RTrim( sDR.GetString(1)), sDR.GetInt32(2), sDR.GetInt32(3), Strings.RTrim(sDR.GetString(4)), Strings.RTrim( sDR.GetString(5)), Strings.RTrim( sDR.GetString(6))
                                    , sDR.GetInt32(7));
                            }
                            RunThread = false;
                        }
                    }
                    sCONN.Close();
                }
            }
            catch (SqlException ex)
            {
                LogToGUI(ex.Message);
            }
            catch (Exception ex)
            {
                LogToGUI(ex.Message);
            }
        }

        private void ProcessRecord(string Process, string TestTime, int TestCell, int PassFail, string FailReason, string ValvebodyID, string TestData, int WCID)
        {
            //  if there is no filepath set, or if there is a full set of records to the file - create a new file.
            if (CurrentFilePath == string.Empty || RecordCount%RecordCountToFile == 0)
            {
                CurrentFilePath = GetNextFilePath();
                LogToGUI(CurrentFilePath);
            }

            string _Containment = "LASERWELD";
            string _ContainmentType = "Set Containment";
            if (PassFail == 1)
                _ContainmentType = "Remove Containment";

            string WriteToFile = string.Format("<Message><TestData><Process>{0}</Process><PanelID>N/A</PanelID><PCB_Position>0</PCB_Position><ASICID>0</ASICID><TestTime>{1}</TestTime><TestCell>{2}</TestCell><PassFail>{3}</PassFail><FailReason>{4}</FailReason><SerialNumber>N/A</SerialNumber><ValvebodyID>{5}</ValvebodyID><Data>{6}</Data><WCID>{7}</WCID><DataType>3</DataType><Operator>{8}</Operator><Containment>{9}</Containment><ContainmentType>{10}</ContainmentType></TestData></Message>"
                , Process, TestTime, TestCell, PassFail, FailReason, ValvebodyID, TestData, WCID, PCName, _Containment, _ContainmentType);

            clsClarifi.LogMessage(CurrentFilePath, WriteToFile);
            RecordCount++;
        }

        private string GetNextFilePath()
        {
            string fp;
            do
            {
                FileCount++;
                fp = string.Format(StandardFilePath, FileCount);
            } while (File.Exists(fp));
            return fp;
        }

        private void LogToGUI(string Message)
        {
            lstOutput.Invoke((MethodInvoker) (() => lstOutput.Items.Insert(0, Message)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunThread = true;
            if(operatingThread.ThreadState != ThreadState.Running)
                if(operatingThread == null || operatingThread.ThreadState == ThreadState.Stopped)
                    operatingThread = new Thread(GetRecords);
                operatingThread.Start();
        }
    }
}
