using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermometerTest
{
    class TemperatureThresholdRegistrationInfo
    {
        public double Threshold;
        public double WaiverMargin;
        public Direction ChangeDirection;
        public Action<TemperatureThresholdReachedEventArgs> TemperatureThresholedReachedHandler;
    }
}
