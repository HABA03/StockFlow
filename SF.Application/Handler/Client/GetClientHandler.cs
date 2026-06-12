using AutoMapper;
using MediatR;
using SF.Application.DTO.Client.Get;
using SF.Domain.Interface;

namespace SF.Application.Handler.Client
{
    public class GetClientHandler : IRequestHandler<GetClientRequest, List<GetClientResponse>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<List<GetClientResponse>> Handle(GetClientRequest request, CancellationToken cancellationToken)
        {
            var response = await _clientRepository.GetClients(cancellationToken);

            return _mapper.Map<List<GetClientResponse>>(response);
        }
    }
}