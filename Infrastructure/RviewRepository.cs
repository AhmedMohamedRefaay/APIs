using ApiContext;
using Application.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RviewRepository : Repository<Review, int>, IReviewRepository
    {
    
public RviewRepository(DBContext context) : base(context)
        {
        }

        public Task<IEnumerable<Review>> FilterAsync()
        {
            throw new NotImplementedException();
        }
    }
}
