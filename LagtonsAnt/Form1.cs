using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LagtonsAnt
{
    public partial class Title : Form
    {
        public Title()
        {
            InitializeComponent();
            SimulationSpeed.SelectedIndex = 0;
            SolidWalls.SelectedIndex = 0;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            SimulationWindow Simulation = new SimulationWindow(Convert.ToInt32(GridSizeXValue.Text), Convert.ToInt32(GridSizeYValue.Text), Convert.ToInt32(StartLocationXValue.Text), Convert.ToInt32(StartLocationYValue.Text), Convert.ToBoolean(SolidWalls.SelectedIndex), Convert.ToInt32(SimulationLength.Text),Convert.ToInt32(SimulationSpeed.Text));
            Simulation.Show();
        }
    }
}
