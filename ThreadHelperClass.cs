using SumakeController.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SumakeController
{
    public class ThreadHelperClass
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);
        delegate void SetNumericUpDownCallback(Form f, Control ctrl, int value);
        delegate void SetEnableCallback(Form f, Control ctrl, bool enabled);
        public static void SetText(Form form, Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }
        public static void SetNumericUpDown(Form form, Control ctrl, int value)
        {
            if (ctrl.InvokeRequired)
            {
                SetNumericUpDownCallback d = new SetNumericUpDownCallback(SetNumericUpDown);
                form.Invoke(d, new object[] { form, ctrl, value });
            }
            else
            {
                ((NumericUpDown)ctrl).Value = value;
            }
        }
        public static void SetEnabled(Form form, Control ctrl, bool enabled)
        {
            if (ctrl.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(SetEnabled);
                form.Invoke(d, new object[] { form, ctrl, enabled });
            }
            else
            {
                ctrl.Enabled = enabled;
            }
        }
    }
}
