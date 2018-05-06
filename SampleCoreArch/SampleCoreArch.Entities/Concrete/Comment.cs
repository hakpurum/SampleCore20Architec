using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Entities.Concrete
{
    [Serializable]
    [Table("Comments")]
    public sealed class Comment : BaseEntity, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Comment Id is required")]
        [Display(Name = "Comment Id")]
        public int CommentId { get; set; } // int, not null

        [Required(ErrorMessage = "Content Id is required")]
        [Display(Name = "Content Id")]
        public int ContentId { get; set; } // int, not null

        [Required(ErrorMessage = "User Id is required")]
        [Display(Name = "User Id")]
        public int UserId { get; set; } // int, not null

        [MaxLength(1000)]
        [Required(ErrorMessage = "Comment Text is required")]
        [Display(Name = "Comment Text")]
        public string CommentText { get; set; } // varchar(1000), not null

        [MaxLength(16)]
        [Required(ErrorMessage = "Ip Adress is required")]
        [Display(Name = "Ip Adress")]
        public string IpAdress { get; set; } // varchar(16), not null

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int Status { get; set; } // int, not null

        public Content Content { get; set; }
        public User User { get; set; }
    }
}