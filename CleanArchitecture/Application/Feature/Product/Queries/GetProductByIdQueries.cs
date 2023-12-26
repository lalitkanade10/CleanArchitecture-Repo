using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Product.Queries
{
    public class GetProductByIdQueries: IRequest<Domain.Entities.Product>
    {
        public int ID { get; set; }
        internal class GetProductByIdQueriesHandler : IRequestHandler<GetProductByIdQueries, Domain.Entities.Product>
        {
            private readonly IApplicationDbContext _context;
            public GetProductByIdQueriesHandler(IApplicationDbContext applicationDbContext)
            {
                this._context = applicationDbContext;
            }
            public async Task<Domain.Entities.Product> Handle(GetProductByIdQueries request, CancellationToken cancellationToken)
            {
                var result = await _context.Products.Where(x => x.ID==request.ID).FirstOrDefaultAsync(cancellationToken);
                return result;
            }
        }
    }
}
