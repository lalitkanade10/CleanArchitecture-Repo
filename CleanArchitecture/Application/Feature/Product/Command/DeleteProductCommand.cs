using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Product.Command
{
    public class DeleteProductCommand: IRequest<int>
    {
        public int ID { get; set; }
      

        internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public DeleteProductCommandHandler(IApplicationDbContext applicationDbContext)
            {
                this._context = applicationDbContext;
            }
            public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(x => x.ID == request.ID).FirstOrDefaultAsync();

                if (product == null)
                {
                    return default;                   
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product.ID;

            }
        }
    }
}
