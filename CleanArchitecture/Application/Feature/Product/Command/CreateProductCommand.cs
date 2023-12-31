﻿using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Product.Command
{
    public class CreateProductCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }

        internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateProductCommandHandler(IApplicationDbContext applicationDbContext)
            {
                this._context = applicationDbContext;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Domain.Entities.Product();

                product.Name = request.Name;
                product.Description = request.Description;
                product.Rate = request.Rate;

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return product.ID;
            }
        }
    }
}
