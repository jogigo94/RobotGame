using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RobotGame
{
    public class Tauler:Grid 
    {
        int numFiles;
        int numColumnes;
        Posicio[,] terreny;
        Random r=new Random();
        
        public Tauler(int files, int columnes)
        {
            this.NumFiles = files;
            this.NumColumnes = columnes;
            terreny=new Posicio[files,columnes];
            ColumnDefinition columnaNova;
            RowDefinition filaNova;

            for (int fila = 0; fila < files; fila++)
            {
                filaNova = new RowDefinition();
                filaNova.Height = new GridLength(1, GridUnitType.Star);

                this.RowDefinitions.Add(filaNova);

            }
            for (int columna = 0; columna < columnes; columna++)
            {
                columnaNova = new ColumnDefinition();
                columnaNova.Width = new GridLength(1, GridUnitType.Star);
                this.ColumnDefinitions.Add(columnaNova);
            }
            
            for (int fila = 0; fila < files; fila++)
            {
                for (int columna = 0; columna < columnes; columna++)
                {
                    Posicio pos = new Posicio(fila, columna);
                    terreny[fila, columna] = pos;

                    pos.SetValue(Grid.ColumnProperty, columna);
                    pos.SetValue(Grid.RowProperty, fila);
                    this.Children.Add(pos);
                }
            }
            creaRobot();
            creaTresor();
        }

        public int NumFiles { get => numFiles; set => numFiles = value; }
        public int NumColumnes { get => numColumnes; set => numColumnes = value; }

        public bool DestiValid(int fil, int col)
        {
            return fil >= 0 && fil < NumFiles && col >= 0 && col < NumColumnes;
        }
        public void creaRobot()
        {
            int fila = r.Next(numFiles);
            int columna = r.Next(numColumnes);
            Robot robot = new Robot(fila, columna);
            
            terreny[fila,columna] =robot;
            robot.ImgIcona = new BitmapImage(new Uri("/Images/LuffySud.png", UriKind.Relative));
            this.Children.Add(robot);
        }
        public void creaTresor()
        {
            int fila = r.Next(numFiles);
            int columna = r.Next(numColumnes);
            Tresor tresor = new Tresor(fila, columna);
            tresor.ImgIcona = new BitmapImage(new Uri("/Images/tresor.png", UriKind.Relative));
            terreny[fila, columna] = tresor;

            this.Children.Add(tresor);
        }

    }
}
