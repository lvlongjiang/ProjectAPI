using bpmdemoapi.models;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication21.Models
{
    //业务表
    public class LeaveNew : BaseModels
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Day { get; set; }
    }
}
