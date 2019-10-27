using BussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface EmployeeInter//Interface for employee
    {
        //These are method headings which will be define in bussiness folder
        List<EmployeeModel> GetEmp();
        List<EmployeeModel> GetEmpByID(int id);
        EmployeeModel AddUpdateEmp(EmployeeModel model);
        bool DeleteEmp(int id);
    }
}
