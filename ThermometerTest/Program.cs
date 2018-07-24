using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermometerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryTemperatureReader myTemperatureReader = new InMemoryTemperatureReader();
            ThermoMeter myThermoMeter = new ThermoMeter(myTemperatureReader);
            Oven myOven = new Oven(myThermoMeter);
            Refrigerator myRefrigerator = new Refrigerator(myThermoMeter);

            OvenRegistrationInfo myOvenRegistrationInfo = new OvenRegistrationInfo(0, 0.5, Direction.Positive);
            myOven.RegisrterForTemperatureChange(myOvenRegistrationInfo);

            RefrigeratorRegistrationInfo myRefrigeratorRegistrationInfo = new RefrigeratorRegistrationInfo(0, 0.5, Direction.None);
            myRefrigerator.RegisrterForTemperatureChange(myRefrigeratorRegistrationInfo);

            for (int i=0; i<15; i++)
            {
                myTemperatureReader.Next();
            }

            Console.ReadLine();
        }
    }
}
