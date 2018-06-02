namespace MicroHermes.Core.Data.Queries
{
    public interface IVehicleInteriorColorQueries
    {
        int GetId(string value);
        string GetValue(int id);
    }
}