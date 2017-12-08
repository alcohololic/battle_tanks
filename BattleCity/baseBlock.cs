using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleCity
{
    class baseBlock : _Blocks
    {
        public baseBlock(Point position) : base(position)
        {
            bblock = true;
            isDestructable = true;
            img = Image.FromFile("baseBlock.png");
        }
        
    }
}
