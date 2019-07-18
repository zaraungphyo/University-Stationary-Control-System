
namespace sa47.team8ad.SSIS.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CollectionPointId { get; set; }

        public string ContactName { get; set; }
        public string PhoneNo { get; set; }

        public string FaxNo { get; set; }
        public virtual CollectionPointViewModel CollectionPoint { get; set; }
    }
}