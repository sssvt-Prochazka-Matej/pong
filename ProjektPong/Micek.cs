using System;
using System.Collections.Generic;
using System.Drawing;

namespace ProjektPong
{
    public class Micek
    {
        public double PoziceX { get; set; }
        public double PoziceY { get; set; }

        public double RychlostX { get; set; }
        public double RychlostY { get; set; }

        public double Prumer { get; set; }

        public int SkoreA { get; set; }
        public int SkoreB { get; set; }



        public Micek(double x, double y, double rychlostX = 0, double rychlostY = 0)
        {
            SkoreA = 0;
            SkoreB = 0;
            PoziceX = x;
            PoziceY = y;
            RychlostX = rychlostX;
            RychlostY = rychlostY;
            Prumer = 25;
        }

        public void OdrazOdSteny(int vyska, int sirka )
        {
            if(PoziceY + 25 >= vyska || PoziceY <= 0)
            {
                
                RychlostY *= -1;

            }
            if(PoziceX >= sirka)
            {
                SkoreA++;                                   //podani plus přičtení skore leva strana
                Podani();
                
            }
            if(PoziceX <= 0) 
            {
                SkoreB++;                                  //podani plus přičtení skore prava strana
                Podani();
                
            }
        }

           
        public void Podani()
        {
            PoziceX = 400 - 12.5;
            PoziceY = 300 - 12.5;
            RychlostX = 150;
            RychlostY = 150;

            Random randomS = new Random();
            int strana = randomS.Next(0, 1 + 1);
            
            if(strana == 0)
            {
                
            }
            else
            {
                RychlostX *= -1;
            }
            Random randomU = new Random();
            int uhel = randomU.Next(0, 1 + 1);
            if (uhel == 0)
            {

            }
            else
            {
                RychlostY *= -1;
            }
            
        }
        
        public void Odraz() //modifikace odrazu od palek
        {
            Random randomMR = new Random();
            int ModifikaceR  = randomMR.Next(0, 1 + 1);
            if(ModifikaceR == 0)
            {
                RychlostY += 5;
                RychlostX -= 5;
            }
            else
            {
                RychlostY -= 5;
                RychlostX += 5;
            }
                
        }
               

        
        public void OdrazOdPalky(PalkaLeva palkaL, PalkaPrava palkaP)
        {
            if(palkaL.PoziceY <= PoziceY + 12.5 && palkaL.PoziceY + 75 >= PoziceY + 12.5 && palkaL.PoziceX <= PoziceX && palkaL.PoziceX + 10 >= PoziceX)
            {
                Odraz();
                
                RychlostX *= -1;
                
            }
            if(palkaP.PoziceY <= PoziceY + 12.5 && palkaP.PoziceY + 75 >= PoziceY + 12.5 && palkaP.PoziceX <= PoziceX + 25 && palkaP.PoziceX + 10 >= PoziceX + 25)
            {
                Odraz();
                
                RychlostX *= -1;
            
            }
        }

        
        
        public void Vykresli(Graphics grafickaPlocha)
        {
            Brush stetec = Brushes.Black;
            grafickaPlocha.FillEllipse(stetec, (float)PoziceX, (float)PoziceY, (float)Prumer, (float)Prumer);
            grafickaPlocha.DrawString($"{SkoreA}  {SkoreB}", new Font("Arial", 20), stetec, 374, 10);
        }

        public void Posun(double rozdilCasu)
        {
            PoziceX += (RychlostX * rozdilCasu);
            PoziceY += (RychlostY * rozdilCasu);
        }
        
    }

                
                
            
            
                



}
        
