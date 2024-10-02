using System;
namespace Practice1
{
	public class City : IMessageWritter
	{
		private IStation CityStation; // Por si en vez de una estación de policia queremos una estacion de bomberos
        private List<Taxi> taxiLicences;

		public City(IStation argCityStation) 
		{
			CityStation = argCityStation; 
            taxiLicences = new List<Taxi>();
        }
        public override string ToString()
        {
            return $"City";
        }

        internal Taxi NewLicense(string plate)
        {
            Taxi taxi = new Taxi(plate);
            taxiLicences.Add(taxi);
            return taxi;
        }
        
        public void deleteLicense(string plate)
        {
            Taxi taxiToRemove = taxiLicences.Find(taxi => taxi.GetPlate() == plate);

            if (taxiToRemove != null)
            {
                taxiLicences.Remove(taxiToRemove);
                Console.WriteLine($"Taxi with plate {plate} has been removed.");
            }
            else
            {
                Console.WriteLine($"Taxi with plate {plate} not found.");
            }
        }
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}

