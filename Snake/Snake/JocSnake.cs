using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake
{
    class JocSnake
    {
        public bool fiPartida=false;
        public const int WIDH = 5;
        public const int HEIGHT = 5;
        const int NPOMES = 5;
        private List<Point> cosSerp = new List<Point>();
        private List<Point> pomes;
        Point cap;
        DireccioSnake direccio;

        public DireccioSnake Direccio { get => direccio; set => direccio = value; }
        public Point Cap { get => cap; set => cap = value; }
        public List<Point> Pomes { get => pomes; set => pomes = value; }
        public List<Point> CosSerp { get => cosSerp; set => cosSerp = value; }

        public JocSnake()
        {
            Cap = new Point(0, 0);
            Direccio = DireccioSnake.Sud;
            Pomes = new List<Point>();
            cosSerp.Add(cap);
            //distribuir pomes 
            Random r = new Random();
            for (int i = 0; i < NPOMES; i++)
            {
                var x = r.Next(0, WIDH - 1);
                var y = r.Next(0, HEIGHT - 1);
                while (x == 0 && y == 0)
                {
                    x = r.Next(0, WIDH - 1);
                    y = r.Next(0, HEIGHT - 1); ;
                }
                Pomes.Add(new Point(x, y));

            }
        }

        

        public void moure()
        {
            if (fiPartida == false)
            {
                if (Direccio == DireccioSnake.Nord)
                {
                    cap.Y--;
                    if (cap.Y== -2)
                    {
                        FinalPartida();
                    }
                }
                else if (Direccio == DireccioSnake.Sud)
                {
                    cap.Y++;
                    if (Cap.Y == HEIGHT+1)
                    {
                        FinalPartida();
                    }
                }

                else if (Direccio == DireccioSnake.Est)
                {
                    cap.X++;
                    if (Cap.X == WIDH+1)
                    {
                        FinalPartida();
                    }
                }

                else if (Direccio == DireccioSnake.Oest)
                {
                    cap.X--;
                    //MessageBox.Show(cap.X.ToString());
                    if (Cap.X == -2)
                    {
                        FinalPartida();
                    }
                }
                bool primer = true;


                if (CosSerp.Count > 1)
                {
                    Point aux1 = new Point();
                    Point aux2 = new Point();
                    Point aux3 = new Point();
                    Point aux4 = new Point();
                    if (CosSerp.Count == 2)
                    {
                        CosSerp[1] = CosSerp[0];                      
                    }

                    if (CosSerp.Count == 3)
                    {
                        aux1 = CosSerp[1];
                        CosSerp[1] = CosSerp[0];
                        CosSerp[2] = aux1;
                    }

                    if (CosSerp.Count == 4)
                    {
                        aux1 = CosSerp[1];
                        CosSerp[1] = CosSerp[0];
                        aux2 = CosSerp[2];
                        CosSerp[2] = aux1;
                        CosSerp[3] = aux2;
                    }

                    if (CosSerp.Count == 5)
                    {
                        aux1 = CosSerp[1];
                        CosSerp[1] = CosSerp[0];
                        aux2 = CosSerp[2];
                        CosSerp[2] = aux1;
                        aux3 = CosSerp[3];
                        CosSerp[3] = aux2;
                        CosSerp[4] = aux3;
                    }

                    if (CosSerp.Count == 6)
                    {
                        aux1 = CosSerp[1];
                        CosSerp[1] = CosSerp[0];
                        aux2 = CosSerp[2];
                        CosSerp[2] = aux1;
                        aux3 = CosSerp[3];
                        CosSerp[3] = aux2;
                        aux4 = CosSerp[4];
                        CosSerp[4] = aux3;
                        CosSerp[5] = aux4;
                    }
                }

                CosSerp[0] = Cap;
                for (int i = 0; i < pomes.Count; i++)
                {
                   
                    if (cap.X == pomes[i].X && cap.Y == pomes[i].Y)
                    {
                        CosSerp.Add(pomes[i]);
                        pomes.Remove(pomes[i]);
                        if (pomes.Count() == 0)
                            FinalPartida();
                    }
                }
            }
           
            else FinalPartida();
           

        }
        private void FinalPartida()
        {
            fiPartida = true;
            if(Pomes.Count()==0)
                MessageBox.Show("Has guanyat");
            else MessageBox.Show("Has perdut");
        }
    }
   

    public enum DireccioSnake
    {
        Nord,
        Sud,
        Est,
        Oest
    }


}
