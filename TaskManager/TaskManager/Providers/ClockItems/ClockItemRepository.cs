using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using TaskManager.Models;
using TaskManager.Enums;

namespace TaskManager.Providers
{
    public class ClockItemRepository : Repository<ClockItem>, IClockItemRepository
    {
        public ClockItemRepository(SQLiteAsyncConnection context) : base(context) { }

        public SQLiteAsyncConnection Context
        {
            get { return this.context as SQLiteAsyncConnection; }
        }

        public IEnumerable<ClockItem> GetAMItemsAsync() => amHoursClockItems;
        
        public IEnumerable<ClockItem> GetPMItemsAsync() => pmHoursClockItems;
        
        public IEnumerable<ClockItem> GetMinsItemsAsync() => minsClockItems;

        private IList<ClockItem> amHoursClockItems = new List<ClockItem>()
        {
            new ClockItem
            {
                Id = 1,
                InnerText = "1",
                Angle = 300.0
            },
            new ClockItem
            {
                Id = 2,
                InnerText = "2",
                Angle = 330.0
            },
            new ClockItem
            {
                Id = 3,
                InnerText = "3",
                Angle = 360.0
            },
            new ClockItem
            {
                Id = 4,
                InnerText = "4",
                Angle = 30.0
            },
            new ClockItem
            {
                Id = 5,
                InnerText = "5",
                Angle = 60.0
            },
            new ClockItem
            {
                Id = 6,
                InnerText = "6",
                Angle = 90.0
            },
            new ClockItem
            {
                Id = 7,
                InnerText = "7",
                Angle = 120.0
            },
            new ClockItem
            {
                Id = 8,
                InnerText = "8",
                Angle = 150.0
            },
            new ClockItem
            {
                Id = 9,
                InnerText = "9",
                Angle = 180.0
            },
            new ClockItem
            {
                Id = 10,
                InnerText = "10",
                Angle = 210.0
            },
            new ClockItem
            {
                Id = 11,
                InnerText = "11",
                Angle = 240.0
            },
            new ClockItem
            {
                Id = 12,
                InnerText = "12",
                Angle = 270.0
            }
        };

        private IList<ClockItem> pmHoursClockItems = new List<ClockItem>()
        {
            new ClockItem
            {
                Id = 1,
                InnerText = "13",
                Angle = 300.0
            },
            new ClockItem
            {
                Id = 2,
                InnerText = "14",
                Angle = 330.0
            },
            new ClockItem
            {
                Id = 3,
                InnerText = "15",
                Angle = 360.0
            },
            new ClockItem
            {
                Id = 4,
                InnerText = "16",
                Angle = 30.0
            },
            new ClockItem
            {
                Id = 5,
                InnerText = "17",
                Angle = 60.0
            },
            new ClockItem
            {
                Id = 6,
                InnerText = "18",
                Angle = 90.0
            },
            new ClockItem
            {
                Id = 7,
                InnerText = "19",
                Angle = 120.0
            },
            new ClockItem
            {
                Id = 8,
                InnerText = "20",
                Angle = 150.0
            },
            new ClockItem
            {
                Id = 9,
                InnerText = "21",
                Angle = 180.0
            },
            new ClockItem
            {
                Id = 10,
                InnerText = "22",
                Angle = 210.0
            },
            new ClockItem
            {
                Id = 11,
                InnerText = "23",
                Angle = 240.0
            },
            new ClockItem
            {
                Id = 12,
                InnerText = "24",                    
                Angle = 270.0
            }
        };

        private IList<ClockItem> minsClockItems = new List<ClockItem>()
        {
            new ClockItem
            {
                Id = 1,
                InnerText = "5",
                Angle = 300.0
            },
            new ClockItem
            {
                Id = 2,
                InnerText = "10",
                Angle = 330.0
            },
            new ClockItem
            {
                Id = 3,
                InnerText = "15",
                Angle = 360.0
            },
            new ClockItem
            {
                Id = 4,
                InnerText = "20",
                Angle = 30.0
            },
            new ClockItem
            {
                Id = 5,
                InnerText = "25",
                Angle = 60.0
            },
            new ClockItem
            {
                Id = 6,
                InnerText = "30",
                Angle = 90.0
            },
            new ClockItem
            {
                Id = 7,
                InnerText = "35",
                Angle = 120.0
            },
            new ClockItem
            {
                Id = 8,
                InnerText = "40",
                Angle = 150.0
            },
            new ClockItem
            {
                Id = 9,
                InnerText = "45",
                Angle = 180.0
            },
            new ClockItem
            {
                Id = 10,
                InnerText = "50",
                Angle = 210.0
            },
            new ClockItem
            {
                Id = 11,
                InnerText = "55",
                Angle = 240.0
            },
            new ClockItem
            {
                Id = 12,
                InnerText = "0",
                Angle = 270.0
            }
        };
    }
}
