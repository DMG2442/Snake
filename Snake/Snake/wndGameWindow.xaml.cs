using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Lógica de interacción para wndGameWindow.xaml
    /// </summary>
    public partial class wndGameWindow : Window
    {
        public const int SNAKE_HEAD_WIDTH = 100;
        public const int SNAKE_HEAD_HEIGHT = 100;
        SolidColorBrush pinzell = new SolidColorBrush(Colors.Green);
        SolidColorBrush pinzellPoma = new SolidColorBrush(Colors.Red);
        JocSnake joc;
        DispatcherTimer timer = new DispatcherTimer();
        public wndGameWindow()
        {
            InitializeComponent();
            joc = new JocSnake();
            
            this.KeyDown += WndGameWindow_KeyDown;
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
         
        }

        private void WndGameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (joc.fiPartida == false)
            {
                if (e.Key == Key.Up)
                    joc.Direccio = DireccioSnake.Nord;
                else if (e.Key == Key.Down)
                    joc.Direccio = DireccioSnake.Sud;
                else if (e.Key == Key.Right)
                    joc.Direccio = DireccioSnake.Est;
                else if (e.Key == Key.Left)
                    joc.Direccio = DireccioSnake.Oest;
            }
            else cnvCanvas.Children.Clear();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (joc.fiPartida == false)
            {
                Ellipse elSnake=new Ellipse();
                List<Point> cosSerp;
                cosSerp = joc.CosSerp;
                cnvCanvas.Children.Clear();
                
                foreach (Point snake in cosSerp)
                {
                     elSnake = new Ellipse()
                    {
                        //fer codi de cos
                        //eliminar ultim i colocar a on estava el primer
                        Fill = pinzell,
                        Width = SNAKE_HEAD_WIDTH,
                        Height = SNAKE_HEAD_HEIGHT

                    };
                    Canvas.SetTop(elSnake, snake.Y * SNAKE_HEAD_HEIGHT);
                    Canvas.SetLeft(elSnake, snake.X* SNAKE_HEAD_WIDTH);
                    //Canvas.SetTop(elSnake, joc.Cap.Y * SNAKE_HEAD_HEIGHT);
                    //Canvas.SetLeft(elSnake, joc.Cap.X * SNAKE_HEAD_WIDTH);
                    cnvCanvas.Children.Add(elSnake);
                   
                }

              

                joc.moure();







                List<Point> llistaPomes;
                llistaPomes = joc.Pomes;
               
                foreach (Point poma in llistaPomes)
                {
                    Ellipse elPoma = new Ellipse()
                    {
                        Fill = pinzellPoma,
                        Width = SNAKE_HEAD_WIDTH,
                        Height = SNAKE_HEAD_HEIGHT
                    };
                    Canvas.SetTop(elPoma, poma.Y * SNAKE_HEAD_HEIGHT);
                    Canvas.SetLeft(elPoma, poma.X * SNAKE_HEAD_WIDTH);
                    cnvCanvas.Children.Add(elPoma);
                }
                
            }
            else cnvCanvas.Children.Clear();
        }

        private void BtnIniciaJoc_Click(object sender, RoutedEventArgs e)
        {
           
            timer.Start();


        }
    }
}
