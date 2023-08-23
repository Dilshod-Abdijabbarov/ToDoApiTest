using Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.CategoryDTOs
{
    public class CategoryForViewDTO
    {
        public int Id { get; set; }
        public CategoryEnum AddDateTime { get; set; }
        public int TaskBaseId { get; set; }
    }
}
