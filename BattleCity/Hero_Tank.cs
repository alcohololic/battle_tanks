using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BattleCity
{
    class Hero_Tank : _Tanks
    {
        public Hero_Tank(Point startPosition) : base(startPosition)
        {
            this.img = Image.FromFile("tank.png");
        }

        public void move(Entity[,] map, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                this.isMoving = true;
                this.Or = _Orientation.Left;
            }
            else if (e.KeyCode == Keys.D)
            {
                this.isMoving = true;
                this.Or = _Orientation.Right;
            }

            else if (e.KeyCode == Keys.W)
            {
                this.isMoving = true;
                this.Or = _Orientation.Up;
            }
            else if (e.KeyCode == Keys.S)
            {
                this.isMoving = true;
                this.Or = _Orientation.Down;
            }
            else if (e.KeyCode == Keys.X)
            {
                this.StartShoot();
            }
            base.move(map);
        }

    }

}
