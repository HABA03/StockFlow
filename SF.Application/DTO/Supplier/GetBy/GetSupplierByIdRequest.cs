using MediatR;

namespace SF.Supplier.DTO.Supplier.GetBy
{
    public class GetSupplierByIdRequest : IRequest<GetSupplierByIdResponse>
    {
        public int Id { get; set; }
    }
}