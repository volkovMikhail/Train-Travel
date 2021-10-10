using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Travel.Utils
{
    public class ids
    {
        public string id;
        public int workerId;
    }
    public struct medParams
    {
        public bool onYear;
        public bool whoHaveNot;
        public DateTime date;
        public string phone;
    }
    public struct queryParams
    {
        public bool DateSearch;
        public string from;
        public string to;
        public DateTime startDate;
        public string startPrice;
        public string endPrice;
        public bool sell;
    }

    public struct workersParams
    {
        public string otdel;
        public string brigada;
        public string phone;
    }

    public struct trainsParams
    {
        public string brigade;
        public string repBrigade;
        public string id;
        public string place;
    }

    public struct userParams
    {
        public string id;
        public string phone;
        public string email;
    }
}
