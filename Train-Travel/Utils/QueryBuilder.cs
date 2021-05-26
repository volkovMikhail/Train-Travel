using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_Travel.Utils;

namespace Train_Travel.Utils
{
    class QueryBuilder
    {
        public static string query(queryParams QP)
        {
            string cmd = "SELECT * FROM Voyage WHERE type LIKE N'%' ";
            if (QP.from != "Все")
            {
                cmd += $"AND fromPlace = N'{QP.from}' ";
            }
            if (QP.to != "Все")
            {
                cmd += $"AND toPlace = N'{QP.to}' ";
            }
            if (QP.DateSearch)
            {
                cmd += $"AND startDate = '{QP.startDate.Year}-{QP.startDate.Month}-{QP.startDate.Day}' ";
            }
            if (QP.startPrice != string.Empty)
            {
                cmd += $"AND price >= {QP.startPrice} ";
            }
            if (QP.endPrice != string.Empty)
            {
                cmd += $"AND price <= {QP.endPrice} ";
            }
            return cmd;
        }
    }
}
