using MediatR;

namespace SF.Application.DTO.Employee.GetBy
{
    public class GetEmployeeByIdRequest : IRequest<GetEmployeeByIdResponse>
    {
        public int Id { get; set; }
    }
}