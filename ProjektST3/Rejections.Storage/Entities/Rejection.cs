using Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejections.Storage.Entities
{
    public class Rejection : BaseEntity
    {
        public int Rejectee { get; set; }
        public int Rejected { get; set; }
    }
}
