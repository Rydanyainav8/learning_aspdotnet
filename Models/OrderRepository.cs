namespace learning_aspdotnet.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ScratchShopAppDbContext _scratchShopAppDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(ScratchShopAppDbContext scratchShopAppDbContext, IShoppingCart shoppingCart)
        {
            _scratchShopAppDbContext = scratchShopAppDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            //ajout de commande avec leur details
            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems) 
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            _scratchShopAppDbContext.Orders.Add(order);
            _scratchShopAppDbContext.SaveChanges();
        }
    }
}
