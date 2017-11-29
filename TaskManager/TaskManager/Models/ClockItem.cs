using System;
using SQLite;

namespace TaskManager.Models
{
    [Table("clock_items")]
    public class ClockItem : BaseModel
    {
        private const double HALF_CIRCLE = 180.0;
        
        [Column("inner_text")]
        public string InnerText { get; set; }

        private double angle;
        [Column("angle")]
        public double Angle
        {
            get { return angle; }
            set
            {
                double newValue = ConvertToDegrees(value);

                if (angle != newValue)
                {
                    angle = newValue;
                }
            }
        }

        [Column("type")]
        public string Type { get; set; }

        private double ConvertToDegrees(double value)
        {
            return Math.PI * value / HALF_CIRCLE;
        }
    }
}
