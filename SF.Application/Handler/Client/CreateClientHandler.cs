using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Client.Create;
using SF.Domain.Interface;

namespace SF.Application.Handler.Client
{
    public class CreateClientHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateClientRequest> _validator;

        public CreateClientHandler(IClientRepository clientRepository, IMapper mapper, IValidator<CreateClientRequest> validator)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _clientRepository.CreateClient(_mapper.Map<Domain.Entity.Client>(request), cancellationToken);
            return new CreateClientResponse{ Response = response };
        }
    }
}