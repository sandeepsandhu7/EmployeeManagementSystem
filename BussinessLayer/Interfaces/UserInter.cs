using BussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface UserInter//Interface for user
    {
        //These are method headings which will be define in bussiness folder
        bool LoginUser(UserModel model);
        List<UserModel> GetUsers();
        UserModel GetUserByID(int id);
        UserModel AddUpdateUser(UserModel model);
        bool DeleteUsers(int id);
    }
}
