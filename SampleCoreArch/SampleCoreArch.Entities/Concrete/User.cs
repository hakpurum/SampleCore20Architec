using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Entities.Concrete
{
    [Serializable]
    [Table("Users")]
    public sealed class User : BaseEntity, IEntity
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            ContentCategoryRelations = new HashSet<ContentCategoryRelation>();
            Contents = new HashSet<Content>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "User Id is required")]
        [Display(Name = "User Id")]
        public int UserId { get; set; } // int, not null

        [Required(ErrorMessage = "User Group Id is required")]
        [Display(Name = "User Group Id")]
        public int UserGroupId { get; set; } // int, not null

        [MaxLength(200)]
        [Required(ErrorMessage = "Name Surname is required")]
        [Display(Name = "Name Surname")]
        public string NameSurname { get; set; } // nvarchar(200), not null

        [MaxLength(100)]
        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; } // nvarchar(100), not null

        [MaxLength(200)]
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; } // nvarchar(200), not null

        [MaxLength(200)]
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; } // nvarchar(200), not null

        [MaxLength(500)]
        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; } // nvarchar(500), null

        [MaxLength(16)]
        [Display(Name = "Ip Adress")]
        public string IpAdress { get; set; } // varchar(16), null

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int Status { get; set; } // int, not null

        [MaxLength]
        [Display(Name = "Description")]
        public string Description { get; set; } // nvarchar(max), null

        public UserGroup UserGroup { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ContentCategoryRelation> ContentCategoryRelations { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}