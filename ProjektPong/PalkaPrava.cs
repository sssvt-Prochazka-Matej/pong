using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektPong
{
     public class PalkaPrava
     {
        public double PoziceX { get; set; }
        public double PoziceY { get; set; }

        public int Vyska { get; set; }
        public int Sirka { get; set; }

        public int RychlostY { get; set; }

        public PalkaPrava(double x, double y, int vyska, int sirka)
        {
            PoziceX = x;
            PoziceY = y;
            Vyska = vyska;
            Sirka = sirka;
        }

        public void LimitPrava(int vyska)
        {
            if (PoziceY >= vyska - 75)
            {
                PoziceY = vyska - 75;
            }
            if (PoziceY <= 0)
            {
                PoziceY = 0;
            }
        }

        public void Vykresli(Graphics grafickaPlocha)
        {
            Brush stetec = Brushes.Black;
            grafickaPlocha.FillRectangle(stetec, (float)PoziceX, (float)PoziceY, Sirka, Vyska);
        }

        public void Posun(double rozdilCasu)
        {

            PoziceY += (RychlostY * rozdilCasu);
        }
    }
}
