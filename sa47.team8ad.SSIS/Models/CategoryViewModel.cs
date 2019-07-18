namespace sa47.team8ad.SSIS.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
        }
        
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ItemViewModel> Items { get; set; }
    }
}
