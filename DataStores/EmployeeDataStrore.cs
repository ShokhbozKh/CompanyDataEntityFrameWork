using CompanyData.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CompanyData.DataStores
{
    public class EmployeeDataStrore
    {
        private readonly CompanyEntities _companyEntities;

        public EmployeeDataStrore()
        {
            _companyEntities = new CompanyEntities();
        }

        public List<emp> GetAllEmployee()
        {
            var resultEmp = _companyEntities.emp.ToList();

            return resultEmp;
        }
        public void CreateEmployee(emp newEmployee)
        {
            _companyEntities.emp.Add(newEmployee);
            _companyEntities.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            var employee = _companyEntities.emp.FirstOrDefault(x=>x.empno == id);
            if(employee is null)
            {
                return;
            }
            _companyEntities.emp.Remove(employee);
            _companyEntities.SaveChanges();
        }

        public void UptadeEmployee(emp editEmployee)
        {
            //Edit data
            //_companyEntities.emp.AddOrUpdate(editEmployee);
            _companyEntities.emp.Attach(editEmployee);
            _companyEntities.SaveChanges();
        }
        public emp GetEmployeeById(int id)
        {
            var resultData = _companyEntities.emp.Where(x => x.empno == id).FirstOrDefault();
            return resultData;
           // return _companyEntities.emp.Find(id);
        }
        public List<emp> GetEmployeeByName(string name)
        {
            return _companyEntities.emp.Where(x => x.ename.Contains(name)).ToList();
        }
        public List<emp> SearchEmployee(string searchTerm)
        {
            var resultData = _companyEntities.emp.Where(x => x.ename.Contains(searchTerm) ||
            x.job.Contains(searchTerm)).ToList();
            return resultData;
        }
    }
}
