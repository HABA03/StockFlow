using AutoMapper;
using MediatR;
using SF.Application.DTO.Product.Get;
using SF.Domain.Interface;

namespace SF.Application.Handler.Product
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, List<GetProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductResponse>> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var productsInfo = await _productRepository.GetProducts(cancellationToken);

            if(productsInfo == null)
                throw new Exception("Error getting info");

            return _mapper.Map<List<GetProductResponse>>(productsInfo);
        }
    }
}