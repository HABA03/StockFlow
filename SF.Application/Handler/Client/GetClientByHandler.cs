using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Client.GetBy;
using SF.Domain.Interface;

namespace SF.Application.Handler.Client
{
    public class GetClientByHandler : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetClientByIdRequest> _validator;

        public GetClientByHandler(IClientRepository clientRepository, IMapper mapper, IValidator<GetClientByIdRequest> validator)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _clientRepository.GetClientBy(request.Id, cancellationToken);
            return _mapper.Map<GetClientByIdResponse>(response);
        }
    }
}