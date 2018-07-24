using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermometerTest
{
    class InMemoryTemperatureReader : TempratureReader
    {
        private double[] _inMemoryTemperatureResource = { 1, 0.5, -1, -0.7, 0, 0.5, -0.5, 0 , 1, 1.7, 0.5, 0 };
        private int _lastReadIndex = 0;
        public double? Next()
        {
            if (_lastReadIndex >= (_inMemoryTemperatureResource.Length-1))
                return null;
            
            _lastReadIndex++;
            TemperatureChangedEventArgs temperatureChangedEventArgs = new TemperatureChangedEventArgs();
            temperatureChangedEventArgs.Temperature = _inMemoryTemperatureResource[_lastReadIndex];
            temperatureChangedEventArgs.ChangeDirection = GetDirection(_lastReadIndex);

            NotifyOnTempratureChanged(temperatureChangedEventArgs);
            return _inMemoryTemperatureResource[_lastReadIndex];
            
        }

        public Direction GetDirection(int i)
        {
            if (_inMemoryTemperatureResource[i] - _inMemoryTemperatureResource[i - 1] > 0)
            {
                return Direction.Positive;
            }
            else if (_inMemoryTemperatureResource[_lastReadIndex] - _inMemoryTemperatureResource[_lastReadIndex - 1] < 0)
            {
                return Direction.Negative;
            }
            else
            {
                return Direction.None;
            }
        }
    }
}
