using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CESATAutomationDevelop
{
    #region ENUMS
    enum CMD
    {
        [Description("Host Respond Status")] CMD100,
        [Description("Controller Configuration Setting")] CMD103,
        [Description("Execute Specific Job")] CMD104,
        [Description("Loading Controller Configuration Setting")] CMD108,
        [Description("Loading Screwdriver Status")] CMD116,
        [Description("TS Parameter Setting")] CMD121,
        [Description("TP Parameter Setting")] CMD122,
        [Description("Job Parameter Setting")] CMD123,
        [Description("Loading TS Parameter Setting")] CMD124,
        [Description("Barcode Setting")] CMD126,
        [Description("Tool Control Commands")] CMD151
    }
    enum ANS
    {
        [Description("Reply Controller Configuration Setting")] ANS103,
        [Description("Reply Execute Specific Job")] ANS104,
        [Description("Reply Loading Controller Configuration Setting")] ANS108,
        [Description("Reply Loading Screwdriver Status")] ANS116,
        [Description("Loading Screwdriver Status")] ANS121,
        [Description("Reply TP Parameter Setting")] ANS122,
        [Description("Reply Job Parameter Setting")] ANS123,
        [Description("Reply CMD124 Parameter Setting")] ANS124,
        [Description("Reply Barcode Setting")] ANS126,
        [Description("Reply Tool Control Commands")] ANS151
    }
    enum REQ
    {
        [Description("Device Status")] REQ100,
        [Description("Barcode Data")] REQ101
    }
    enum DATA
    {
        [Description("Tightening Data")] DATA100,
        [Description("Torque Curve Data")] DATA101
    }
    #endregion
    public class SmtC1
    {
        #region PROPERTIES
        private string screwdriverIDCode = "SMT0121070001A";
        private string controllerIDCode = "2106001A";
        /// <summary>Mode options:<para>0: ADV, 1: STD, 2: ALI, 3: SET</para></summary>
        private Mode mode = Mode.STD;
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
        private int remainingScrews = 0;
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
        private string torque;
        private TorqueUnit torqueUnit = TorqueUnit.Lbin;
        private GateMode gateMode = GateMode.Off;
        private OkAllSignal okAllSignal = OkAllSignal.Each;
        private BatchMode batchMode = BatchMode.Increase;
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
        private int firstStep;
        private int secondStep;
        private int thirdStep;
        private int fourthStep;
        private int fifthStep;
        private float okAllAlarmTime;
        private float okAlarmTime;
        private OkAllStop okAllStop = OkAllStop.Off;
        private int nsNgStop;
        private int[] tigtheningProgram = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] tighteningRepeat = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int settingButtonTorque;
        private Select select;
        private int tsTpJob;
        private ControllerState controllerState;
        private ScrewdriverMode screwdriverMode;
        #endregion

        #region METHODS

        #region CMD
        public string CMD100()
        {
            Time time = new Time();
            string command = String.Format("CMD{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},", "100", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, DeviceName, InstructionNumber);
            Console.WriteLine(command);
            return "{" + command + "}";
        }
        public string CMD103()
        {
            Time time = new Time();
            string command = String.Format("CMD103" + StringCommandHelper(24), time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, DeviceName, deviceID, (int)TorqueUnit, (int)GateMode, (int)Mode, (int)OkAllSignal, (int)BatchMode, (int)InternetSettings, (int)BuzzerMode, (int)Language, (int)Unused, (int)LedMode, (int)StartMode, (int)BarcodeEnable, (int)StartSignalMode, InstructionNumber);
            Console.WriteLine(command);
            return "{" + command + "}";
        }
        public string CMD104()
        {
            Time time = new Time();
            string command = "{" + String.Format("CMD{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},",
                "104",
                time.Year, time.Month, time.Day, time.Hour, time.Minute,
                time.Second, time.CheckSum, time.KeyCode, DeviceName,
                Job, JobSequence, InstructionNumber) + "}";
            return command;
        }
        public string CMD108()
        {
            Time time = new Time();
            string command = String.Format("CMD108" + StringCommandHelper(10), time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, 1, InstructionNumber);
            return "{" + command + "}";
        }
        public string CMD116()
        {
            Time t = new Time();
            string command = String.Format(StringCommandHelper(11),CMD.CMD116,t.Year,t.Month,t.Day,t.Hour,t.Minute,t.Second,t.CheckSum,t.KeyCode,DeviceName,InstructionNumber);
            return "{" + command + "}";
        }
        public string CMD121()
        {
            /*
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
             */
            Time time = new Time();
            string command = String.Format("CMD121" + StringCommandHelper(28), time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, DeviceName, TighteningStep, StepName, Speed, (int)TargetCondition, (int)Unused, TargetThread, TargetTorque, (int)Direction, DelayTime, UpperThreadLimit, LowerThreadLimit, UpperTorqueLimit, LowerTorqueLimit, (int)Unused, (int)Unused, (int)Unused, (int)Unused, (int)Unused, InstructionNumber);
            return "{" + command + "}";
        }
        public string CMD122()
        {
            Time t = new Time();
            string command = String.Format(StringCommandHelper(26),CMD.CMD122,t.Year,t.Month,t.Day,t.Hour,t.Minute,t.Second,t.CheckSum,t.KeyCode,DeviceName,TighteningProgram,StepName,Unused,FirstStep,SecondStep,ThirdStep,FifthStep,OkAllAlarmTime,OkAlarmTime,(int)OkAllStop,NsNgStop,Unused,Unused,Unused,InstructionNumber);
            return "{" + command + "}";
        }
        public string CMD123()
        {
            Time t = new Time();
            string command = String.Format(StringCommandHelper(18),CMD.CMD123,t.Year,t.Month,t.Day,t.Hour,t.Minute,t.Second,t.CheckSum,t.KeyCode,DeviceName,Job,0,String.Join(",",TigtheningProgram), String.Join(",", TighteningRepeat),(int)Direction,SettingButtonTorque,Speed,InstructionNumber);
            return "{" + command + "}";
        }
        public string CMD124()
        {
            Time t = new Time();
            string command = String.Format(StringCommandHelper(13), CMD.CMD124, t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second, t.CheckSum, t.KeyCode, DeviceName, Select, TsTpJob, InstructionNumber);
            return "{" + command + "}";
        }
        public string CMD126()
        {
            int determineInitialPointSection = 1, determineSectionSize = 1;
            Time t = new Time();
            string command = String.Format(StringCommandHelper(13), CMD.CMD126, t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second, t.CheckSum, t.KeyCode, DeviceName, Job, determineInitialPointSection, determineSectionSize, barcodeEnable, instructionNumber);
            return "{" + command + "}";
        }
        public string CMD151()
        {
            Time t = new Time();
            string command = String.Format(StringCommandHelper(14), CMD.CMD151, t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second, t.CheckSum, t.KeyCode, DeviceName, (int)ControllerState, (int)ScrewdriverMode, Unused, InstructionNumber);
            return "{" + command + "}";
        }
        #endregion

        #region ANS
        private void ANS108(string[] parameters)
        {
            BarcodeEnable = (BarcodeEnable)Int32.Parse(parameters[9]);
            BatchMode = (BatchMode)Int32.Parse(parameters[10]);
            DeviceID = Int32.Parse(parameters[11]);
            TorqueUnit = (TorqueUnit)Int32.Parse(parameters[12]);
            GateMode = (GateMode)Int32.Parse(parameters[13]);
            Mode = (Mode)Int32.Parse(parameters[14]);
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
        }
        #endregion

        #region REQ
        private void REQ100(string[] parameters)
        {
            DeviceID = Int32.Parse(parameters[11]);
            ScrewdriverIDCode = parameters[12];
            ControllerIDCode = parameters[13];
            GateMode = (GateMode)Int32.Parse(parameters[14]);
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
            //Write(CMD100());
        }
        #endregion

        #region DATA
        private void DATA101(string[] parameters)
        {
            //TemporalListen = "";
            torque = parameters[1];
            //sMTC1Controller.updateTorque(parameters[1]);
        }
        #endregion

        public string Listener(string commandString)
        {
            Console.WriteLine("Listener:"+commandString);
            return String.Empty;
        }
        private string StringCommandHelper(int no)
        {
            string s = ",";
            for (int x = 0; x < no; x++)
            {
                s += "{" + x + "},";
            }
            return s;
        }
        #endregion

        #region GETTERS AND SETTERS
        public int DeviceID { get => deviceID; set => deviceID = value; }
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
        internal BatchMode BatchMode { get => batchMode; set => batchMode = value; }
        internal TorqueUnit TorqueUnit { get => torqueUnit; set => torqueUnit = value; }
        internal GateMode GateMode { get => gateMode; set => gateMode = value; }
        internal BuzzerMode BuzzerMode { get => buzzerMode; set => buzzerMode = value; }
        internal LedMode LedMode { get => ledMode; set => ledMode = value; }
        internal StartMode StartMode { get => startMode; set => startMode = value; }
        internal BarcodeEnable BarcodeEnable { get => barcodeEnable; set => barcodeEnable = value; }
        internal StartSignalMode StartSignalMode { get => startSignalMode; set => startSignalMode = value; }
        internal Mode Mode { get => mode; set => mode = value; }
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
        public string Torque { get => torque; set => torque = value; }
        public int FirstStep { get => firstStep; set => firstStep = value; }
        public int SecondStep { get => secondStep; set => secondStep = value; }
        public int ThirdStep { get => thirdStep; set => thirdStep = value; }
        public int FourthStep { get => fourthStep; set => fourthStep = value; }
        public int FifthStep { get => fifthStep; set => fifthStep = value; }
        public float OkAllAlarmTime { get => okAllAlarmTime; set => okAllAlarmTime = value; }
        public float OkAlarmTime { get => okAlarmTime; set => okAlarmTime = value; }
        internal OkAllStop OkAllStop { get => okAllStop; set => okAllStop = value; }
        public int NsNgStop { get => nsNgStop; set => nsNgStop = value; }
        public int[] TigtheningProgram { get => tigtheningProgram; set => tigtheningProgram = value; }
        public int[] TighteningRepeat { get => tighteningRepeat; set => tighteningRepeat = value; }
        public int SettingButtonTorque { get => settingButtonTorque; set => settingButtonTorque = value; }
        internal Select Select { get => select; set => select = value; }
        public int TsTpJob { get => tsTpJob; set => tsTpJob = value; }
        private ScrewdriverMode ScrewdriverMode1 { get => ScrewdriverMode; set => ScrewdriverMode = value; }
        internal ControllerState ControllerState { get => controllerState; set => controllerState = value; }
        internal ScrewdriverMode ScrewdriverMode { get => screwdriverMode; set => screwdriverMode = value; }
        #endregion
    }
}