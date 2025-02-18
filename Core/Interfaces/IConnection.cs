using Backend.Data;

namespace Backend.Core.Interfaces
{
    public interface IConnection
    {
        AppDbContext GetContext();
    }
}