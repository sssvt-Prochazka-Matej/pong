using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektPong
{
    public class Hra
    {
        public bool JeSpustena { get; set; }

        public int Sirka { get; set; }
        public int Vyska { get; set; }

       


        public Micek HerniMicek { get; set; }
        public PalkaLeva PalkaL { get; set; }

        public FormMain FormM { get; set; }

        public PalkaPrava PalkaP { get; set; }

        public Hra(int vyska, int sirka)
        {
            Sirka = sirka;
            Vyska = vyska;
            JeSpustena = false;
            

            HerniMicek = null;
            PalkaL = null;
            PalkaP = null;
        }

        public void Spust()
        {
            PalkaP = new PalkaPrava(785, 5, 75, 10);
            PalkaL = new PalkaLeva(5, 5, 75, 10);
            HerniMicek = new Micek(100, 100, 150, 150);
            JeSpustena = true;
           
        }

        public void Vykresli(Graphics grafickaPlocha, double rozdilCasu)
        {
            if (!JeSpustena)
                return;

            HerniMicek.OdrazOdPalky(PalkaL,PalkaP);
            HerniMicek.OdrazOdSteny(Vyska, Sirka);
            HerniMicek.Posun(rozdilCasu);
            HerniMicek.Vykresli(grafickaPlocha);

            PalkaL.LimitLeva(Vyska);
            PalkaL.Posun(rozdilCasu);
            PalkaL.Vykresli(grafickaPlocha);

            PalkaP.LimitPrava(Vyska);
            PalkaP.Posun(rozdilCasu);
            PalkaP.Vykresli(grafickaPlocha);

            grafickaPlocha.DrawLine(Pens.Black, 0, 0, 800, 0);
            grafickaPlocha.DrawLine(Pens.Black, 0, 599, 800, 599);
            grafickaPlocha.DrawLine(Pens.Black, 400, 0, 400, 599);
        }
            

            


        public void KlavesaStisknuta(Keys klavesa)
        {
            
            if (klavesa == Keys.W)
            {
                PalkaL.RychlostY = -300;
            }
            else if (klavesa == Keys.S)
            {
                PalkaL.RychlostY = 300;
            }
            else if (klavesa == Keys.Up)
            {
                PalkaP.RychlostY = -300;
            }
            else if (klavesa == Keys.Down)
            {
                PalkaP.RychlostY = 300;
            }
        }

        public void KlavesaPustena(Keys klavesa)
        {
            
           if (klavesa == Keys.W)
            {
                PalkaL.RychlostY = 0;
            }
            else if (klavesa == Keys.S)
            {
                PalkaL.RychlostY = 0;
            }
           else if (klavesa == Keys.Up)
            {
                PalkaP.RychlostY = 0;
            }
            else if (klavesa == Keys.Down)
            {
                PalkaP.RychlostY = 0;
            }
        }
        
        
    } 
}
