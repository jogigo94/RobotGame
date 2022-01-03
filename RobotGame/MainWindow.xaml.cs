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
using System.Windows.Threading;

namespace RobotGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int NFILES = 5, NCOLUMNES = 5;
        Tauler joc;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            joc = new Tauler(NFILES,NCOLUMNES);
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            InitializeComponent();
            grdTaulell.Children.Add(joc);
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
        }

        
    }
}
