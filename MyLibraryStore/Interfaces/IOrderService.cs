using MyLibraryStore.Dto;
using System.Collections.Generic;

namespace MyLibraryStore.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(int userId, OrdersDto orderDetails);
        List<OrdersDto> GetOrderList(int userId);
    }
}
