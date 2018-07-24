using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermometerTest
{
    class Refrigerator
    {
        private ThermoMeter _thermoMeter;
        public Refrigerator(ThermoMeter thermoMeter)
        {
            _thermoMeter = thermoMeter;
        }
        public void RegisrterForTemperatureChange(RefrigeratorRegistrationInfo refrigeratorRegistrationInfo)
        {
            TemperatureThresholdRegistrationInfo temperatureThresholdRegistrationInfo = new TemperatureThresholdRegistrationInfo();
            temperatureThresholdRegistrationInfo.Threshold = refrigeratorRegistrationInfo.Threshold;
            temperatureThresholdRegistrationInfo.WaiverMargin = refrigeratorRegistrationInfo.WaiverMargin;
            temperatureThresholdRegistrationInfo.ChangeDirection = refrigeratorRegistrationInfo.ChangeDirection;
            temperatureThresholdRegistrationInfo.TemperatureThresholedReachedHandler = Handler;
            _thermoMeter.RequestRegistration(temperatureThresholdRegistrationInfo);
        }
        public void Handler(TemperatureThresholdReachedEventArgs args)
        {
            Console.WriteLine(" ***** Refrigerator's temperature threshold has been reached!");
            //Console.WriteLine("Current Temperature: " + args.Temperature);
        }
    }
}
