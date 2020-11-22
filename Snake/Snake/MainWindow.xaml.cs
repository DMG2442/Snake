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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const int TAMANY_SNAKE = 50;
        SolidColorBrush pinzellSnake = new SolidColorBrush(Colors.BlueViolet);
        SolidColorBrush pinzellPoma = new SolidColorBrush(Colors.Red);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnIniciaJoc_Click(object sender, RoutedEventArgs e)
        {
            Ellipse el = new Ellipse()
            {
                Fill = pinzellSnake,
                Width = TAMANY_SNAKE,
                Height = TAMANY_SNAKE
            };
            Canvas.SetLeft(el, 100);
            Canvas.SetTop(el, 100);
            cnvCanvas.Children.Add(el);
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                Ellipse elPoma = new Ellipse()
                {
                    Fill = pinzellPoma,
                    Width = TAMANY_SNAKE,
                    Height = TAMANY_SNAKE
                };
                Canvas.SetLeft(el, r.Next(0,500));
                Canvas.SetTop(el, r.Next(0, 500));
                cnvCanvas.Children.Add(elPoma);
                Canvas.SetLeft(elPoma, 200);
                Canvas.SetTop(elPoma, 200);
            }
         

            

            
            

        }
    }
}
