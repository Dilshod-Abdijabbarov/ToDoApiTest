using Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.AddFileDTOs
{
    public class AddFileForViewDTOs
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int TaskBaseId { get; set; }
    }
}
