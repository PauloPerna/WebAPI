using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
        public bool IsValid => !Messages.Any();
    }
}