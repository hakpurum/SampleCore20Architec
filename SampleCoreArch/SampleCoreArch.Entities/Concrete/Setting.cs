using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Entities.Concrete
{
    [Serializable]
    [Table("Settings")]
    public sealed class Setting : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Setting Id is required")]
        [Display(Name = "Setting Id")]
        public int SettingId { get; set; } // int, not null

        [MaxLength(200)]
        [Required(ErrorMessage = "Page Title is required")]
        [Display(Name = "Page Title")]
        public string PageTitle { get; set; } // nvarchar(200), not null

        [MaxLength(200)]
        [Required(ErrorMessage = "Page Name is required")]
        [Display(Name = "Page Name")]
        public string PageName { get; set; } // nvarchar(200), not null

        [MaxLength(500)]
        [Display(Name = "Keywords")]
        public string Keywords { get; set; } // nvarchar(500), null

        [MaxLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; } // nvarchar(500), null

        [MaxLength(500)]
        [Display(Name = "Theme")]
        public string Theme { get; set; } // nvarchar(500), null

        [MaxLength(500)]
        [Display(Name = "Analystic")]
        public string Analystic { get; set; } // nvarchar(500), null
    }
}