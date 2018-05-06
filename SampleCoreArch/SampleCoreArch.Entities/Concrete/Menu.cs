using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Entities.Concrete
{
    [Serializable]
    [Table("Menus")]
    public sealed class Menu : BaseEntity, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Menu Id is required")]
        [Display(Name = "Menu Id")]
        public int MenuId { get; set; } // int, not null

        [Required(ErrorMessage = "Parent Menu Id is required")]
        [Display(Name = "Parent Menu Id")]
        public int ParentMenuId { get; set; } // int, not null

        [MaxLength(200)]
        [Required(ErrorMessage = "Menu Name is required")]
        [Display(Name = "Menu Name")]
        public string MenuName { get; set; } // varchar(200), not null

        [MaxLength(500)]
        [Display(Name = "Seo Url")]
        public string SeoUrl { get; set; } // nvarchar(500), null

        [Required(ErrorMessage = "User Id is required")]
        [Display(Name = "User Id")]
        public int UserId { get; set; } // int, not null

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int Status { get; set; } // int, not null

        [MaxLength(500)]
        [Display(Name = "Alternative Link")]
        public string AlternativeLink { get; set; } // nvarchar(500), null

        [Display(Name = "Is Alternative Link")]
        public bool? IsAlternativeLink { get; set; } // bit, null
    }
}