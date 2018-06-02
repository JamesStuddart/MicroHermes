namespace MicroHermes.Core.Data.Queries
{
    public interface IVehicleMakeQueries
    {
        int GetId(string value);
        string GetValue(int id);
    }
}