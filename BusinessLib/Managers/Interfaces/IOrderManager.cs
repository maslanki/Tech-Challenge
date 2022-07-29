using BusinessLib.Models;
namespace BusinessLib.Managers.Interfaces
{
    public interface IOrderManager
    {
        Task<List<Order>> GetInProgressOrdersAsync();
        Task<List<Product>> GetTop5ProductsAsync(List<Order> orders = null);
    }
}
