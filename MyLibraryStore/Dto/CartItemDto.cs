using MyLibraryStore.Models;

namespace MyLibraryStore.Dto
{
    public class CartItemDto
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
