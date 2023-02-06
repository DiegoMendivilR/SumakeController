using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CESATAutomationDevelop.Screens
{
    public partial class Simulation : Form, INotifyPropertyChanged
    {
        public event EventHandler Scanning;
        public event EventHandler StartSimulation;
        public event PropertyChangedEventHandler PropertyChanged;
        private bool simulationRunning;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool SimulationRunning { get => simulationRunning; set
            {
                if(value != simulationRunning)
                {
                    simulationRunning = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Simulation()
        {
            InitializeComponent();
            txtInput.KeyUp += TxtInput_KeyPress;
        }
        private void TxtInput_KeyPress(object sender, EventArgs e) => Scanning?.Invoke(sender, e);
        private void ButtonStartSimulation(object sender, EventArgs e) => StartSimulation?.Invoke(sender, e);

        public void SimulationImage(Image image)
        {
            panelImage.BackgroundImage = image;
            panelImage.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
