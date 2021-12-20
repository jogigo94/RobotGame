using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotGame
{
    public class Robot:Posicio
    {
        public Robot(int fila, int columna) : base(fila, columna) { }

        public override bool Buida
        {
            get => false;
        }
        public override bool EsRobot { get=>true; }
        public override bool EsTresor { get => false; }
    }
}
