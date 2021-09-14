using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektPong
{
    public partial class FormMain : Form
    {
        public Hra HerniInstance { get; set; }

        public FormMain()
        {
            InitializeComponent();
            HerniInstance = new Hra(pictureBox.Height, pictureBox.Width);
            
        }
            

        private void FormMain_Load(object sender, EventArgs e)
        {
            HerniInstance.Spust();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            HerniInstance.Vykresli(e.Graphics, timerFrame.Interval / 1000.0);
        }

        private void TimerFrame_Tick(object sender, EventArgs e)
        {
            if (HerniInstance.JeSpustena)
                pictureBox.Refresh();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            HerniInstance.KlavesaStisknuta(e.KeyCode);
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            HerniInstance.KlavesaPustena(e.KeyCode);
        }
        
        
    }
}
