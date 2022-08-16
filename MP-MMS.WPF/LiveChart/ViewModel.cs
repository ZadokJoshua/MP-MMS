using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MMS.WPF.LiveChart
{
    public class ViewModel
    {
        public List<Sales>  Data { get; set; }

        public ViewModel()
        {
            Data = new List<Sales>
            {
                new Sales { Year="2014",ProductA=300,ProductB=200},
                new Sales { Year="2015",ProductA=450,ProductB=500},
                new Sales {Year="2016",ProductA=400,ProductB=300},
                new Sales {Year="2017",ProductA=550,ProductB=500},
                new Sales {Year="2018",ProductA=650,ProductB=450}
            };
        
        }
    }
}
