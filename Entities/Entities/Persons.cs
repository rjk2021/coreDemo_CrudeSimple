using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Persons
    {

        public int Id { get; set; }


        public string UserName { get; set; }


        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;


        public bool IsDeleted { get; set; } = false;

    }
}
