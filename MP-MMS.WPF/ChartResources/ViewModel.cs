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
        public List<Issue> Issues { get; set; }
        public List<IssuesHelper> Data { get; set; }

        public ViewModel()
        {
            Data = new List<IssuesHelper>()
            {
                new IssuesHelper{ Name="Completed WO", Count=GetWO().Result[0]},
                new IssuesHelper{ Name="Incomplete WO", Count=GetWO().Result[1]}
            };
        }

        private async Task<int[]> GetWO()
        {
            int completeWO = 0;
            int incompleteWO = 0;
            int[] arrOfWorkOrders = new int[2];
            using (MPMMSDbContext context = new())
            {
                Issues = await context.Issues.ToListAsync();
            }

            foreach(var issue in Issues)
            {
                if(issue.IsCompleted == true)
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

            return arrOfWorkOrders;
        }
    }

}
