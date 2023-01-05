using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SumakeController
{
    internal class CommunicationCommands
    {
        private String connectionString = ConfigurationManager.ConnectionStrings["think"].ConnectionString;
        private int deviceID = 0;
        private string temporalListen = "";
        private int unused = 0;
        private string screwdriverIDCode = "SMT0121070001A";
        private string controllerIDCode = "2106001A";
        /// <summary>Mode options:<para>0: ADV, 1: STD, 2: ALI, 3: SET</para></summary>
        private int mode = 1;
        private int job;
        private int jobSequence;
        private int selectScrewDriver = 1;
        private int tighteningProgram;
        private int deviceType = 4;
        private string controllerVersion = "1.017";
        private string screwdriverVersion = "1.15";
        private int screwdriverStatus = 0;
        private char nsasstatus = '0';
        private int instructionNumber = 1;
        /// <summary>DeviceName options:<para>0: AMS, 1: DAS</para><para>(Default us 0 for RS232 commands)</para></summary>
        private int deviceName = 0;
        private int totalScrews = 0;
        private int remainingScrews = 0;
        public int DeviceID { get => deviceID; set => deviceID = value; }
        public string TemporalListen { get => temporalListen; set => temporalListen = value; }
        public int Unused { get => unused; set => unused = value; }
        public string ScrewdriverIDCode { get => screwdriverIDCode; set => screwdriverIDCode = value; }
        public string ControllerIDCode { get => controllerIDCode; set => controllerIDCode = value; }
        public int Mode { get => mode; set => mode = value; }
        public int Job { get => job; set => job = value; }
        public int JobSequence { get => jobSequence; set => jobSequence = value; }
        public int SelectScrewDriver { get => selectScrewDriver; set => selectScrewDriver = value; }
        public int TighteningProgram { get => tighteningProgram; set => tighteningProgram = value; }
        public int DeviceType { get => deviceType; set => deviceType = value; }
        public string ControllerVersion { get => controllerVersion; set => controllerVersion = value; }
        public string ScrewdriverVersion { get => screwdriverVersion; set => screwdriverVersion = value; }
        public int ScrewdriverStatus { get => screwdriverStatus; set => screwdriverStatus = value; }
        public char Nsasstatus { get => nsasstatus; set => nsasstatus = value; }
        public int InstructionNumber { get => instructionNumber; set => instructionNumber = value; }
        public int DeviceName { get => deviceName; set => deviceName = value; }
        public int TotalScrews { get => totalScrews; set => totalScrews = value; }
        public int RemainingScrews { get => remainingScrews; set => remainingScrews = value; }

        internal void Listener(string data, SMTC1Controller sMTC1Controller)
        {
            if (TemporalListen != data)
            {
                TemporalListen = data;
                string[] parameters = data.Split(',');
                switch (parameters[0])
                {
                    case "REQ100": Debug.WriteLine(data); this.REQ100(parameters,sMTC1Controller); break;
                    case "DATA100": Debug.WriteLine(data); this.DATA100(parameters, sMTC1Controller); break;
                    case "DATA101": Debug.WriteLine(data); this.DATA101(parameters, sMTC1Controller); break;
                    default: Debug.WriteLine(data); break;
                }
            }
        }

        private void REQ100(string[] parameters, SMTC1Controller sMTC1Controller)
        {
            DeviceID = Int32.Parse(parameters[11]);
            ScrewdriverIDCode = parameters[12];
            ControllerIDCode = parameters[13];
            Mode = Int32.Parse(parameters[14]);
            Job = Int32.Parse(parameters[15]);
            JobSequence = Int32.Parse(parameters[16]);
            SelectScrewDriver = Int32.Parse(parameters[18]);
            TighteningProgram = Int32.Parse(parameters[19]);
            DeviceType= Int32.Parse(parameters[20]);
            ScrewdriverStatus= Int32.Parse(parameters[21]);
            ControllerVersion = parameters[22];
            ScrewdriverVersion= parameters[23];
            ScrewdriverStatus = Int32.Parse(parameters[24]);
            var left = Regex.Match(parameters[25], @".*/", RegexOptions.None);
            var right = Regex.Match(parameters[25], @"/.*", RegexOptions.None);
            //TotalScrews = Int32.Parse(left.Value.Substring(0, left.Value.Length - 1));
            //RemainingScrews = Int32.Parse(left.Value.Substring(1));
            //sMTC1Controller.updateUi(this);
        }

        public string CMD100()
        {
            Time time = new Time();
            return "{" + String.Format("CMD{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},", "100", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, DeviceName, InstructionNumber) + "}";
        }
        public string CMD104(int Job, int JobSequence)
        {
            Time time = new Time();
            return "{" + String.Format("CMD{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},",
                "104",
                time.Year, time.Month, time.Day, time.Hour, time.Minute,
                time.Second, time.CheckSum, time.KeyCode, DeviceName,
                Job,
                JobSequence,
                InstructionNumber) + "}";
        }
        //{CMD104,2022,11,17,36,00,2086,1,1,3,1}

        public string REQ100Out(string DeviceID, string Job, string JobSequence, string TighteningProgram, string RemainingScrews, string TotalScrews)
        {
            Time time = new Time();
            return "{" + String.Format("REQ{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},", "104", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, Unused, Unused, DeviceID, ScrewdriverIDCode, ControllerIDCode, Mode, Unused, Job, JobSequence, SelectScrewDriver, TighteningProgram, DeviceType, ScrewdriverStatus, ControllerVersion, ScrewdriverVersion, Nsasstatus, String.Format("{0}/{1}", RemainingScrews, TotalScrews), InstructionNumber) + "}";
        }
        

        private async void DATA100(string[] parameters, SMTC1Controller sMTC1Controller)
        {
            var query = String.Format("INSERT INTO [CESAT].[dbo].[TighteningData] ([Date],[IdSerie],[DeviceID],[ScrewSerial],[DeviceSerial],[Job],[Js],[Ts],[ProgramName],[TorqueUnit],[FasteningTimeMs],[FasteningThread],[RemainingScrews],[TotalScrews],[FasteningStatus],[NSAS]) VALUES (GETDATE(),{14},{0},'{1}','{2}',{3},{4},{5},'{6}',{7},{8},{9},{10},{11},'{12}',{13})",parameters[10],parameters[11],parameters[12],parameters[14],parameters[15],parameters[16],parameters[17],parameters[20],parameters[21],parameters[22],Int32.Parse(parameters[23].Substring(0, 2)),Int32.Parse(parameters[23].Substring(3)),parameters[25],parameters[26],sMTC1Controller.getIDSerie());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
            }
        }

        private void DATA101(string[] parameters, SMTC1Controller sMTC1Controller)
        {
            TemporalListen = "";
            sMTC1Controller.updateTorque(parameters[1]);
        }
    }
}
