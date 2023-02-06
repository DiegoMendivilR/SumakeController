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
    public partial class Simulation : Form
    {
        public event EventHandler Scanning;
        public event EventHandler StartSimulation;
        public Simulation()
        {
            InitializeComponent();
            txtInput.KeyUp += TxtInput_KeyPress;
        }
        private void TxtInput_KeyPress(object sender, EventArgs e) => Scanning?.Invoke(sender, e);
        private void ButtonStartSimulation(object sender, EventArgs e) => StartSimulation?.Invoke(sender, e);
    }
}
