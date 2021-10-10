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
        public static string med(medParams med)
        {
            string cmd = "SELECT med.id,name,lastname,middlename,phone,med.date,workers.id FROM Med FULL OUTER JOIN Workers ON med.workerid = Workers.id WHERE med.id > -1 ";
            if (med.onYear)
            {
                cmd += $"AND YEAR(med.date) = '{med.date.Year}' ";
            }
            if (med.phone.Trim().Length > 15)
            {
                cmd += $"AND Workers.phone LIKE N'%{med.phone.Trim()}%'";
            }
            if (med.whoHaveNot)
            {
                cmd = $"SELECT med.id,name,lastName,middleName,phone,med.date,Workers.Id from Workers FUll outer join MED ON med.WorkerID = Workers.Id;";
            }
            return cmd;
        }
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
            if (QP.sell)
            {
                cmd += $"AND (time < '{DateTime.Now.TimeOfDay}' OR startDate < '{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}') ";
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
            if (WP.phone.Trim().Length > 15)
            {
                cmd += $"AND phone LIKE N'%{WP.phone.Trim()}%'";
            }
            return cmd;
        }

        public static string trains(trainsParams tp)
        {
            string cmd = "SELECT * FROM Trains WHERE id > -1 ";
            if (tp.id.Trim() != string.Empty)
            {
                cmd += $" AND id = {tp.id} ";
            }
            if (tp.place != "Все")
            {
                cmd += $" AND connectToPlace = N'{tp.place}'";
            }
            if (tp.repBrigade != "Все")
            {
                cmd += $" AND repairBrigade = N'{tp.repBrigade}'";
            }
            if (tp.brigade != "Все")
            {
                cmd += $" AND brigade = N'{tp.brigade}'";
            }
            cmd += $" ORDER BY completed DESC";
            return cmd;
        }

        public static string users(userParams up)
        {
            string cmd = "SELECT * FROM Users WHERE id > -1 ";
            if (up.id != string.Empty)
            {
                cmd += $"AND id = {up.id} ";
            }
            if (up.email != string.Empty)
            {
                cmd += $"AND email LIKE N'%{up.email}%' ";
            }
            if (up.phone.Trim().Length > 15)
            {
                cmd += $"AND phone LIKE N'%{up.phone.Trim()}%' ";
            }
            return cmd;
        }
    }
}
