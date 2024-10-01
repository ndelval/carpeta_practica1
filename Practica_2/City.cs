using System;
namespace Practice1
{
	public class City : IMessageWritter
	{
		private PoliceStation CityStation;
        private List<Taxi> taxiLicences;

		public City(PoliceStation argCityStation) // DUDA preguntar si es correcto pasar esto como argumento por que claro primero creo la police stationm y luego la cuidad
		{
			CityStation = argCityStation; // DUDA realmente no uso para nada a que ciudad esta asociada cada comisaria
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
        // DUDA Cuando tengo que eliminar licencias simplemente quito el taxi de mi lista o tengo que de alguna manera eliminar la existencia de ese objeto taxi?
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

