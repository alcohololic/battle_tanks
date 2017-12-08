using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity
{
    class _Blocks : Entity
    {
             
        public _Blocks(Point position)
        {
            isDestructable = true;
            isBlock = true;
            location = position;
            size = new Size(20,20);
            rect = new Rectangle(location, size);
            this.img = Image.FromFile("red.png");
        }


        public override void Draw()
        {
            Program.grph.DrawImage(img, location);
        }

    }
}
