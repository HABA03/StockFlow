using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SF.Domain.Entity;
using SF.Domain.Interface;
using SF.Infrastructure.Context;

namespace SF.Infrastructure.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SFContext _context;

        public EmployeeRepository(SFContext context)
        {
            _context = context;
        }

        public async Task<string> CreateEmployee(Employee employee, CancellationToken cancellationToken)
        {
            if(employee == null)
                throw new Exception("Employee is null");

            employee.CreatedDate = DateTime.UtcNow;
            employee.IsActive = true;

            var passwordHasher = new PasswordHasher<Employee>();
            employee.PasswordHash = passwordHasher.HashPassword(employee, employee.PasswordHash);

            await _context.Employee.AddAsync(employee, cancellationToken);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Employee created" : "Error creating employee";
        }

        public async Task<Employee> GetEmployeeBy(int id, CancellationToken cancellationToken)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.Id == id, cancellationToken)?? new Employee();
        }

        public async Task<List<Employee>> GetEmployees(CancellationToken cancellationToken)
        {
            return await _context.Employee.Where(e => e.IsActive).ToListAsync(cancellationToken);
        }

        public async Task<string> UpdateEmployee(Employee employee, CancellationToken cancellationToken)
        {
            if(employee == null)
                throw new Exception("Employee is null");

            employee.IsActive = true;
            employee.UpdatedDate = DateTime.UtcNow;
            _context.Employee.Update(employee);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Employee updated" : "Error updating employee";
        }
    }
}