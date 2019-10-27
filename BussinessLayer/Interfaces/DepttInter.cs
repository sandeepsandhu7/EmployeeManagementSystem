using BussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface DepttInter//Interface for department
    {
        //These are method headings which will be define in bussiness folder
        List<DepttModel> GetDeptts();
        List<DepttModel> GetDepttByID(int id);
        DepttModel AddUpdateDeptt(DepttModel model);
        bool DeleteDeptt(int id);
    }
}
