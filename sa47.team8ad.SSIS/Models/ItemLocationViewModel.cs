namespace sa47.team8ad.SSIS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class ItemLocationViewModel
    {
        public ItemLocationViewModel()
        {
            //Items = new HashSet<ItemViewModel>();
        }

        [Key]
        public int LocationId { get; set; }

        [Required]
        [StringLength(100)]
        public string LocationDesc { get; set; }

      //  public virtual ICollection<ItemViewModel> Items { get; set; }
    }
}
