using BasicWebAPI.Models;

namespace BasicWebAPI.Interfaces
{
    public interface IEmployeeDataService
    {
        public List<EmployeeData> GetEmployeeDatas();
        public EmployeeData GetEmployeeDatas(int id);
        public EmployeeData AddEmployee(EmployeeData employeedata);
        public EmployeeData UpdateEmployee(EmployeeData employeedatas);
        public bool DeleteEmployee(int id);
    }
}
