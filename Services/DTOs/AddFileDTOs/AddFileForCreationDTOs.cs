using Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.AddFileDTOs
{
    public class AddFileForCreationDTOs
    {
        public string FilePath { get; set; }
        public int TaskBaseId { get; set; }
    }
}
