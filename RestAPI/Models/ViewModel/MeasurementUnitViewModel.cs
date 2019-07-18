namespace RestAPI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MeasurementUnitViewModel
    {
        public MeasurementUnitViewModel()
        {
        }
        
        public int UnitId { get; set; }
        
        public string UnitName { get; set; }

        public int UnitQuantity { get; set; }
        
    }
}
