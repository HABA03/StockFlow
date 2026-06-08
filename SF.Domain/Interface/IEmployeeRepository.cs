using SF.Domain.Entity;

namespace SF.Domain.Interface
{
    public interface IEmployeeRepository
    {
        Task<string> CreateEmployee(Employee employee, CancellationToken cancellationToken);
        Task<string> UpdateEmployee(Employee employee, CancellationToken cancellationToken);
        Task<Employee> GetEmployeeBy(int id, CancellationToken cancellationToken);
        Task<List<Employee>> GetEmployees(CancellationToken cancellationToken);
    }
}