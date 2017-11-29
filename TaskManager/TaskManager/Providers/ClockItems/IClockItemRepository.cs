using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManager.Models;

namespace TaskManager.Providers
{
    public interface IClockItemRepository : IRepository<ClockItem>
    {
        IEnumerable<ClockItem> GetAMItemsAsync();
        IEnumerable<ClockItem> GetPMItemsAsync();
        IEnumerable<ClockItem> GetMinsItemsAsync();
    }
}
