using System;
using SQLite;

namespace TaskManager.Models
{
    [Table("todo_items")]
    public class TodoItem : BaseModel
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
                
        [Column("date")]
        public DateTime Date { get; set; }

        [Column("time")]
        public TimeSpan Time { get; set; }

        public TodoItem ShallowCopy()
        {
            return (TodoItem)this.MemberwiseClone();
        }
    }
}
