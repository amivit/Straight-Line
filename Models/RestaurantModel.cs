using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Models
{
    public class RestaurantModel
    {
        public static List<Table> TableList { get; set; }

        public RestaurantModel()
        {
            TableList = new List<Table>();
            for (int i = 0; i < 20; i++)
            {
                TableList.Add(new Table { Occupied = false, TableNumber = i + 1 });
            }
        }
    }

    public class Table
    {
        public int TableNumber { get; set; }
        public bool Occupied { get; set; }
    }
}