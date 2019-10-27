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
    public class JobBussiness : JobInter//Here implementation of interface
    {
        //These are definitions of interface
        EmployeeManagementEntities _db = new EmployeeManagementEntities();
        public JobModel AddUpdateJobs(JobModel model)//Addupdate method
        {
            try
            {
                if (model.ID > 0)
                {
                    var record = _db.tblJobs.OrderByDescending(x => x.ID).Where(x => x.ID == model.ID).FirstOrDefault();
                    record.Job = model.Job;
                    record.MinSalary = model.MinSalary;
                    record.MaxSalary = model.MaxSalary;
                    _db.SaveChanges();

                }
                else
                {
                    tblJob _job = new tblJob();
                    _job.Job = model.Job;
                    _job.MinSalary = model.MinSalary;
                    _job.MaxSalary = model.MaxSalary;
                    _db.tblJobs.Add(_job);
                    _db.SaveChanges();
                    model.ID = _job.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }

        public bool DeleteJobs(int id)//Delete method
        {
            bool isDeleted = false;
            try
            {
                var record = _db.tblJobs.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.tblJobs.Remove(record);
                _db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex)
            {

            }
            return isDeleted;
        }

        public List<JobModel> GetJobByID(int id)//fetching data by id
        {
            var record = new List<JobModel>();
            try
            {
                record = (from a in _db.tblJobs
                          where a.ID == id
                          select new JobModel
                          {
                              ID = a.ID,
                              Job = a.Job,
                              MinSalary = a.MinSalary,
                              MaxSalary = a.MaxSalary
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }

        public List<JobModel> GetJobs()//fetch all data
        {
            var list = new List<JobModel>();
            try
            {
                list = (from a in _db.tblJobs
                        select new JobModel
                        {
                            ID = a.ID,
                            Job = a.Job,
                            MinSalary = a.MinSalary,
                            MaxSalary = a.MaxSalary
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
