using AutoMapper;
using MediatR;
using SF.Domain.Interface;
using SF.Supplier.DTO.Supplier.Get;

namespace SF.Application.Handler.Supplier
{
    public class GetSupplierHandler : IRequestHandler<GetSupplierRequest, List<GetSupplierResponse>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<List<GetSupplierResponse>> Handle(GetSupplierRequest request, CancellationToken cancellationToken)
        {
            var suppliersInfo = await _supplierRepository.GetSuppliers(cancellationToken);

            if(suppliersInfo == null)
                throw new Exception("Error getting info");

            return _mapper.Map<List<GetSupplierResponse>>(suppliersInfo);
        }
    }
}