using System.Collections.Generic;

namespace Rocket_Elevators_Customer_Portal.Models
{
    public class Building
    {

        public int id { get; set; }
        public string? addressBuilding { get; set; }
        public string? FullNameBuildingAdmin { get; set; }
        public string? EmailAdminBuilding { get; set; }
        public int? customer_id { get; set; }

    }
}
