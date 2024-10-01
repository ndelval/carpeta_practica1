namespace Practice1
{
    public class SpeedRadar : IMessageWritter, IRadar
    {
        //Radar doesn't know about Vechicles, just speed and plates
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> SpeedHistory { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();
        }

        public void TriggerRadar(Vehicle vehicle)
        {
            plate = vehicle.GetPlate();
            speed = vehicle.GetSpeed();
            SpeedHistory.Add(speed);
        }
        
        public (string, bool) GetLastReading()
        {
            string radarMessage;
            bool trigger;

            if (speed > legalSpeed)
            {
                trigger = true;
                radarMessage = WriteMessage("Caught above legal speed.");
            }
            else
            {
                trigger = false;
                radarMessage = WriteMessage("Driving legally.");
            }

            // Return both the radar message and the speed
            return (radarMessage, trigger);
        }

        public virtual string WriteMessage(string radarReading)
        {
            return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {radarReading}";
        }
    }
}