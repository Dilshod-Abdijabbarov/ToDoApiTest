using Data.IRepositories;
using Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AddDueDateRepositoryAsync : GenericRepositoryAsync<AddDueDate>,IAddDueDateRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public AddDueDateRepositoryAsync(DatabaseContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
