using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Persistance;

namespace Application.FileUpload
{
    public class Add
    {
        public class Command : IRequest
        {
            public IFormFile File { get; set; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IWebHostEnvironment _enviroment;

            public Handler(DataContext context, IWebHostEnvironment enviroment)
            {
                _context = context;
                _enviroment = enviroment;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                
                string filePath = Path.Combine(_enviroment.ContentRootPath, "Upload", request.File.FileName);
                if (request.File != null)
                {
                    using (Stream filesStream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.File.CopyToAsync(filesStream);
                    }
                }


                return Unit.Value;

                
            }
        }
    }
}