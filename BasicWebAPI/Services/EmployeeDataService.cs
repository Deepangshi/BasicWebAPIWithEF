using BasicWebAPI.Context;
using BasicWebAPI.Interfaces;
using BasicWebAPI.Models;

namespace BasicWebAPI.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly APIDbContext _apidbContext;
        public EmployeeDataService(APIDbContext apidbContext)
        {
            _apidbContext = apidbContext;
        }
        public EmployeeData AddEmployee(EmployeeData employeedata)
        {
           var empd = _apidbContext.EmployeeDatas.Add(employeedata);
           _apidbContext.SaveChanges();
           return empd.Entity;
        }

        public bool DeleteEmployee(int id)
        {
            try {
                var empd = _apidbContext.EmployeeDatas.SingleOrDefault(s => s.EmployeeDataId == id);
                if (empd == null)
                    throw new Exception("user not found");
                else
                {
                    _apidbContext.EmployeeDatas.Remove(empd);
                    _apidbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<EmployeeData> GetEmployeeDatas()
        {
            var empdatas = _apidbContext.EmployeeDatas.ToList();
            return empdatas;
        }

        public EmployeeData GetEmployeeDatas(int id)
        {
            var empd = _apidbContext.EmployeeDatas.SingleOrDefault(s => s.EmployeeDataId == id);
            return empd;
        }

        public EmployeeData UpdateEmployee(EmployeeData employeedatas)
        {
            var updated = _apidbContext.EmployeeDatas.Update(employeedatas);
            _apidbContext.SaveChanges();
            return updated.Entity;
        }
    }
}
