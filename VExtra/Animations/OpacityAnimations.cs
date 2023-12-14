using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace VExtra.Animations
{
    public class OpacityAnimations
    {
        public DoubleAnimation opacityOut = new DoubleAnimation()
        {
            From = 1, To = 0.3, Duration = TimeSpan.FromMilliseconds(200)
        };
        public DoubleAnimation opacityIn = new DoubleAnimation()
        {
            From = 0.3,
            To = 1,
            Duration = TimeSpan.FromMilliseconds(200)
        };
    }
}
