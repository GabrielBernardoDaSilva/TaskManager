using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Taskes
{


    public class List
    {
        public class Query : IRequest<List<Domain.Taskes>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Domain.Taskes>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {

                _context = context;
            }

            public async Task<List<Domain.Taskes>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var taskes = await _context.Taskes.ToListAsync();
                return taskes;

            }
        }
    }

}