using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity
{
    class Adamantium : _Blocks
    {
        public Adamantium(Point position) : base(position)
        {
            isDestructable = false;
            img = Image.FromFile("adm.png");
        }

        public override void Draw()
        {
            base.Draw();
            Program.grph.DrawRectangle(new Pen(Color.Red), rect);
        }
    }
}
