namespace MicroHermes.Core.Data.Queries
{
    public interface IVehicleExteriorColorQueries
    {
        int GetId(string value);
        string GetValue(int id);
    }
}