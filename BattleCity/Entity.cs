using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity
{
    abstract class Entity
    {
        public Image img;
        public Size size;
        public Point location;
        public Rectangle rect;
        public bool isDead = false;
        public bool isDestructable = true;
        public bool isBlock = false;
        public bool bblock = false;
        public _Orientation Or;
        public virtual void Draw() { }
    }
}
