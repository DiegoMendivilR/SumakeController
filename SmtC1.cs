using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class SmtC1 : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region METHODS
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private string StringCommandHelper(int no)
        {
            string s = ",";
            for (int x = 0; x < no; x++)
            {
                s += "{" + x + "},";
            }
            return s;
        }
        #region CMD
        public string CMD100()
        {
            Time time = new Time();
            string command = String.Format("CMD{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},", "100", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.CheckSum, time.KeyCode, DeviceName, InstructionNumber);
            //Console.WriteLine("{" + command + "}");
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
            string[] parameters = commandString.Split(',');
            switch(parameters[0])
            {
                case nameof(REQ.REQ100): REQ100(parameters); break;
                default: break;
            }
            return String.Empty;
        }
        #endregion
        #region GETTERS AND SETTERS
        public int DeviceID { get => deviceID; set { if(value != deviceID) { deviceID = value; NotifyPropertyChanged(); } } }
        public string ScrewdriverIDCode { get => screwdriverIDCode; set { if (value != screwdriverIDCode) { screwdriverIDCode = value; NotifyPropertyChanged(); } } }
        public string ControllerIDCode { get => controllerIDCode; set { if (value != controllerIDCode) { controllerIDCode = value; NotifyPropertyChanged(); } } }
        public int Job { get => job; set { if (value != job) { job = value; NotifyPropertyChanged(); } } }
        public int JobSequence { get => jobSequence; set { if (value != jobSequence) { jobSequence = value; NotifyPropertyChanged(); } } }
        public int SelectScrewDriver { get => selectScrewDriver; set { if (value != selectScrewDriver) { selectScrewDriver = value; NotifyPropertyChanged(); } } }
        public int TighteningProgram { get => tighteningProgram; set { if (value != tighteningProgram) { tighteningProgram = value; NotifyPropertyChanged(); } } }
        public int DeviceType { get => deviceType; set { if (value != deviceType) { deviceType = value; NotifyPropertyChanged(); } } }
        public string ControllerVersion { get => controllerVersion; set { if (value != controllerVersion) { controllerVersion = value; NotifyPropertyChanged(); } } }
        public string ScrewdriverVersion { get => screwdriverVersion; set { if (value != screwdriverVersion) { screwdriverVersion = value; NotifyPropertyChanged(); } } }
        public int ScrewdriverStatus { get => screwdriverStatus; set { if (value != screwdriverStatus) { screwdriverStatus = value; NotifyPropertyChanged(); } } }
        public char Nsasstatus { get => nsasstatus; set { if (value != nsasstatus) { nsasstatus = value; NotifyPropertyChanged(); } } }
        public int InstructionNumber { get => instructionNumber; set { if (value != instructionNumber) { instructionNumber = value; NotifyPropertyChanged(); } } }
        public int DeviceName { get => deviceName; set { if (value != deviceName) { deviceName = value; NotifyPropertyChanged(); } } }
        public int TotalScrews { get => totalScrews; set { if (value != totalScrews) { totalScrews = value; NotifyPropertyChanged(); } } }
        public int RemainingScrews { get => remainingScrews; set { if (value != remainingScrews) { remainingScrews = value; NotifyPropertyChanged(); } } }
        public string DeviceSerial { get => deviceSerial; set { if (value != deviceSerial) { deviceSerial = value; NotifyPropertyChanged(); } } }
        public string ToolSerial { get => toolSerial; set { if (value != toolSerial) { toolSerial = value; NotifyPropertyChanged(); } } }
        internal Language Language { get => language; set { if (value != language) { language = value; NotifyPropertyChanged(); } } }
        internal OkAllSignal OkAllSignal { get => okAllSignal; set { if (value != okAllSignal) { okAllSignal = value; NotifyPropertyChanged(); } } }
        internal BatchMode BatchMode { get => batchMode; set { if (value != batchMode) { batchMode = value; NotifyPropertyChanged(); } } }
        internal TorqueUnit TorqueUnit { get => torqueUnit; set { if (value != torqueUnit) { torqueUnit = value; NotifyPropertyChanged(); } } }
        internal GateMode GateMode { get => gateMode; set { if (value != gateMode) { gateMode = value; NotifyPropertyChanged(); } } }
        internal BuzzerMode BuzzerMode { get => buzzerMode; set { if (value != buzzerMode) { buzzerMode = value; NotifyPropertyChanged(); } } }
        internal LedMode LedMode { get => ledMode; set { if (value != ledMode) { ledMode = value; NotifyPropertyChanged(); } } }
        internal StartMode StartMode { get => startMode; set { if (value != startMode) { startMode = value; NotifyPropertyChanged(); } } }
        internal BarcodeEnable BarcodeEnable { get => barcodeEnable; set { if (value != barcodeEnable) { barcodeEnable = value; NotifyPropertyChanged(); } } }
        internal StartSignalMode StartSignalMode { get => startSignalMode; set { if (value != startSignalMode) { startSignalMode = value; NotifyPropertyChanged(); } } }
        internal Mode Mode { get => mode; set { if (value != mode) { mode = value; NotifyPropertyChanged(); } } }
        internal Unused Unused { get => unused; set { if (value != unused) { unused = value; NotifyPropertyChanged(); } } }
        internal InternetSettings InternetSettings { get => internetSettings; set { if (value != internetSettings) { internetSettings = value; NotifyPropertyChanged(); } } }
        internal ScrewdriverStatus ScrewdriverStatus108 { get => screwdriverStatus108; set { if (value != screwdriverStatus108) { screwdriverStatus108 = value; NotifyPropertyChanged(); } } }
        public int TighteningStep { get => tighteningStep; set { if (value != tighteningStep) { tighteningStep = value; NotifyPropertyChanged(); } } }
        public string StepName { get => stepName; set { if (value != stepName) { stepName = value; NotifyPropertyChanged(); } } }
        public int Speed { get => speed; set { if (value != speed) { speed = value; NotifyPropertyChanged(); } } }
        internal TargetCondition TargetCondition { get => targetCondition; set { if (value != targetCondition) { targetCondition = value; NotifyPropertyChanged(); } } }
        public float TargetThread { get => targetThread; set { if (value != targetThread) { targetThread = value; NotifyPropertyChanged(); } } }
        public float TargetTorque { get => targetTorque; set { if (value != targetTorque) { targetTorque = value; NotifyPropertyChanged(); } } }
        internal Direction Direction { get => direction; set { if (value != direction) { direction = value; NotifyPropertyChanged(); } } }
        public float DelayTime { get => delayTime; set { if (value != delayTime) { delayTime = value; NotifyPropertyChanged(); } } }
        public float UpperThreadLimit { get => upperThreadLimit; set { if (value != upperThreadLimit) { upperThreadLimit = value; NotifyPropertyChanged(); } } }
        public float LowerThreadLimit { get => lowerThreadLimit; set { if (value != lowerThreadLimit) { lowerThreadLimit = value; NotifyPropertyChanged(); } } }
        public float UpperTorqueLimit { get => upperTorqueLimit; set { if (value != upperTorqueLimit) { upperTorqueLimit = value; NotifyPropertyChanged(); } } }
        public float LowerTorqueLimit { get => lowerTorqueLimit; set { if (value != lowerTorqueLimit) { lowerTorqueLimit = value; NotifyPropertyChanged(); } } }
        public string Torque { get => torque; set { if (value != torque) { torque = value; NotifyPropertyChanged(); } } }
        public int FirstStep { get => firstStep; set { if (value != firstStep) { firstStep = value; NotifyPropertyChanged(); } } }
        public int SecondStep { get => secondStep; set { if (value != secondStep) { secondStep = value; NotifyPropertyChanged(); } } }
        public int ThirdStep { get => thirdStep; set { if (value != thirdStep) { thirdStep = value; NotifyPropertyChanged(); } } }
        public int FourthStep { get => fourthStep; set { if (value != fourthStep) { fourthStep = value; NotifyPropertyChanged(); } } }
        public int FifthStep { get => fifthStep; set { if (value != fifthStep) { fifthStep = value; NotifyPropertyChanged(); } } }
        public float OkAllAlarmTime { get => okAllAlarmTime; set { if (value != okAllAlarmTime) { okAllAlarmTime = value; NotifyPropertyChanged(); } } }
        public float OkAlarmTime { get => okAlarmTime; set { if (value != okAlarmTime) { okAlarmTime = value; NotifyPropertyChanged(); } } }
        internal OkAllStop OkAllStop { get => okAllStop; set { if (value != okAllStop) { okAllStop = value; NotifyPropertyChanged(); } } }
        public int NsNgStop { get => nsNgStop; set { if (value != nsNgStop) { nsNgStop = value; NotifyPropertyChanged(); } } }
        public int[] TigtheningProgram { get => tigtheningProgram; set { if (value != tigtheningProgram) { tigtheningProgram = value; NotifyPropertyChanged(); } } }
        public int[] TighteningRepeat { get => tighteningRepeat; set { if (value != tighteningRepeat) { tighteningRepeat = value; NotifyPropertyChanged(); } } }
        public int SettingButtonTorque { get => settingButtonTorque; set { if (value != settingButtonTorque) { settingButtonTorque = value; NotifyPropertyChanged(); } } }
        internal Select Select { get => select; set { if (value != select) { select = value; NotifyPropertyChanged(); } } }
        public int TsTpJob { get => tsTpJob; set { if (value != tsTpJob) { tsTpJob = value; NotifyPropertyChanged(); } } }
        private ScrewdriverMode ScrewdriverMode { get => screwdriverMode; set { if (value != screwdriverMode) { screwdriverMode = value; NotifyPropertyChanged(); } } }
        internal ControllerState ControllerState { get => controllerState; set { if (value != controllerState) { controllerState = value; NotifyPropertyChanged(); } } }
        #endregion
    }
}