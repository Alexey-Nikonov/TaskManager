using System;
using SQLite;

namespace TaskManager.Models
{
    public class ClockItem : BaseModel
    {
        private const double HALF_CIRCLE = 180.0;
        
        public string InnerText { get; set; }

        private double angle;
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
        
        public string Type { get; set; }

        private double ConvertToDegrees(double value)
        {
            return Math.PI * value / HALF_CIRCLE;
        }
    }
}
