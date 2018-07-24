using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermometerTest
{
    abstract class TempratureReader
    {
        public delegate void TempratureChangedEventHandler(TemperatureChangedEventArgs args);// Declare delegate. public event MyDelegate BeginOutput; // Declare event.
        public event TempratureChangedEventHandler TemperatureChanged;
        public void NotifyOnTempratureChanged(TemperatureChangedEventArgs temperatureChangedEventArgs)
        {
            TemperatureChanged?.Invoke(temperatureChangedEventArgs);
        }
    }
}
