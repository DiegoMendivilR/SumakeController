using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumakeController
{
    public class Time
    {
        private int year;
        private int month;
        private int day;
        private int hour;
        private int minute;
        private int second;
        private int checkSum;
        private int keyCode;
        public Time()
        {
            this.year = DateTime.Now.Year;
            this.month = DateTime.Now.Month;
            this.day = DateTime.Now.Day;
            this.hour = DateTime.Now.Hour;
            this.minute = DateTime.Now.Minute;
            this.second = DateTime.Now.Second;
            this.checkSum = this.year + this.month + this.day + this.hour + this.minute + this.second;
            this.keyCode = checkSum + 5438;
        }
        public string Year { get { return year.ToString(); } }
        public string Month { get { return month.ToString("D2"); } }
        public string Day { get { return day.ToString("D2"); } }
        public string Hour { get { return hour.ToString("D2"); } }
        public string Minute { get { return minute.ToString("D2"); } }
        public string Second { get { return second.ToString("D2"); } }
        public string CheckSum { get { return checkSum.ToString(); } }
        public string KeyCode { get { return keyCode.ToString(); } }
    }
}
