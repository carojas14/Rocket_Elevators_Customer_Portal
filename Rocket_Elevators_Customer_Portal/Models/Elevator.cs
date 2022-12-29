namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Elevator
    {

        public int id { get; set; }
        public string? elevator_status { get; set; }
        public int column_id { get; set; }
        public string? model { get; set; }
        public DateTime? date_last_inspection { get; set; }
    }
}
