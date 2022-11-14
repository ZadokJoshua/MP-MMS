using Microsoft.EntityFrameworkCore;
using MP_MMS.Data;
using MP_MMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.WPF.ChartResources
{
    public class ViewModel
    {
        public List<Issue> Issues { get; set; } = new List<Issue>();
        public List<IssuesHelper> Data { get; set; }
        int[] arrOfWorkOrders = new int[2];

        public ViewModel()
        {
            GetWO();
            Data = new List<IssuesHelper>()
            {
                new IssuesHelper{ Name="Completed", Count= arrOfWorkOrders[0]},
                new IssuesHelper{ Name="Incomplete", Count= arrOfWorkOrders[1]}
            };
        }

        private void GetWO()
        {
            int completeWO = 0;
            int incompleteWO = 0;
            using (MPMMSDbContext context = new())
            {
                Issues = context.Issues.ToList();
            }

            foreach(var issue in Issues)
            {
                if(issue.IsCompleted)
                {
                    completeWO++;
                }
                else 
                {
                    incompleteWO++;
                }
            }

            arrOfWorkOrders[0] = completeWO;
            arrOfWorkOrders[1] = incompleteWO;
        }
    }

}
