using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Product.Queries
{
    public class GetAllProductQueries:IRequest<IEnumerable<Domain.Entities.Product>>
    {
        internal class GetAllProductQueriesHandler : IRequestHandler<GetAllProductQueries, IEnumerable<Domain.Entities.Product>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductQueriesHandler(IApplicationDbContext applicationDbContext)
            {
                this._context = applicationDbContext;
            }
            public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductQueries request, CancellationToken cancellationToken)
            {
                var result = await _context.Products.ToListAsync(cancellationToken);
                return result;
            }
        }
    }

    
}
