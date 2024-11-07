using EFCoreDatabaseFirstWinDemo.Models;

namespace EFCoreDatabaseFirstWinDemo.Services
{
    public interface IOrderService
    {
        void SaveOrder(Order order);
    }
}