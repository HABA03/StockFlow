using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Client.Update;
using SF.Domain.Interface;

namespace SF.Application.Handler.Client
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateClientRequest> _validator;

        public UpdateClientHandler(IClientRepository clientRepository, IMapper mapper, IValidator<UpdateClientRequest> validator)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _clientRepository.UpdateClient(_mapper.Map<Domain.Entity.Client>(request), cancellationToken);
            return new UpdateClientResponse{ Response = response };
        }
    }
}