using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CESATAutomationDevelop
{
    public class EAACTDSRS232
    {
        //EAACTDS PROPS
        private enum CMD
        {
            [Description("REQUEST CURRENT STATUS")] CMD0,
            [Description("COMMAND PROGRAM PARAMETER SETTINGS")] CMD2,
            [Description("COMMAND CONTROLLER PARAMETER SETTINGS")] CMD3,
            [Description("COMMAND SCREW COUNT TO ZERO")] CMD4,
            [Description("COMMAND CONFIRM (ENABLE NG STOP/OKALL STOP)")] CMD5,
            [Description("COMMAND SELECT SCREWDRIVER & PROGRAM")] CMD6,
            [Description("READ CONTROLLER PROGRAM STATUS")] CMD7,
            [Description("READ CONTROLLER PARAMETER")] CMD8,
            [Description("COMMAND STD MODE ALL SEQUENCE")] CMD10,
            [Description("READ STD MODE CURRENT SEQUENCE")] CMD11,
            [Description("READ SCREWDRIVER STATUS")] CMD16,
            [Description("ENABLE/DISABLE")] CMD51,
            [Description("RESET CONTROLLER")] CMD52,
            [Description("SETTING CONTROLLER PASSWORD")] CMD53,
            [Description("READ CONTROLLER PASSWORD")] CMD54,
            [Description("BARCODE")] CMD55,
            [Description("READ SCANNER PARAMETER SETTING")] CMD56,
            [Description("COMMAND FILTER SETTING")] CMD57,
            [Description("READ FILTER PARAMTER")] CMD58,
            [Description("COMMAND THREAD FINDING STATUS")] CMD59,
            [Description("READ THREAD FINDING STATUS")] CMD60,
        }
        private enum ReverseMode { EACH, ONCE }
        private enum BatchMode { [Description("Decrease")] DEC, [Description("Increase")] INC }
        private enum BrakeSignal { Release, Keep }
        private enum TorqueUnit { Nm, Kgf_cm, lbf_in, kgf_m }
        private enum GateMode { Once, Twice, Once_Confirm, Twice_Confirm }
        private enum SequenceMode { Off, Single, Multi }
        private enum ThreadFinding { Off, On }
        private enum Mode { ADV, STD, ALI, SET }
        private int aMSStepSequence = 1;
        private int aMSStepID = 0;
        private int program;
        private int toolInfo;
        private int batchCount;
        private float highTorque;
        private float lowTorque;
        private float highThread;
        private float lowThread;
        private float highTime;
        private float lowTime;
        private float torqueOffset;
        private int gearRatio;
        private int slowStartSpeed;
        private float slowStartTime;
        private float reconfirmTime;
        private float okAllAlarmTime;
        private float autoStopTime;
        private float runReverseTime;
        private float reverseSuspendTime;
        private float autoReverseTime;
        private int nOkStop;
        private int okAllStop;
        private int remainingScrews;
        private float okOneTime;
        private int countThread;
        private static int SafeData = 5438;
        private string screwDriverStatus;
        private string ioStatus;
        private int programStart;
        private int endOfProgram;
        private int programStep1;
        private int toolInfo1;
        private int unit;
        private int yearCalibrationTime;
        private int monthCalibrationTime;
        private int dayCalibrationTime;
        private int hourCalibrationTime;
        private int minuteCalibrationTime;

        private string screwdriverIDCode = "SMT0121070001A";

        public void showmethemagic()
        {
            Console.WriteLine(CMD.CMD0);
            Console.WriteLine(CMD.CMD0.ToString());
        }
        
        /*PROPERTIES*/
        private string tempBuffer;
        private SerialPort serialPort = new SerialPort();
        private String connectionString = ConfigurationManager.ConnectionStrings["think"].ConnectionString;
        private string temporalListen = "";
        private string controllerIDCode = "2106001A";
        /// <summary>Mode options:<para>0: ADV, 1: STD, 2: ALI, 3: SET</para></summary>
        //private Mode mode = Mode.STD;
        private int job;
        private int jobSequence;
        private int selectScrewDriver = 1;
        private int tighteningProgram;
        private int deviceType = 4;
        private string controllerVersion = "1.017";
        private string screwdriverVersion = "1.15";
        private int screwdriverStatus = 0;
        private ScrewdriverStatus screwdriverStatus108 = CESATAutomationDevelop.ScrewdriverStatus.DisableBoth;
        private char nsasstatus = '0';
        private int instructionNumber = 1;
        /// <summary>DeviceName options:<para>0: AMS, 1: DAS</para><para>(Default is 0 for RS232 commands)</para></summary>
        private int deviceID = 1;
        private string deviceSerial = "";
        private string toolSerial = "";
        private int deviceName = 0;
        private int totalScrews = 0;
        //private int remainingScrews = 0;
        private Unused unused = CESATAutomationDevelop.Unused.Default;

        private int tighteningStep = 1;
        private string stepName = "";
        private int speed;
        private TargetCondition targetCondition = TargetCondition.Thread;
        private float targetThread = 0;
        private float targetTorque = 0;
        private Direction direction = Direction.CW;
        private float delayTime = 0;
        private float upperThreadLimit = 0;
        private float lowerThreadLimit = 0;
        private float upperTorqueLimit = 0;
        private float lowerTorqueLimit = 0;
        
        #region Controller default configurations
        //private TorqueUnit torqueUnit = TorqueUnit.Lbin;
        //private GateMode gateMode = GateMode.Off;
        private OkAllSignal okAllSignal = OkAllSignal.Each;
        //private BatchMode batchMode = BatchMode.Increase;
        private InternetSettings internetSettings = InternetSettings.RS232;
        private BuzzerMode buzzerMode = BuzzerMode.On;
        private Language language = Language.English;
        private LedMode ledMode = LedMode.Off;
        /// <summary>toolStartMode options: 0:Both 1:Lever 2:Push</summary>
        private StartMode startMode = StartMode.Lever;
        /// <summary>barcodeEnable options: 0:ON 1:OFF (default)</summary>
        private BarcodeEnable barcodeEnable = BarcodeEnable.Off;
        /// <summary>startSignalMode options: 0:Motor (default) 1:Trigger. Only from V1.009</summary>
        private StartSignalMode startSignalMode = StartSignalMode.Trigger;
        #endregion
        private Controller sMTC1Controller;
        public EAACTDSRS232(Controller sMTC1Controller)
        {
            this.sMTC1Controller = sMTC1Controller;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(Port_Listener);
        }
        /*METHODS*/
        private void Port_Listener(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort.IsOpen) return; // If the com port has been closed, do nothing
            tempBuffer += serialPort.ReadExisting(); // Read all the data waiting in the buffer
            var regex = @"{.*}";
            var complete = Regex.Match(tempBuffer, regex, RegexOptions.None);
            if (complete.Success) // If pattern not match, wait for the line ending pattern to proccess
            {
                var data = Regex.Match(tempBuffer, @"(?:[^{}]+)", RegexOptions.None);
                Data_Listener(data.Value);
                tempBuffer = "";
            }
        }
        internal void Data_Listener(string data)
        {
            if (TemporalListen != data)
            {
                TemporalListen = data;
                string[] parameters = data.Split(',');
                Debug.WriteLine(data);
                switch (parameters[0])
                {
                    case "REQ100": this.REQ100(parameters); break;
                    case "DATA100": this.DATA100(parameters); break;
                    case "DATA101": this.DATA101(parameters); break;
                    case "ANS104": this.ANS104(parameters); break;
                    case "ANS108": this.ANS108(parameters); break;
                    default: break;
                }
            }
        }
        public void OpenPort(string portName)
        {
            //bool error = false;
            // If the port is open, close it.
            if (serialPort.IsOpen) serialPort.Close();
            else
            {
                // Set the port's settings
                // BaudRate options: "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200"
                serialPort.BaudRate = int.Parse("115200");
                // DataBits options: "7", "8", "9"
                serialPort.DataBits = int.Parse("8");
                // StopBits options: "1", "2", "3"
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
                // Parity options: "None", "Even", "Odd"
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                // Retrive the COM options later #TODO
                serialPort.PortName = portName;
                try
                {
                    serialPort.Open();
                }
                catch (UnauthorizedAccessException e) { sMTC1Controller.ShowMessage(e.Message, "UnauthorizedAccessException"); }
                catch (IOException e) { sMTC1Controller.ShowMessage(e.Message, "IOException"); }
                catch (ArgumentException e) { sMTC1Controller.ShowMessage(e.Message, "ArgumentException"); }
            }
        }
        public void ClosePort()
        {
            serialPort.Close();
        }
        public void Write(string data)
        {
            if(serialPort.IsOpen)
            {
                serialPort.Write(data);
            }
            else
            {
                sMTC1Controller.OpenPortFirst();
            }
        }
        private void REQ100(string[] parameters)
        {
            DeviceID = Int32.Parse(parameters[11]);
            ScrewdriverIDCode = parameters[12];
            ControllerIDCode = parameters[13];
            //GateMode = (GateMode) Int32.Parse(parameters[14]);
            Job = Int32.Parse(parameters[15]);
            JobSequence = Int32.Parse(parameters[16]);
            SelectScrewDriver = Int32.Parse(parameters[18]);
            TighteningProgram = Int32.Parse(parameters[19]);
            DeviceType = Int32.Parse(parameters[20]);
            ScrewdriverStatus = Int32.Parse(parameters[21]);
            ControllerVersion = parameters[22];
            ScrewdriverVersion = parameters[23];
            ScrewdriverStatus = Int32.Parse(parameters[24]);
            var left = Regex.Match(parameters[25], @".*/", RegexOptions.None);
            var right = Regex.Match(parameters[25], @"/.*", RegexOptions.None);
            //TotalScrews = Int32.Parse(left.Value.Substring(0, left.Value.Length - 1));
            //RemainingScrews = Int32.Parse(left.Value.Substring(1));
            sMTC1Controller.UpdateUi();
            //Write(CMD100());
        }
        public void CMD100()
        {
            Time time = new Time();
            string command = String.Format("CMD{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},", "100", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, DeviceName, InstructionNumber);
            Console.WriteLine(command);
            Write("{" + command + "}");
        }
        /// <summary>
        /// Controller configuration settings command.
        /// </summary>
        public void CMD103()
        {
            /*
            Time time = new Time();
            string command = String.Format("CMD103" + stringCommandHelper(24),time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, DeviceName, deviceID, (int)TorqueUnit, (int)GateMode, (int)Mode, (int)OkAllSignal, (int)BatchMode, (int)InternetSettings, (int)BuzzerMode, (int)Language, (int)Unused, (int)LedMode, (int)StartMode, (int)BarcodeEnable, (int)StartSignalMode, InstructionNumber);
            Console.WriteLine(command);
            Write("{" + command + "}");
             */
        }
        public void CMD121()
        {
            TighteningStep = 250;
            StepName = "test";
            Speed = 1600;
            TargetCondition = TargetCondition.Thread;
            TargetThread = 5;
            UpperThreadLimit = 6;
            LowerThreadLimit = 4;
            TargetTorque = 5;
            UpperTorqueLimit = 6;
            LowerTorqueLimit = 4;
            Direction = Direction.CW;
            DelayTime = (float)0.2;
            Time time = new Time();
            string command = String.Format("CMD121"+stringCommandHelper(28),time.Year,time.Month,time.Day,time.Hour,time.Minute,time.Second,time.CheckSum,time.KeyCode,DeviceName,TighteningStep,StepName,Speed,(int)TargetCondition,(int)Unused,TargetThread,TargetTorque,(int)Direction,DelayTime,UpperThreadLimit, LowerThreadLimit,UpperTorqueLimit, LowerTorqueLimit,(int)Unused, (int)Unused, (int)Unused, (int)Unused, (int)Unused,InstructionNumber);
            Task.Delay(3500).ContinueWith((task) => {
                Console.WriteLine(command);
                Write("{" + command + "}");
            });
        }
        private string stringCommandHelper(int no)
        {
            string s = ",";
            for(int x = 0; x<no; x++)
            {
                s += "{" + x + "},";
            }
            return s;
        }
        public void CMD104(int Job, int JobSequence)
        {
            Time time = new Time();
            string command = "{" + String.Format("CMD{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},",
                "104",
                time.Year, time.Month, time.Day, time.Hour, time.Minute,
                time.Second, time.CheckSum, time.KeyCode, DeviceName,
                Job, JobSequence, InstructionNumber) + "}";
            Write(command);
        }
        private string CMD108String()
        {
            Time time = new Time();
            return String.Format("CMD108" + stringCommandHelper(10), time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, 1, InstructionNumber);
        }
        public void CMD108()
        {
            Time time = new Time();
            string command = CMD108String();
            Console.WriteLine(command);
            Write("{" + command + "}");
        }
        public void CMD108Delayed()
        {
            Time time = new Time();
            string command = CMD108String();
            Task.Delay(1000).ContinueWith((task) => {
                Console.WriteLine(command);
                Write("{" + command + "}");
            });
        }
        private void ANS108(string[] parameters)
        {
            BarcodeEnable = (BarcodeEnable)Int32.Parse(parameters[9]);
            //BatchMode = (BatchMode)Int32.Parse(parameters[10]);
            DeviceID = Int32.Parse(parameters[11]);
            //TorqueUnit = (TorqueUnit)Int32.Parse(parameters[12]);
            //GateMode = (GateMode)Int32.Parse(parameters[13]);
            //Mode = (Mode)Int32.Parse(parameters[14]);
            StartSignalMode = (StartSignalMode)Int32.Parse(parameters[15]);
            ScrewdriverStatus108 = (ScrewdriverStatus)Int32.Parse(parameters[17]);
            OkAllSignal = (OkAllSignal)Int32.Parse(parameters[19]);
            ScrewdriverIDCode = parameters[20];
            ControllerIDCode = parameters[21];
            InternetSettings = (InternetSettings)Int32.Parse(parameters[22]);
            BuzzerMode = (BuzzerMode)Int32.Parse(parameters[23]);
            Language = (Language)Int32.Parse(parameters[24]);
            LedMode = (LedMode)Int32.Parse(parameters[26]);
            StartMode = (StartMode)Int32.Parse(parameters[27]);
            InstructionNumber = Int32.Parse(parameters[28]);
            sMTC1Controller.UpdateSettings();
        }
        /*
        public string REQ100Out(string DeviceID, string Job, string JobSequence, string TighteningProgram, string RemainingScrews, string TotalScrews)
        {
            Time time = new Time();
            return "{" + string.Format("REQ{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},", "104", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, Unused, Unused, DeviceID, ScrewdriverIDCode, ControllerIDCode, Mode, Unused, Job, JobSequence, SelectScrewDriver, TighteningProgram, DeviceType, ScrewdriverStatus, ControllerVersion, ScrewdriverVersion, Nsasstatus, string.Format("{0}/{1}", RemainingScrews, TotalScrews), InstructionNumber) + "}";
        }
         */
        private async void DATA100(string[] parameters)
        {
            var query = String.Format("INSERT INTO [CESAT].[dbo].[TighteningData] ([Date],[IdSerie],[DeviceID],[ScrewSerial],[DeviceSerial],[Job],[Js],[Ts],[ProgramName],[TorqueUnit],[FasteningTimeMs],[FasteningThread],[RemainingScrews],[TotalScrews],[FasteningStatus],[NSAS]) VALUES (GETDATE(),{14},{0},'{1}','{2}',{3},{4},{5},'{6}',{7},{8},{9},{10},{11},'{12}',{13})", parameters[10], parameters[11], parameters[12], parameters[14], parameters[15], parameters[16], parameters[17], parameters[20], parameters[21], parameters[22], Int32.Parse(parameters[23].Substring(0, 2)), Int32.Parse(parameters[23].Substring(3)), parameters[25], parameters[26], sMTC1Controller.getIDSerie());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
            }
        }
        private void DATA101(string[] parameters)
        {
            TemporalListen = "";
            sMTC1Controller.updateTorque(parameters[1]);
        }
        private void ANS104(string[] parameters)
        {
            /*
             * ANS104: Reply Execute Specific Job
                str1	104	Command code
                str2	1~9999	Year
                str3	1~12	Month
                str4	1~31	Day
                str5	0~23	Hour(24 hours)
                str6	0~59	Minute
                str7	0~59	Second
                str8	2 Byte	YEAR+MONTH+DAY+HOUR+MINUTE+SECOND = Check Sum
                str9	2 Byte	Check Sum+ Safe Data(5438)=KEY Code
                str10	20 Bytes	Screwdriver identification code
                str11	20 Bytes	Controller identification code
                str12	1~255	Instruction number
                str13	0~1	Command setting status: 1: correct; 0: error
             */
            sMTC1Controller.JobChanged(Int32.Parse(parameters[12]) == 1);
        }
        /*GET AND SET*/
        public bool IsOpen { get => serialPort.IsOpen; }
        public int DeviceID { get => deviceID; set => deviceID = value; }
        public string TemporalListen { get => temporalListen; set => temporalListen = value; }
        public string ScrewdriverIDCode { get => screwdriverIDCode; set => screwdriverIDCode = value; }
        public string ControllerIDCode { get => controllerIDCode; set => controllerIDCode = value; }
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
        public string DeviceSerial { get => deviceSerial; set => deviceSerial = value; }
        public string ToolSerial { get => toolSerial; set => toolSerial = value; }
        internal Language Language { get => language; set => language = value; }
        internal OkAllSignal OkAllSignal { get => okAllSignal; set => okAllSignal = value; }
        //internal BatchMode BatchMode { get => batchMode; set => batchMode = value; }
        //internal TorqueUnit TorqueUnit { get => torqueUnit; set => torqueUnit = value; }
        //internal GateMode GateMode { get => gateMode; set => gateMode = value; }
        internal BuzzerMode BuzzerMode { get => buzzerMode; set => buzzerMode = value; }
        internal LedMode LedMode { get => ledMode; set => ledMode = value; }
        internal StartMode StartMode { get => startMode; set => startMode = value; }
        internal BarcodeEnable BarcodeEnable { get => barcodeEnable; set => barcodeEnable = value; }
        internal StartSignalMode StartSignalMode { get => startSignalMode; set => startSignalMode = value; }
        //internal Mode Mode { get => mode; set => mode = value; }
        internal Unused Unused { get => unused; set => unused = value; }
        internal InternetSettings InternetSettings { get => internetSettings; set => internetSettings = value; }
        internal ScrewdriverStatus ScrewdriverStatus108 { get => screwdriverStatus108; set => screwdriverStatus108 = value; }
        public int TighteningStep { get => tighteningStep; set => tighteningStep = value; }
        public string StepName { get => stepName; set => stepName = value; }
        public int Speed { get => speed; set => speed = value; }
        internal TargetCondition TargetCondition { get => targetCondition; set => targetCondition = value; }
        public float TargetThread { get => targetThread; set => targetThread = value; }
        public float TargetTorque { get => targetTorque; set => targetTorque = value; }
        internal Direction Direction { get => direction; set => direction = value; }
        public float DelayTime { get => delayTime; set => delayTime = value; }
        public float UpperThreadLimit { get => upperThreadLimit; set => upperThreadLimit = value; }
        public float LowerThreadLimit { get => lowerThreadLimit; set => lowerThreadLimit = value; }
        public float UpperTorqueLimit { get => upperTorqueLimit; set => upperTorqueLimit = value; }
        public float LowerTorqueLimit { get => lowerTorqueLimit; set => lowerTorqueLimit = value; }
    }
}
