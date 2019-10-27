using BussinessLayer.Interfaces;
using BussinessLayer.Model;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Bussiness
{
    public class UserBussiness : UserInter//Here implementation of interface
    {
        //These are definitions of interface
        EmployeeManagementEntities _db = new EmployeeManagementEntities();
        public UserModel AddUpdateUser(UserModel model)//Addupdate method
        {
            try
            {
                if (model.ID > 0)
                {
                    var record = _db.tblUsers.OrderByDescending(x => x.ID).Where(x => x.ID == model.ID).FirstOrDefault();
                    record.Name = model.Name;
                    record.Password = model.Password;
                    _db.SaveChanges();

                }
                else
                {
                    tblUser _user = new tblUser();
                    _user.Name = model.Name;
                    _user.Password = model.Password;
                    _db.tblUsers.Add(_user);
                    _db.SaveChanges();
                    model.ID = _user.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        public bool DeleteUsers(int id)//Delete method
        {
            bool isDeleted = false;
            try
            {
                var record = _db.tblUsers.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.tblUsers.Remove(record);
                _db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex)
            {

            }
            return isDeleted;
        }

        public UserModel GetUserByID(int id)//fetching data by id
        {
            var record = new UserModel();
            try
            {
                record = (from a in _db.tblUsers
                          where a.ID == id
                          select new UserModel
                          {
                              ID = a.ID,
                              Name = a.Name,
                              Password = a.Password
                          }).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return record;
        }

        public List<UserModel> GetUsers()//fetch all data
        {
            var list = new List<UserModel>();
            try
            {
                list = (from a in _db.tblUsers
                        select new UserModel
                        {
                            ID = a.ID,
                            Name = a.Name,
                            Password = a.Password
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public bool LoginUser(UserModel model)
        {
            bool isLogin = false;
            try
            {
                var record = (from a in _db.tblUsers
                              where a.Name == model.Name && a.Password == model.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isLogin = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isLogin;
        }
    }
}
