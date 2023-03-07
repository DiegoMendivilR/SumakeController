using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CESATAutomationDevelop.Screens
{
    public partial class Monitoring : Form
    {
        RS232 serial;
        SmtC1 smt;
        public Monitoring(RS232 serial, SmtC1 smt)
        {
            this.serial = serial;
            this.smt = smt;
            InitializeComponent();
            comboPorts.DataSource = SerialPort.GetPortNames();
            btnOpenPort.BackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
            btnOpenPort.FlatAppearance.MouseDownBackColor = Theme.EatonBlue;
            btnOpenPort.FlatAppearance.MouseOverBackColor = Theme.EatonBlue;
            btnChangeJob.BackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
            btnChangeJob.FlatAppearance.MouseDownBackColor = Theme.EatonBlue;
            btnChangeJob.FlatAppearance.MouseOverBackColor = Theme.EatonBlue;
            foreach (Control control in panelScan.Controls)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            foreach (Control control in panelScan.Controls)
            {
                if(control is Label)
                {
                    ((Label)control).ForeColor = Theme.EatonBlue;
                }
            }
            foreach (Control control in panelInfo.Controls)
            {
                if (control is Label)
                {
                    ((Label)control).ForeColor = Theme.EatonBlue;
                }
            }
            foreach(Control control in panelInfo2.Controls)
            {
                if(control is Label)
                {
                    ((Label)control).ForeColor= Theme.EatonBlue;
                }
            }
        }
        public void SetTorque(string torque) => ThreadHelperClass.SetText(this, lblTorque, torque);
        internal void UpdateUi()
        {
            ThreadHelperClass.SetText(this, lblJob, smt.Job.ToString());
            ThreadHelperClass.SetText(this, lblJs, smt.JobSequence.ToString());
            ThreadHelperClass.SetText(this, lblTp, smt.TighteningProgram.ToString());
            ThreadHelperClass.SetText(this, lblScrewdriverIdCode, smt.ScrewdriverIDCode.ToString());
            ThreadHelperClass.SetText(this, lblScrewdriverStatus, smt.ScrewdriverStatus.ToString());
        }
        private async void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            var data = txtInput.Text;
            if (e.KeyChar == (char)13 && data.Length > 0)
            {
                /*
                JulianCalendar jCal = new JulianCalendar();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var query = String.Format("INSERT INTO [CESAT].[dbo].[Series] ([Serie],[Date],[Status]) VALUES ('{0}-{1}-'+(select trim(str(count(*)+1)) from cesat.dbo.Series where Serie like '{0}-{1}%'),GETDATE(),1) SELECT * from CESAT.dbo.Series where id = SCOPE_IDENTITY()", data, Math.Round(JulianDate.JD(DateTime.Now)));
                    //Debug.WriteLine(query);
                    SqlCommand command = new SqlCommand(query, connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            serie.Id = (int)reader["ID"];
                            serie.SerieString = (string)reader["Serie"];
                        }
                    }
                }
                lblLastScan.Text = serie.SerieString;
                */
            }
            await Task.Delay(1000).ContinueWith((task) => {
                ThreadHelperClass.SetText(this, txtInput, String.Empty);
            });
        }
        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            /*
            if (serial.IsOpen) serial.ClosePort();
            else serial.OpenPort(comboPorts.Text);
            if (serial.IsOpen) btnOpenPort.Text = "&Close Port";
            else btnOpenPort.Text = "&Open Port";
            if (serial.IsOpen) serial.CMD100();

            serial.CMD121();
             */
        }
        /// <summary>
        /// Changing Job and JobSequence for the Sumake.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeJob_Click(object sender, EventArgs e)
        {
            //serial.CMD104(Decimal.ToInt32(numJ.Value), Decimal.ToInt32(numJS.Value));
        }
    }
}
