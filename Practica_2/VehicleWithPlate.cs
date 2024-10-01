using Practice1;

public class VehicleWithPlate : Vehicle
{
    private string plate;

    public VehicleWithPlate(string typeOfVehicle, string plate) : base(typeOfVehicle)
    {
        this.plate = plate;
    }

    public override string GetPlate()
    {
        return plate;
    }
}