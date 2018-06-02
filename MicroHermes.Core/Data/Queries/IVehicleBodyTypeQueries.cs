namespace MicroHermes.Core.Data.Queries
{
    public interface IVehicleBodyTypeQueries
    {
        int GetId(string value);
        string GetValue(int id);
    }
}