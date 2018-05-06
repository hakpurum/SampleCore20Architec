using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Entities.Concrete
{
    [Serializable]
    [Table("UserGroups")]
    public sealed class UserGroup : BaseEntity, IEntity
    {
        public UserGroup()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "User Group Id is required")]
        [Display(Name = "User Group Id")]
        public int UserGroupId { get; set; } // int, not null

        [MaxLength(200)]
        [Required(ErrorMessage = "Group Name is required")]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; } // nvarchar(200), not null

        [Required(ErrorMessage = "Group Type is required")]
        [Display(Name = "Group Type")]
        public int GroupType { get; set; } // int, not null

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public int Status { get; set; } // int, not null

        [Required(ErrorMessage = "Create Date is required")]
        public new DateTime? UpdateDate { get; set; } // datetime, null

        public ICollection<User> Users { get; set; }
    }
}