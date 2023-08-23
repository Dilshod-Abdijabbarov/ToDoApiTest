﻿using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.TaskBaseDTOs
{
    public class TaskBaseForCreationDTO
    {
        [Required]
        public string TaskName { get; set; }
        public DateTime? Remind_me { get; set; }
        public DateTime? Planned { get; set; }
        public bool? Important { get; set; }
        [Required]
        public bool FinishedTask { get; set; }
        public string? Note { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
