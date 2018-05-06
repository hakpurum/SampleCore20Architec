using System;
using System.ComponentModel.DataAnnotations;

namespace SampleCoreArch.Entities
{
    public abstract class BaseEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UpdateDate { get; set; }
    }
}