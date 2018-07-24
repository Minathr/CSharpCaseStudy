namespace ThermometerTest
{
    class TemperatureThresholdReachedEventArgs
    {
        public double Temperature;
        public Direction ChangeDirection;
        public TemperatureThresholdReachedEventArgs(double temperature, Direction changeDirection)
        {
            Temperature = temperature;
            ChangeDirection = changeDirection;
        }
    }
}