using System;
using System.Collections.Generic;

namespace Practice1
{
    internal class Program
    {
        static void Main()
        {
            // Primer bloque de acciones (creación de taxis y coches de policía, patrullaje, uso del radar, etc.)
            SpeedRadar radar1 = new SpeedRadar();
            SpeedRadar radar2 = new SpeedRadar();
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            PoliceCar policeCar1 = new PoliceCar("0001 CNP", radar1);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", radar2);

            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));

            
            Console.WriteLine("\n--- Assigning police cars to a new city and police station ---\n");

            PoliceStation newPoliceStation = new PoliceStation(); 
            City newCity = new City(newPoliceStation); 

            
            newPoliceStation.RegisterPolice(policeCar1);
            newPoliceStation.RegisterPolice(policeCar2);

            
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            taxi2.StartRide();
            policeCar2.UseRadar(taxi2);
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2);
            taxi2.StopRide();
            policeCar2.EndPatrolling();

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1);
            taxi1.StopRide();
            taxi1.StopRide();
            policeCar1.EndPatrolling();

            
            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();

            // Segundo bloque de acciones (creación de otra ciudad y comisaría de policía, más taxis, coches de policía, etc.)
            Console.WriteLine("\n--- Second part: Creating another city and police station ---\n");

            
            PoliceStation policeStation = new PoliceStation();
            Console.WriteLine(policeStation.WriteMessage("Created"));
            City city = new City(policeStation);
            Console.WriteLine(city.WriteMessage("Created"));

            Taxi cityTaxi1 = city.NewLicense("ABC123");
            Taxi cityTaxi2 = city.NewLicense("DEF456");
            Taxi cityTaxi3 = city.NewLicense("GHI789");

            Console.WriteLine(cityTaxi1.WriteMessage("Created"));
            Console.WriteLine(cityTaxi2.WriteMessage("Created"));
            Console.WriteLine(cityTaxi3.WriteMessage("Created"));

            
            SpeedRadar radar3 = new SpeedRadar();
            SpeedRadar radar4 = new SpeedRadar();
            PoliceCar cityPoliceCar1 = new PoliceCar("POLICE001", radar3);
            PoliceCar cityPoliceCar2 = new PoliceCar("POLICE002", radar4);
            PoliceCar cityPoliceCar3 = new PoliceCar("POLICE003"); 
            

            Console.WriteLine(cityPoliceCar1.WriteMessage("Created"));
            Console.WriteLine(cityPoliceCar2.WriteMessage("Created"));
            Console.WriteLine(cityPoliceCar3.WriteMessage("Created"));

            policeStation.RegisterPolice(cityPoliceCar1);
            policeStation.RegisterPolice(cityPoliceCar2);
            policeStation.RegisterPolice(cityPoliceCar3);

            
            cityPoliceCar1.StartPatrolling();
            cityPoliceCar2.StartPatrolling();
            cityPoliceCar3.StartPatrolling();

            
            
            cityPoliceCar3.UseRadar(cityTaxi1); 

            
            cityTaxi1.StartRide(); 
            cityPoliceCar1.UseRadar(cityTaxi1); 

            
            city.deleteLicense(cityTaxi1.GetPlate()); 

            
            policeStation.PrintSpeedingList(); 

            Console.ReadLine(); 
        }
    }
}
