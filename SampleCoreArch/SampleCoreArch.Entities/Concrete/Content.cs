using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Entities.Concrete
{
    [Serializable]
    [Table("Contents")]
    public sealed class Content : BaseEntity, IEntity
    {
        public Content()
        {
            Comments = new HashSet<Comment>();
            ContentCategoryRelations = new HashSet<ContentCategoryRelation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Content Id is required")]
        [Display(Name = "Content Id")]
        public int ContentId { get; set; } // int, not null

        [MaxLength(500)]
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; } // nvarchar(500), not null

        [MaxLength]
        [Display(Name = "Content Text")]
        public string ContentText { get; set; } // nvarchar(max), null

        [MaxLength]
        [Display(Name = "Content Spot Text")]
        public string ContentSpotText { get; set; } // nvarchar(max), null

        [MaxLength(500)]
        [Display(Name = "Seo Url")]
        public string SeoUrl { get; set; } // nvarchar(500), null

        [MaxLength(500)]
        [Display(Name = "Keywords")]
        public string Keywords { get; set; } // nvarchar(500), null

        [MaxLength(1000)]
        [Display(Name = "Description")]
        public string Description { get; set; } // nvarchar(1000), null

        [Required(ErrorMessage = "Rating is required")]
        [Display(Name = "Rating")]
        public int Rating { get; set; } // int, not null

        [Required(ErrorMessage = "Views is required")]
        [Display(Name = "Views")]
        public int Views { get; set; } // int, not null

        [Required(ErrorMessage = "User Id is required")]
        [Display(Name = "User Id")]
        public int UserId { get; set; } // int, not null

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int Status { get; set; } // int, not null

        [Display(Name = "Sorting")]
        public int? Sorting { get; set; } // int, null

        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ContentCategoryRelation> ContentCategoryRelations { get; set; }
    }
}