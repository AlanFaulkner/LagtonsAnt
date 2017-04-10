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
    public partial class SimulationWindow : Form
    {
        Lagtons_Ant Simulation;
        private List<PictureBox> GridWorldView = new List<PictureBox> { };
        private int CurrentItteration = 0;
        private int Itterations { get; set; } = 1000;
        private int Speed { get; set; } = 1000;
        private int NumberOfSquaresX { get; set; }
        private int NumberOfSquaresY { get; set; }

        public SimulationWindow(int X, int Y, int Sx, int Sy, bool SolidWalls,int SimulationLength, int SimulationSpeed)
        {
            InitializeComponent();
            NumberOfSquaresX = X;
            NumberOfSquaresY = Y;
            Speed /= SimulationSpeed*10;
            Itterations = SimulationLength;
            Simulation = new Lagtons_Ant(X, Y, Sx, Sy, SolidWalls);
        }
               
        private void Start_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            SimulationTimer.Enabled = true;
            SimulationTimer.Interval = Speed;
        }    

        // Drawing Functions

        private void SimulationWindow_Paint(object sender, PaintEventArgs e)
        {
            for (int Row = 0; Row < NumberOfSquaresY; Row++)
            {
                for (int Column = 0; Column < NumberOfSquaresX; Column++)
                {
                    if (Simulation.GridWorld[Row][Column] == 1) {
                        e.Graphics.FillRectangle(Brushes.Black, Column * (400 / NumberOfSquaresX), Row * (460 / NumberOfSquaresY) + 15, 400 / NumberOfSquaresX, 460 / NumberOfSquaresY);
                    }
                }
            }
        }

        // Not used - Chooses which ant image to display based on the current direction in Simulation class
        private void SelectCorrectAnt(PictureBox square)
        {
            switch (Simulation.CurrentDirection)
            {
                case (Lagtons_Ant.Direction.Up):
                    square.Image = Properties.Resources.AntUp;
                    break;

                case (Lagtons_Ant.Direction.Right):
                    square.Image = Properties.Resources.AntRight;
                    break;

                case (Lagtons_Ant.Direction.Down):
                    square.Image = Properties.Resources.AntDown;
                    break;

                case (Lagtons_Ant.Direction.Left):
                    square.Image = Properties.Resources.AntLeft;
                    break;
            }
        }

        private void SimulationTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentItteration < Itterations)
            {
                SimulationWindow.ActiveForm.Text = "Simulation Running...  Itteration: " + CurrentItteration;
                Simulation.MoveAnt();
                CurrentItteration++;
                Invalidate();
            }
            else
            {
                SimulationTimer.Enabled = false;
                SimulationWindow.ActiveForm.Text = "Simulation Complete!";
                CloseButton.Enabled = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
