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
        Robot robot;
        Tresor tresor;

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

        internal bool jocAcabat()
        {
            return robot.Fila == tresor.Fila && robot.Columna == tresor.Columna;
            
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
             robot = new Robot(fila, columna);
            
            terreny[fila,columna] =robot;
            robot.ImgIcona = new BitmapImage(new Uri("/Images/LuffySud.png", UriKind.Relative));
            this.Children.Add(robot);
        }
        public void creaTresor()
        {
            int fila = r.Next(numFiles);
            int columna = r.Next(numColumnes);
            tresor = new Tresor(fila, columna);
            tresor.ImgIcona = new BitmapImage(new Uri("/Images/tresor.png", UriKind.Relative));
            terreny[fila, columna] = tresor;

            this.Children.Add(tresor);
        }
        public void movimentRobot()
        {
            switch (robot.OnMira)
            {
                case Direccio.Sud:
                    Mou(robot.Fila, robot.Columna, robot.Fila + 1, robot.Columna);
                    break;
                case Direccio.Est:
                    Mou(robot.Fila, robot.Columna, robot.Fila , robot.Columna+1);
                    break;
                case Direccio.Oest:
                    Mou(robot.Fila, robot.Columna, robot.Fila , robot.Columna-1);
                    break;
                case Direccio.Nord:
                    Mou(robot.Fila, robot.Columna, robot.Fila - 1, robot.Columna);
                    break;
            }
        }

        public void posicioRobot()
        {
            int atzar = r.Next(0,4);
            if (atzar == 0)
            {
                GirarEsquerra();
            }
            else if (atzar == 1)
            {
                GiraDreta();
            }
            else 
            {
                movimentRobot();
            }
            ActualitzarImatge();
        }

        private void GiraDreta()
        {
            switch (robot.OnMira)
            {
                case Direccio.Sud:
                    robot.OnMira = Direccio.Oest;
                    break;
                case Direccio.Est:
                    robot.OnMira = Direccio.Sud;
                    break;
                case Direccio.Oest:
                    robot.OnMira = Direccio.Nord;
                    break;
                case Direccio.Nord:
                    robot.OnMira = Direccio.Est;
                    break;
            }
        }

        private void GirarEsquerra()
        {
            switch (robot.OnMira)
            {
                case Direccio.Sud:
                    robot.OnMira = Direccio.Est;
                    break;
                case Direccio.Est:
                    robot.OnMira = Direccio.Nord;
                    break;
                case Direccio.Oest:
                    robot.OnMira = Direccio.Sud;
                    break;
                case Direccio.Nord:
                    robot.OnMira = Direccio.Oest;
                    break;
            }
            
        }

        private void ActualitzarImatge()
        {
            switch (robot.OnMira)
            {
                case Direccio.Sud:
                    robot.ImgIcona = new BitmapImage(new Uri("/Images/LuffySud.png", UriKind.Relative));
                    break;
                case Direccio.Est:
                    robot.ImgIcona = new BitmapImage(new Uri("/Images/LuffyEst.png", UriKind.Relative));
                    break;
                case Direccio.Oest:
                    robot.ImgIcona = new BitmapImage(new Uri("/Images/LuffyOest.png", UriKind.Relative));
                    break;
                case Direccio.Nord:
                    robot.ImgIcona = new BitmapImage(new Uri("/Images/LuffyNord.png", UriKind.Relative));
                    break;
            }
        }

        public void Mou(int filOrig, int colOrig, int filDesti, int colDesti)
        {
            if (DestiValid(filDesti, colDesti))
            {
                Posicio origen = terreny[filOrig, colOrig];
                terreny[filOrig, colOrig] = new Posicio(filOrig, colOrig);
                origen.Fila = filDesti;
                origen.Columna = colDesti;
                terreny[filDesti, colDesti] = origen;
                terreny[filDesti, colDesti].SetValue(Grid.RowProperty, filDesti);
                terreny[filDesti, colDesti].SetValue(Grid.ColumnProperty, colDesti);

            }

        }
    }
}
