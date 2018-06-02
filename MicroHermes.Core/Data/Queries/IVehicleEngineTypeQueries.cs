namespace MicroHermes.Core.Data.Queries
{
    public interface IVehicleEngineTypeQueries
    {
        int GetId(string value);
        string GetValue(int id);
    }
}