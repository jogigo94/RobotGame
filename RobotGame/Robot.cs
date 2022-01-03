using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGame
{
    public class Robot:Posicio
    {
        Direccio onMira;
        public Robot(int fila, int columna) : base(fila, columna) 
        {
            this.OnMira = Direccio.Sud;
        }

        public override bool Buida
        {
            get => false;
        }
        public override bool EsRobot { get=>true; }
        public override bool EsTresor { get => false; }
        public Direccio OnMira { get => onMira; set => onMira = value; }
    }
}
