namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Battery
    {

        public int id { get; set; }
        public string? status { get; set; }
        public int building_id { get; set; }
        public DateTime? date_last_inspection { get; set; }
        public string? battery_type { get; set; }
        public string? information { get; set; }
        public string? notes { get; set; }
    }
}
