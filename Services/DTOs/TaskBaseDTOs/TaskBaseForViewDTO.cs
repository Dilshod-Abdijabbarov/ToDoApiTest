using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.TaskBaseDTOs
{
    public class TaskBaseForViewDTO
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime? Remind_me { get; set; }
        public DateTime? Planned { get; set; }
        public bool? Important { get; set; }
        public bool FinishedTask { get; set; }
        public string? Note { get; set; }
        public DateTime CreateAt { get; set; }
        public int UserId { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<RepeatTime> RepeatTimes { get; set; }
        public ICollection<AddFile> AddFiles { get; set; }
        public ICollection<AddDueDate> AddDueDates { get; set; }

    }
}
