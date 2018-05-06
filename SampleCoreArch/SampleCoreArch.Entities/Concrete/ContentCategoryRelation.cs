using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Entities.Concrete
{
    [Serializable]
    [Table("ContentCategoryRelations")]
    public sealed class ContentCategoryRelation : BaseEntity, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Relation Id is required")]
        [Display(Name = "Relation Id")]
        public int RelationId { get; set; } // int, not null

        [Required(ErrorMessage = "Content Id is required")]
        [Display(Name = "Content Id")]
        public int ContentId { get; set; } // int, not null

        [Required(ErrorMessage = "Category Id is required")]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; } // int, not null

        [Display(Name = "User Id")]
        public int? UserId { get; set; } // int, null

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int Status { get; set; } // int, not null


        public Content Content { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
    }
}