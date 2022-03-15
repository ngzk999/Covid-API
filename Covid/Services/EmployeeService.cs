using Covid.Data;
using Covid.Entities;
using Covid.Interfaces;

namespace Covid.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public bool InsertEmployeeData(EmployeeData employeeData)
        {
            _context.Add(employeeData);
            int numberOfWrittenEntry = _context.SaveChanges();
            return numberOfWrittenEntry > 0;
        }
    }
}
