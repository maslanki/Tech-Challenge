using BusinessLib.Models;
namespace BusinessLib.Managers.Interfaces
{
    public interface IOrderManager
    {
        Task<List<Order>> GetInProgressOrdersAsync();
        Task<List<Product>> GetTop5Products(List<Order> orders = null);
    }
}
