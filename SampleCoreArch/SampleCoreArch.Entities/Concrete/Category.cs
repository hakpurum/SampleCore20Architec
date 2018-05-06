using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Entities.Concrete
{
    [Serializable]
    [Table("Categories")]
    public sealed class Category : BaseEntity, IEntity
    {
        public Category()
        {
            ContentCategoryRelations = new HashSet<ContentCategoryRelation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Category Id is required")]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; } // int, not null

        [MaxLength(200)]
        [Required(ErrorMessage = "Category Name is required")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } // varchar(200), not null

        [MaxLength(500)]
        [Display(Name = "Seo Url")]
        public string SeoUrl { get; set; } // nvarchar(500), null

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int Status { get; set; } // int, not null

        [Required(ErrorMessage = "User Id is required")]
        [Display(Name = "User Id")]
        [ForeignKey("User")]
        public int UserId { get; set; } // int, not null

        public User User { get; set; }

        public ICollection<ContentCategoryRelation> ContentCategoryRelations { get; set; }
    }
}