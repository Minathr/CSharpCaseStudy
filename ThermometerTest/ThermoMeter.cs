using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ThermometerTest
{
    class ThermoMeter
    {
        private class InternalRegistrationInfo
        {
            public double Threshold;
            public double WaiverMargin;
            public Direction ChangeDirection;
            public bool IsFluctuatingAroundThreshold;
            public Action<TemperatureThresholdReachedEventArgs> TemperatureThresholedReachedHandler;
            public InternalRegistrationInfo(TemperatureThresholdRegistrationInfo temperatureThresholdRegistrationInfo)
            {
                Threshold = temperatureThresholdRegistrationInfo.Threshold;
                WaiverMargin = temperatureThresholdRegistrationInfo.WaiverMargin;
                ChangeDirection = temperatureThresholdRegistrationInfo.ChangeDirection;
                IsFluctuatingAroundThreshold = false;
                TemperatureThresholedReachedHandler = temperatureThresholdRegistrationInfo.TemperatureThresholedReachedHandler;
            }
        }

        private TempratureReader _temperatureReader;
        private List<InternalRegistrationInfo> _registerationRequests;
        public ThermoMeter(TempratureReader temperatureReader)
        {
            _temperatureReader = temperatureReader;
            _temperatureReader.TemperatureChanged += HandleTempratureChanged;
            _registerationRequests = new List<InternalRegistrationInfo>();
        }

        public void HandleTempratureChanged(TemperatureChangedEventArgs args)
        {
            Console.WriteLine("Current Temperature: " + args.Temperature);
            foreach (InternalRegistrationInfo registeredRequest in _registerationRequests)
            {
                if (IsThreshold(registeredRequest, args)
                    && IsInDirection(registeredRequest, args)
                    && !registeredRequest.IsFluctuatingAroundThreshold)
                {
                    TemperatureThresholdReachedEventArgs temperatureThresholdReachedEventArgs = new TemperatureThresholdReachedEventArgs(args.Temperature, args.ChangeDirection);
                    registeredRequest.TemperatureThresholedReachedHandler(temperatureThresholdReachedEventArgs);
                    registeredRequest.IsFluctuatingAroundThreshold = true;
                }

                if (IsOutOfWaiverMargin(registeredRequest, args))
                {
                    registeredRequest.IsFluctuatingAroundThreshold = false;
                }
            }
        }
        public void RequestRegistration(TemperatureThresholdRegistrationInfo temperatureTresholdRegistrationInfo)
        {
            InternalRegistrationInfo registrationInfo = new InternalRegistrationInfo(temperatureTresholdRegistrationInfo);
            _registerationRequests.Add(registrationInfo);
        }

        private bool IsThreshold(InternalRegistrationInfo registeredRequest, TemperatureChangedEventArgs temperatureArgs)
        {
            return registeredRequest.Threshold == temperatureArgs.Temperature;
        }
        private bool IsInDirection(InternalRegistrationInfo registeredRequest, TemperatureChangedEventArgs temperatureArgs)
        {
            if (registeredRequest.ChangeDirection == Direction.None)
                return true;

            return registeredRequest.ChangeDirection == temperatureArgs.ChangeDirection;
        }

        private bool IsOutOfWaiverMargin(InternalRegistrationInfo registeredRequest, TemperatureChangedEventArgs temperatureArgs)
        {
            return Math.Abs(temperatureArgs.Temperature - registeredRequest.Threshold) > registeredRequest.WaiverMargin;
        }
    }
}
