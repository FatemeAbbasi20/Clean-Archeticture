using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.Shared
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreationTime = DateTime.Now;
        }

        public long Id { get; private set; }
        public DateTime CreationTime { get; }
    }
}
