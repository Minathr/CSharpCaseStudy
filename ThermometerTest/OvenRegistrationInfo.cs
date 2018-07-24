using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermometerTest
{
    class OvenRegistrationInfo
    {
        public double Threshold;
        public double WaiverMargin;
        public Direction ChangeDirection;
        public OvenRegistrationInfo(double threshold, double waiverMargin, Direction changeDirection)
        {
            Threshold = threshold;
            WaiverMargin = waiverMargin;
            ChangeDirection = changeDirection;
        }
    }
}
