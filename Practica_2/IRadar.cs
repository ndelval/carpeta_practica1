using Practice1;

public interface IRadar
{
    void TriggerRadar(Vehicle vehicle);
    (string, bool) GetLastReading();
}