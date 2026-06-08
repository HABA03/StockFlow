namespace SF.Application.DTO.ProductStock.GetBy
{
    public class GetProductStockByIdResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
    }
}