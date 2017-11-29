using SQLite;

namespace TaskManager.Models
{
    public abstract class BaseModel
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
    }
}
