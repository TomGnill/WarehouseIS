using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseIS_Base.Classes.Report;
using WarehouseIS_Base.Classes.Item;
using WarehouseIS_Base.Classes;
using WarehouseIS_Base.Classes.User;

namespace WarehouseIS_Base
{
    public static class DBsimulation
    {
        public static List<Report> Reports;
        public static List<Item> Items;
        public static List<Response> Responses;
        public static List<User> Users;

        static DBsimulation()
        {
            Reports = new List<Report>();
            Items = new List<Item>();
            Responses = new List<Response>();
            Users = new List<User>();
        }

        //public DBsimulation(List<Item> items)
        //{
        //    Reports = new List<Report>();
        //    Items = new List<Item>();
        //}
    }
}
