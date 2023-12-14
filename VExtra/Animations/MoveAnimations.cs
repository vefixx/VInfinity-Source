using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace VExtra.Animations
{
    public class MoveAnimations
    {
        public DoubleAnimation moveUp = new DoubleAnimation()
        {
            From = 400, To = 450, Duration = TimeSpan.FromMilliseconds(200)
        };
        public DoubleAnimation moveDown = new DoubleAnimation()
        {
            From = 450,
            To = 400,
            Duration = TimeSpan.FromMilliseconds(200)
        };
    }
}
