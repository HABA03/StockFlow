using MediatR;

namespace SF.Supplier.DTO.Supplier.Create
{
    public class CreateSupplierRequest : IRequest<CreateSupplierResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
    }
}