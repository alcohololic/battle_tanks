using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity
{
    class _Tanks : Entity
    {
        
        public bool isMoving = false;
        Point last;

        public _Tanks(Point startPosition)
        {
            location = startPosition;
            Or = _Orientation.Up;
            last = new Point(rect.Location.X, rect.Location.Y);
            size = new Size(25, 25);
            rect = new Rectangle(location, size);
        }

        Image getImage()
        {

            Image temp = (Image)img.Clone();
            switch (Or)
            {
                case _Orientation.Up:
                    {
                        rect.Size = temp.Size;
                        break;
                    }
                case _Orientation.Down:
                    {
                        temp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        rect.Size = temp.Size;
                        break;
                    }
                case _Orientation.Left:
                    {
                        temp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        rect.Size = temp.Size;
                        break;
                    }
                case _Orientation.Right:
                    {
                        temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        rect.Size = temp.Size;
                        break;
                    }

            }

            return temp;
        }

        public override void Draw()
        {
            Program.grph.DrawImage(getImage(), location);
        }

        public virtual void move(Entity[,] map)
        {
            
            if (
                (location.X <= 1 && this.Or == _Orientation.Left) ||
                (location.X >= (499) && this.Or == _Orientation.Right) ||
                (location.Y <= 1 && this.Or == _Orientation.Up) ||
                (location.Y >= (499) && this.Or == _Orientation.Down)
                )
            {
                return;
            }
       

            double _i = rect.Y / 20;
            double _j = rect.X / 20;
            int i = (int)_i;
            int j = (int)_j;
            bool intersect = false;

            
                if ((map[i - 1, j] != null && rect.Top <= map[i - 1, j].rect.Bottom && this.Or == _Orientation.Up ||
                   (map[i - 1, j] == null && map[i - 1, j + 1] != null) && rect.Top <= map[i - 1, j + 1].rect.Bottom && this.Or == _Orientation.Up) ||

                   (map[i + 1, j] != null && rect.Bottom >= map[i + 1, j].rect.Top && this.Or == _Orientation.Down ||
                   (map[i + 1, j] == null && map[i + 1, j + 1] != null) && rect.Bottom >= map[i + 1, j + 1].rect.Top && this.Or == _Orientation.Down) ||

                   (map[i, j] != null && rect.Left <= map[i, j].rect.Right && this.Or == _Orientation.Left ||
                   (map[i, j] == null && map[i + 1, j] != null) && rect.Left <= map[i + 1, j].rect.Right && rect.Top <= map[i + 1, j].rect.Bottom && this.Or == _Orientation.Left) ||

                   (map[i, j + 1] != null && rect.Right >= map[i, j + 1].rect.Left && this.Or == _Orientation.Right ||
                   (map[i, j + 1] == null && map[i + 1, j + 1] != null) && rect.Right >= map[i + 1, j + 1].rect.Left && rect.Bottom >= map[i + 1, j + 1].rect.Top && this.Or == _Orientation.Right)
                   )
                intersect = true;

            if (intersect == false)
            {
                last = location; 
            }
            else
               {
                rect.Location = last;
                location = last;
                    isMoving = false;
            }
         

            if (!isMoving) { return; }

            switch (Or)
            {
                case _Orientation.Up: this.location.Y -= 1; break;
                case _Orientation.Down: this.location.Y += 1; break;
                case _Orientation.Left: this.location.X -= 1; break;
                case _Orientation.Right: this.location.X += 1; break;

            }
            rect.Location = location;

        }

        public void StartShoot()
        {
            lock (Program.entities)
            {
                _Bullet bullet = new _Bullet(location, Or); 
                Program.entities.Add(bullet);
            }

        }
    }
    }



