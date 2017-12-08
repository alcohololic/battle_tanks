using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity
{
    class Enemy_Tank : _Tanks
    {
        private Random rnd;
        int timeForNewOr;
        int timerForShoot;

        public Enemy_Tank(Point startPosition) : base(startPosition)
        {
            rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            this.img = Image.FromFile("Enemy_tank.png");

            timerForShoot = 0;
            timeForNewOr = 0;
        }
        
        public override void move(Entity[,] map)
        {
            timeForNewOr++;
            if (timeForNewOr == 30)
            {
                timeForNewOr = 0;
                NewOrientation();
            }
            timerForShoot++;
            if (timerForShoot > 100)
            {
                _Bullet bullet = new _Bullet(location, Or);
                lock (Program.entities)
                {
                    Program.entities.Add(bullet);
                }

                timerForShoot = 0;
            }
            base.move(map);
        }

        private void NewOrientation()
        {
            switch (rnd.Next(6))
            {
                case 6: this.Or = _Orientation.Up; break;
                case 2: this.Or = _Orientation.Down; break;
                case 3: this.Or = _Orientation.Left; break;
                case 4: this.Or = _Orientation.Right; break;
                case 5: this.Or = _Orientation.Right; break;
                case 1: this.Or = _Orientation.Down; break;
            }

        }

    }
}
