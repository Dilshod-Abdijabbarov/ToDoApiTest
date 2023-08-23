using Data.IRepositories;
using Domian.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AddFileRepositoryAsync : GenericRepositoryAsync<AddFile>,IAddFileRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public AddFileRepositoryAsync(DatabaseContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
