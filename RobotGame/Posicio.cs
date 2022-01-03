using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RobotGame
{
    public class Posicio : UserControl
    {
        public static Random random = new Random();
        protected int fila;
        protected int columna;
        private Image imgIcona;
        private DockPanel contingut = new DockPanel();

        /// <summary>
        /// Crea una nova posició
        /// </summary>
        /// <param name="fil">Fila de la Posició</param>
        /// <param name="col">Columna de la Posició</param>


        public Posicio( int fil, int col)
        {
            this.fila = fil;
            this.columna = col;
            this.BorderBrush = Brushes.Black;
            this.BorderThickness = new Thickness(1);
            this.imgIcona = new Image();
            
            contingut.LastChildFill = true;
            imgIcona.SetValue(DockPanel.DockProperty, Dock.Top);
            contingut.Background = Brushes.Transparent;
            contingut.Children.Add(imgIcona);
            this.SetValue(Grid.RowProperty, fil);
            this.SetValue(Grid.ColumnProperty, col);
            AddChild(contingut);


        }

        public ImageSource ImgIcona
        {
            get
            {
                return imgIcona.Source;
            }
            set
            {
                imgIcona.Source = value;
            }
        }

        /// <summary>
        /// Assigna o obté la columna de la posicio
        /// </summary>
        public int Columna
        {
            get => this.columna;
            set => this.columna = value;
        }
        /// <summary>
        /// Assigna o obté la fila de la posicio
        /// </summary>
        public int Fila
        {
            get => this.fila;
            set => fila = value;
        }

        /// <summary>
        /// Retorna si la posició està o no buida
        /// </summary>
        public virtual bool Buida
        {
            get => true;
        }

        public virtual bool EsRobot
        {
            get =>false;
        }

        public virtual bool EsTresor
        {
            get => false;
        }
    }
}
