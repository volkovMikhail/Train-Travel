using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Travel.Utils
{
    public struct queryParams
    {
        public bool DateSearch;
        public string from;
        public string to;
        public DateTime startDate;
        public string startPrice;
        public string endPrice;
    }

    public struct workersParams
    {
        public string otdel;
        public string brigada;
        public string phone;
        public bool med;
    }
}
