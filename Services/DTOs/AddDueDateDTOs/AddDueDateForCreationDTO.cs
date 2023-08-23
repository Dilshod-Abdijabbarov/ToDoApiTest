using Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.AddDueDateDTOs
{
    public class AddDueDateForCreationDTO
    {
        public AddDueEnum FinishedTime { get; set; }
        public int TaskBaseId { get; set; }
    }
}
