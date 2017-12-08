using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace BattleCity
{
    class _Bullet : Entity
    {
        public Point Location;
        public bool isFire;
        

        public _Bullet(Point Location, _Orientation Or)
        {
            this.Location = Location;
            this.Or = Or;
            size = new Size(4, 4);
            rect = new Rectangle(Location, size);
            this.img = Image.FromFile("bullet.png");
            StartShoot(Location, Or);


        }

        public override void Draw()
        {
            Program.grph.DrawImage(img, Location);
        }

        private void StartShoot(Point location, _Orientation orientation)
        {
            switch (orientation)
            {
                case _Orientation.Up:
                    {
                        Location = new Point(location.X + 8, location.Y - 1);
                        break;
                    }

                case _Orientation.Down:
                    {
                        Location = new Point(location.X + 8, location.Y + 26);
                        break;
                    }

                case _Orientation.Left:
                    {
                        Location = new Point(location.X - 1, location.Y + 8);
                        break;
                    }

                case _Orientation.Right:
                    {
                        Location = new Point(location.X + 26, location.Y + 8);
                        break;
                    }
            }
            isFire = true;
        }

        public void move(Entity[,] map)
        {
            if (isFire)
            {
                switch (Or)
                {
                    case _Orientation.Up: this.Location.Y -= 5; break;
                    case _Orientation.Down: this.Location.Y += 5; break;
                    case _Orientation.Left: this.Location.X -= 5; break;
                    case _Orientation.Right: this.Location.X += 5; break;
                }

                rect.Location = this.Location;

                double _i = rect.Y / 20;
                double _j = rect.X / 20;
                int i = (int)_i;
                int j = (int)_j;

                if (rect.Top <= 20 || rect.Bottom >= 500 || rect.Left <= 20 || rect.Right >= 500)
                    this.isDead = true;
                else                              
                if (map[i, j] != null && rect.IntersectsWith(map[i, j].rect) && map[i, j].bblock == true)
                {
                    this.isDead = true;
                    map[i, j] = null;
                    MessageBox.Show("Killed");
                    Application.Exit();
                }
                else
                if (map[i, j] != null && rect.IntersectsWith(map[i, j].rect) && map[i, j].isDestructable == true)
                {
                    map[i, j] = null;
                    this.isDead = true;
                }
                else
                    for (int k = 0; k < Program.entities.Count; k++)
                    {
                        var item = Program.entities[k];
                        if (item is Enemy_Tank)
                        {

                            if (rect.IntersectsWith(item.rect))
                            {
                                item.isDead = true;
                                this.isDead = true;
                            }
                        }
                        if (item is Hero_Tank)
                        {
                            if (rect.IntersectsWith(item.rect))
                            {
                                item.isDead = true;
                                this.isDead = true;
                                MessageBox.Show("Killed");
                                Application.Exit();
                            }
                        }

                    }
            }
        }

    }
}

