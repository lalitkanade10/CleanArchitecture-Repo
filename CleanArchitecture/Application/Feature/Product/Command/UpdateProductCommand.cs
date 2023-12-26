using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Product.Command
{
    public class UpdateProductCommand: IRequest<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }

        internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateProductCommandHandler(IApplicationDbContext applicationDbContext)
            {
                this._context = applicationDbContext;
            }
            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(x => x.ID == request.ID).FirstOrDefaultAsync();

                if(product !=null)
                {
                    product.Name = request.Name;
                    product.Description = request.Description;
                    product.Rate = request.Rate;

                    await _context.SaveChangesAsync();
                    return product.ID;
                }
                return default;                 
            }
        }
    }
}
