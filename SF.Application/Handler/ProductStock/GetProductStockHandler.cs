using AutoMapper;
using MediatR;
using SF.Application.DTO.ProductStock.Get;
using SF.Domain.Interface;

namespace SF.Application.Handler.ProductStock
{
    public class GetProductStockHandler : IRequestHandler<GetProductStockRequest, List<GetProductStockResponse>>
    {
        private readonly IProductStockRepository _productStockRepository;
        private readonly IMapper _mapper;

        public GetProductStockHandler(IProductStockRepository productStockRepository, IMapper mapper)
        {
            _productStockRepository = productStockRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductStockResponse>> Handle(GetProductStockRequest request, CancellationToken cancellationToken)
        {
            var productsStockInfo = await _productStockRepository.GetProductStocks(cancellationToken);

            if(productsStockInfo == null)
                throw new Exception("Error getting info");

            return _mapper.Map<List<GetProductStockResponse>>(productsStockInfo);
        }
    }
}