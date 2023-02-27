using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CESATAutomationDevelop.Screens
{
    public partial class ChasisScrewing : Form
    {
        public event EventHandler OnTextBoxScan;
        public ChasisScrewing()
        {
            InitializeComponent();
            TextBox textBoxScan = new TextBox();
            textBoxScan.BackColor = SystemColors.Control;
            textBoxScan.BorderStyle = BorderStyle.FixedSingle;
            textBoxScan.Font = new Font("Lucida Sans Unicode", 14.25F);
            textBoxScan.TextAlign = HorizontalAlignment.Center;
            textBoxScan.KeyUp += TextBoxScan;
            Controls.Add(textBoxScan);
            BackColor = Color.BlueViolet;
            PictureBox pictureBox = new PictureBox();

        }
        private void TextBoxScan(object sender, EventArgs e) => OnTextBoxScan?.Invoke(sender, e);
    }
}
