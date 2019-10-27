using BussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface JobInter//Interface for job
    {
        //These are method headings which will be define in bussiness folder
        List<JobModel> GetJobs();
        List<JobModel> GetJobByID(int id);
        JobModel AddUpdateJobs(JobModel model);
        bool DeleteJobs(int id);
    }
}
