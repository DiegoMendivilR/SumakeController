using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESATAutomationDevelop
{
    internal class EaaCtds
    {
        #region ENUMS
        enum CMD
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
            [Description("READ FILTER PARAMETER")] CMD58,
            [Description("COMMAND THREAD FINDING STATUS")] CMD59,
            [Description("READ THREAD FINDING STATUS")] CMD60
        }
        enum ANS
        {
            [Description("REPLY PROGRAM PARAMETER STATUS")] ANS1,
            [Description("REPLY CONTROLLER PARAMETER STATUS")] ANS2,
            [Description("REPLY STD MODE ALL SEQUENCE")] ANS4,
            [Description("REPLY STD MODE CURRENT SEQUENCE")] ANS6,
            [Description("REPLY SCREWDRIVER STATUS")] ANS7,
            [Description("REPLY CONTROLLER PASSWORD")] ANS54,
            [Description("REPLY FILTER PARAMETER")] ANS58,
            [Description("REPLY THREAD FINDING STATUS")] ANS60,
        }
        enum REQ
        {
            [Description("DEVICE STATUS")] REQ0,
            [Description("BARCODE DATA")] REQ1
        }
        enum DATA
        {
            [Description("TIGTENING DATA")] DATA0
        }
        enum EquipmentName { AMS, DAS }
        #endregion
        #region PROPERTIES
        private EquipmentName equipmentName = EquipmentName.AMS;
        private int unused = 0;
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
        private float setUpReShutOffTime;
        private float okAllAlarmTime;
        private float preFasteningTime;
        private float runReverseTime;
        private float reverseSuspendTime;
        private float autoReverseTime;
        private float nOkStop;
        private int okAllStop;
        private int screwCount;
        private float okSignalOutputTime;
        private int countThread;
        #endregion
        #region METHODS
        public string CMD0()
        {
            Time t = new Time();
            string command = String.Format(stringCommandHelper(15),CMD.CMD0,equipmentName,unused,unused,unused,unused,unused,t.Year,t.Month,t.Day,t.Hour,t.Minute,t.Second,t.CheckSum,t.ChkCode);
            return "{" + command + "}";
        }
        public string CMD2()
        {
            Time t = new Time();
            string command = String.Format(stringCommandHelper(35), CMD.CMD2, unused, unused, program, toolInfo, batchCount, highTorque, lowTorque, highThread, lowThread,highTime,lowTime,torqueOffset,gearRatio,slowStartSpeed,slowStartTime,setUpReShutOffTime,okAllAlarmTime,preFasteningTime,runReverseTime,reverseSuspendTime,autoReverseTime,nOkStop, okAllStop, screwCount,okSignalOutputTime,countThread,t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second, t.CheckSum, t.ChkCode);
            return "{" + command + "}";
        }
        private string stringCommandHelper(int no)
        {
            string s = ",";
            for (int x = 0; x < no; x++)
            {
                s += "{" + x + "},";
            }
            return s;
        }
        #endregion
    }
}
