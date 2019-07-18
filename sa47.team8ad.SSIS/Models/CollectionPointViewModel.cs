namespace sa47.team8ad.SSIS.Models
{
    public class CollectionPointViewModel
    {

        public CollectionPointViewModel()
        {
           // Departments = new HashSet<DepartmentViewModel>();
        }

        public int CollectionPointId { get; set; }


        public string CollectionPointAddress { get; set; }


        public string CollectionTime { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DepartmentViewModel> Departments { get; set; }
    }
}