using BookStore.Services.DataTransferObjects.Responses;

namespace BookStore.MVC.Models
{
    public class CardItem
    {
        public BookForAddToCard Book { get; set; }
        public int Quantity { get; set; }
    }
    public class ShoppingCardCollection
    {
        public List<CardItem> CardItems { get; set; } = new List<CardItem>();

        public void Add(CardItem cardItem)
        {
            var existing = CardItems.FirstOrDefault(b => b.Book.Id == cardItem.Book.Id);
            if (existing != null)
            {
                existing.Quantity += cardItem.Quantity;
            }
            else
            {
                CardItems.Add(cardItem);
            }
        }

        public decimal GetTotalPrice() => CardItems.Sum(b => b.Quantity * (b.Book.Price * (1 - b.Book.DiscountRate)));
        public int TotalQuantity { get => CardItems.Sum(b => b.Quantity); }

        public void Clear() => CardItems.Clear();
    }
}
