using static System.Collections.Specialized.BitVector32;

namespace Practice1
{
    public class PoliceCar : VehicleWithPlate
    {

        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private PoliceStation policeStation;
        private bool isChasing;

        public PoliceCar(string plate, SpeedRadar argSpeedRadar = null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = argSpeedRadar;
                
        }
        public void setStation(PoliceStation station)
        {
            policeStation = station;
        }

        public void StartChasing()
        {
            isChasing = true;
            Console.WriteLine($"{GetPlate()} is now chasing.");
        }

        private void SendSpeeding(Vehicle vehicle)
        {
            policeStation.AddSpeedingTaxi(vehicle);
        }

        // DUDA cuando va a dejar de perseguir el policia?
        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling && speedRadar != null)
            {
                speedRadar.TriggerRadar(vehicle);
                var (message, trigger) = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {message}"));
                if (trigger)
                {
                    SendSpeeding(vehicle);
                    isChasing = true;
                }

                

            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                isChasing = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("Has no active Radar"));
            }
                
        }
        public bool GetIsChasing()
        {
            return isChasing;
        }
    }
}