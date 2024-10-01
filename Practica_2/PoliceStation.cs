using System;
using static System.Collections.Specialized.BitVector32;

namespace Practice1
{
    public class PoliceStation : IStation, IMessageWritter
    {
        private List<PoliceCar> PoliceList;
        private List<Vehicle> SpeedingList;
        private bool Alert;


        public PoliceStation()
        {
            PoliceList = new List<PoliceCar>();
            SpeedingList = new List<Vehicle>();

        }

        public override string ToString()
        {
            return $"Police Station";
        }
        
        public void RegisterPolice(PoliceCar policeCar)
        {
            PoliceList.Add(policeCar);
            policeCar.setStation(this);


        }

        public void AddSpeedingTaxi(Vehicle vehicle)
        {
            SpeedingList.Add(vehicle);
            Alert = true;
            SendChasing();
            Console.WriteLine($"Vehicle {vehicle.GetPlate()} added to speeding list.");
        }

        public void SendChasing()
        {
            if (Alert)
            {
                Console.WriteLine("Police alerted! Sending all available units on a chase.");
                foreach (PoliceCar car in PoliceList)
                {
                    if (car.IsPatrolling())
                    {
                        car.StartChasing();
                    }
                    
                }
            }
                

        }
        public void PrintSpeedingList()
        {
            Console.WriteLine("Speeding vehicles:");
            foreach (var vehicle in SpeedingList)
            {
                Console.WriteLine(vehicle.GetPlate());
            }
        }
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}

