using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class User
    {
        [Key]

        public int UId { get; set; }

        public string  UName { get; set; }

        public string  USex { get; set; }

        public string  UAge { get; set; }
    }
}
