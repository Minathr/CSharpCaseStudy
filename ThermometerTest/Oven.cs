using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermometerTest
{
    class Oven
    {
        private ThermoMeter _thermoMeter;
        public Oven(ThermoMeter thermoMeter)
        {
            _thermoMeter = thermoMeter;
        }
        public void RegisrterForTemperatureChange(OvenRegistrationInfo ovenRegistrationInfo)
        {
            TemperatureThresholdRegistrationInfo temperatureThresholdRegistrationInfo = new TemperatureThresholdRegistrationInfo();
            temperatureThresholdRegistrationInfo.Threshold = ovenRegistrationInfo.Threshold;
            temperatureThresholdRegistrationInfo.WaiverMargin = ovenRegistrationInfo.WaiverMargin;
            temperatureThresholdRegistrationInfo.ChangeDirection = ovenRegistrationInfo.ChangeDirection;
            temperatureThresholdRegistrationInfo.TemperatureThresholedReachedHandler = Handler;
            _thermoMeter.RequestRegistration(temperatureThresholdRegistrationInfo);
        }
        public void Handler(TemperatureThresholdReachedEventArgs args)
        {
            Console.WriteLine(" ***** Oven's temperature threshold has been reached!");
            //Console.WriteLine("Current Temperature: " + args.Temperature);
        }
    }
}
