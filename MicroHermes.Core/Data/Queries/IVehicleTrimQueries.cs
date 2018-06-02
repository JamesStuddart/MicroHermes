namespace MicroHermes.Core.Data.Queries
{
    public interface IVehicleTrimQueries
    {
        int GetId(string value);
        string GetValue(int id);
    }
}