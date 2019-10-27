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
    public class DepttBussiness : DepttInter//Here implementation of interface
    {
        //These are definitions of interface
        EmployeeManagementEntities _db = new EmployeeManagementEntities();
        public DepttModel AddUpdateDeptt(DepttModel model)//Addupdate method
        {
            try
            {
                if (model.ID > 0)
                {
                    var record = _db.tblDepartments.OrderByDescending(x => x.ID).Where(x => x.ID == model.ID).FirstOrDefault();
                    record.Name = model.Name;
                    _db.SaveChanges();

                }
                else
                {
                    tblDepartment _department = new tblDepartment();
                    _department.Name = model.Name;
                    _db.tblDepartments.Add(_department);
                    _db.SaveChanges();
                    model.ID = _department.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        public bool DeleteDeptt(int id)//Delete method
        {
            bool isDeleted = false;
            try
            {
                var record = _db.tblDepartments.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.tblDepartments.Remove(record);
                _db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex)
            {

            }
            return isDeleted;
        }

        public List<DepttModel> GetDepttByID(int id)//fetching data by id
        {
            var record = new List<DepttModel>();
            try
            {
                record = (from a in _db.tblDepartments
                          where a.ID == id
                          select new DepttModel
                          {
                              ID = a.ID,
                              Name = a.Name,
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }

        public List<DepttModel> GetDeptts()//fetch all data
        {
            var list = new List<DepttModel>();
            try
            {
                list = (from a in _db.tblDepartments
                        select new DepttModel
                        {
                            ID = a.ID,
                            Name = a.Name,
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
