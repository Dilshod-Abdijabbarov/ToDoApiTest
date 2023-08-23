using Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RepeatTimeDTOs
{
    public class RepeatTimeForCreationDTO
    {
        public int Nummer { get; set; }
        public RepeatEnum AddDateTime { get; set; }
        public int TaskBaseId { get; set; }
    }
}
