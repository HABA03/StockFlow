using MediatR;

namespace SF.Supplier.DTO.Supplier.Update
{
    public class UpdateSupplierRequest : IRequest<UpdateSupplierResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
    }
}