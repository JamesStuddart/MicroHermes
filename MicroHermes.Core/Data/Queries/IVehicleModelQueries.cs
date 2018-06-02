namespace MicroHermes.Core.Data.Queries
{
    public interface IVehicleModelQueries
    {
        int GetId(string value);
        string GetValue(int id);
    }
}