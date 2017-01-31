using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataReprocess_LogFile.SendMessages;
using SchraderElectronics.SEL_InterfaceLibrary;

namespace DataReprocess_LogFile.Functions
{
    public class ReadAndSend
    {
        public class ClarifiDetails
        {
            public string EventName, Installation, Execution, QueueType;
            public bool IsSpecificQueues, RotateQueues;
            public int QueueNumber;
        }

        private static ClarifiDetails cDetails;
        private string sFilePath;
        public delegate void dFinishedTask(string xFilePath, bool xComplete);
        public event dFinishedTask FinishedTask;
        public delegate void dRaiseMessage(string Message);
        public event dRaiseMessage RaiseMessage;
        public delegate void dRecordCounter(int Counts);
        public event dRecordCounter RecordCounter;
        
        public ReadAndSend(string FilePath)
        {
            sFilePath = FilePath;
            cDetails = LoadSettings();
        }

        public ClarifiDetails LoadSettings()
        {
            ClarifiDetails c = new ClarifiDetails();

            c.EventName = Properties.Settings.Default.EventName;
            c.Execution = Properties.Settings.Default.Execution;
            c.Installation = Properties.Settings.Default.Installation;
            c.IsSpecificQueues = Properties.Settings.Default.SpecificQueues;
            c.QueueNumber = Properties.Settings.Default.QueueNumber;
            c.QueueType = Properties.Settings.Default.QueueType;
            c.RotateQueues = Properties.Settings.Default.RotateQueues;

            return c;
        }

        public void ReadMessages()
        {
            bool xComplete = false;
            int RecordCount = 0;
            cDetails = LoadSettings();
            try
            {
                if(!frmSendMessages.RunThread)
                    return;
                if (!File.Exists(sFilePath))
                    return;

                StreamReader sr = new StreamReader(sFilePath);
                {
                    while (!sr.EndOfStream && frmSendMessages.RunThread)
                    {
                        string s = sr.ReadLine();
                        if (s != string.Empty)
                        {
                            SendMessages(s, cDetails);
                            if (RecordCounter != null)
                                RecordCounter(RecordCount++);
                        }
                    }
                    sr.Dispose();
                    xComplete = true;
                }
            }
            catch (ClarifiException ex)
            {
                if (RaiseMessage != null)
                    RaiseMessage(ex.Message);
            }
            frmSendMessages.RunThread = false;
            //frmSendMessages.Finish(sFilePath);
            if (FinishedTask != null)
                FinishedTask(sFilePath, xComplete);
            Thread.CurrentThread.Join();
        }

        private void SendMessages(string Message, ClarifiDetails c)
        {
            if (clsClarifi.CheckAgentStatus() == clsClarifi.AgentStatus.Started)
            {
                if (c.IsSpecificQueues)
                {
                    if (c.RotateQueues)
                    {
                        if (c.QueueNumber > 10 || c.QueueNumber < 2)
                        {
                            c.QueueNumber = 1;
                        }
                        clsClarifi.TriggerAgent(c.EventName, c.Installation, Message, c.Execution, c.QueueType, c.QueueNumber);
                        c.QueueNumber++;
                    }
                    else
                    {
                        if (c.QueueNumber > 10 || c.QueueNumber < 2)
                        {
                            c.QueueNumber = 2;
                        }
                        clsClarifi.TriggerAgent(c.EventName, c.Installation, Message, c.Execution, c.QueueType, c.QueueNumber);
                        
                    }
                }else
                    clsClarifi.TriggerAgent(c.EventName, c.Installation, Message, c.Execution, c.QueueType);
            }
            else
            {
                throw new ClarifiException("SendMessages","Agent stopped - start and try again", "");
            }

        }

    }

    [Serializable]
    public class ClarifiException : Exception
    {
        public ClarifiException()
            : base() { }

        public ClarifiException(string message)
            : base(message) { }

        public ClarifiException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ClarifiException(string function,string format, params object[] args)
            : base(string.Format("Function: " + function + " - " + format, args)) { }

        public ClarifiException(string message, Exception innerException)
            : base(message, innerException) { }

        public ClarifiException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected ClarifiException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

}
