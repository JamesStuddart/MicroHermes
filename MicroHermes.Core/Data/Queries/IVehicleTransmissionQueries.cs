namespace MicroHermes.Core.Data.Queries
{
    public interface IVehicleTransmissionQueries
    {
        int GetId(string value);
        string GetValue(int id);
    }
}