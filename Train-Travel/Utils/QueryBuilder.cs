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

        public static string workers(workersParams WP)
        {
            string cmd = "SELECT * FROM Workers WHERE name LIKE N'%' ";
            if (WP.otdel != "Все")
            {
                cmd += $"AND otdel = N'{WP.otdel}' ";
            }
            if (WP.brigada != "Все")
            {
                cmd += $"AND brigada = N'{WP.brigada}' ";
            }
            if (WP.med)
            {
                DateTime date = DateTime.Now.AddYears(-1);
                cmd += $"AND medDate < '{date.Year}-{date.Month}-{date.Day}' ";
            }
            if (WP.phone.Trim().Length > 15)
            {
                cmd += $"AND phone LIKE N'%{WP.phone.Trim()}%'";
            }
            return cmd;
        }
    }
}
