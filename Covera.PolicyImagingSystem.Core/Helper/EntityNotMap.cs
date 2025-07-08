using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace Covera.PolicyImagingSystem.Core.Helper
{
    public abstract class EntityNotMap<T> : AuditedEntity<T>
    {
        [NotMapped]
        public override DateTime CreationTime { get; set; }
        [NotMapped]
        public override long? CreatorUserId { get; set; }
        [NotMapped]
        public override DateTime? LastModificationTime { get; set; }
        [NotMapped] 
        public override long? LastModifierUserId { get; set; }
    }
}
