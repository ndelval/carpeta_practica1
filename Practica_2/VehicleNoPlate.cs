using Practice1;

public class VehicleNoPlate : Vehicle
{
    public VehicleNoPlate(string typeOfVehicle) : base(typeOfVehicle)
    {
        
    }

    public override string GetPlate()
    {
        return "No Plate"; 
    }
}