using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SchraderElectronics.SEL_InterfaceLibrary;

namespace DataReprocess_LogFile.Functions
{
    public class SearchAndStore
    {
        public bool ProcessFiles(string IDFilePath, string DataFilePath, string OutputFilePath, ref string ErrorString, bool CreateSQLTable, string SQLTablePath)
        {
            #region SanityCheck
            //Check if id file exists
            if (!File.Exists(IDFilePath))
            {
                ErrorString = string.Format("{0} does not exist.", IDFilePath);
                return false;
            }

            //Check if data file exists
            if (!File.Exists(DataFilePath))
            {
                ErrorString = string.Format("{0} does not exist.", DataFilePath);
                return false;
            }

            #endregion

            string sSQL = string.Empty;
            string sTableName = "TempTable";

            if (CreateSQLTable)
            {
                sSQL += string.Format("DECLARE @{0} TABLE ( VBID AS VARCHAR(20) ); ", sTableName);
            }

            //Create array for IDs & parse the file
            string[] aIDs = GetIDs(IDFilePath).ToArray();

            //Create the list of structures to add the data to
            List<Messages> lM = new List<Messages>();

            //Open reader for data file
            StreamReader sr = new StreamReader(DataFilePath);
            {
                while (!sr.EndOfStream)
                {
                    string _data = sr.ReadLine();
                    foreach (string s in aIDs)
                    {
                        //  Check to see if the ID is in the result line
                        if (_data.Contains(s))
                        {
                            if (CreateSQLTable)
                            {
                                sSQL += string.Format("INSERT INTO @{0} (VBID) VALUES ('{1}'); ", sTableName, s);
                            }

                            PopulateStructure(lM, _data);
                        }
                    }
                }
            }
            sr.Dispose();

            if (CreateSQLTable)
            {
                sSQL += string.Format("SELECT DISTINCT VBID FROM @{0};", sTableName);
                clsClarifi.LogMessage(SQLTablePath, sSQL);
            }

            foreach (Messages m in lM)
            {
                clsClarifi.LogMessage(OutputFilePath, m.message);
            }

            return true;

        }

        private void PopulateStructure(List<Messages> m, string Message)
        {
            Messages _m = new Messages();
            _m.message = Message;
            try
            {
                ParseXML(ref _m.valvebody, ref _m.process, ref _m.testtime, _m.message);
            }
            catch (XmlException ex)
            {
                return;
            }

            //Replaces the message with the next message if it doesn't exist, otherwise adds it
            if (!(m.Exists(x => x.process == _m.process && x.valvebody == _m.valvebody)))
                m.Add(_m);
            else
                m.Where(w => w.valvebody == _m.valvebody && w.process == _m.process && w.testtime <= _m.testtime)
                    .ToList()
                    .ForEach(s =>
                    {
                        s.message = _m.message;
                        s.testtime = _m.testtime;
                    });
        }

        private void ParseXML(ref string v, ref string p, ref DateTime t, string m)
        {
            try
            {
                XmlDocument x = new XmlDocument();
                x.LoadXml(m);
                v = GetInnerText(x, "ValvebodyID");
                p = GetInnerText(x, "Process");
                t = Convert.ToDateTime(GetInnerText(x, "TestTime"));
            }
            catch (XmlException ex)
            {
                throw ex;
            }

        }

        private string GetInnerText(XmlDocument x, string tag)
        {
            XmlNodeList xnl = x.GetElementsByTagName(tag);
            return xnl[0].InnerText;
        }

        private List<string> GetIDs(string filepath)
        {
            List<string> l = new List<string>();

            StreamReader sr = new StreamReader(filepath);
            {
                while (!sr.EndOfStream)
                {
                    string _data = sr.ReadLine();
                    if (_data != string.Empty && ValidLength(_data))
                    {
                        l.Add(_data);
                    }
                }
            }
            sr.Dispose();
            return l;
        }


        private bool ValidLength(string ID)
        {
            switch (ID.Length)
            {
                case 14: return true;
                    break;
                case 20:
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }

    //  Changed from a struc to a class
    //  struc creates a lightweight local version, class maintains and holds values
    public class Messages
    {
        public string valvebody;
        public string process;
        public string message;
        public DateTime testtime;
    }




    }
}
