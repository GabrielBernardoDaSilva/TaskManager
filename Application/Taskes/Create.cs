using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Persistance;
using System.IO;

namespace Application.Taskes
{
    public class Create
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime SLA { get; set; }
            public string File { get; set; }
            public string Status { get; set; }

        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title)
                    .MaximumLength(200)
                    .NotEmpty();
                RuleFor(x => x.SLA)
                    .NotEmpty();
                RuleFor(x => x.File)
                    .NotEmpty();
                RuleFor(x => x.Status)
                    .NotEmpty();

            }


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

                string filePath = Path.Combine(_enviroment.ContentRootPath, "Upload", request.File);


                var task = new Domain.Taskes
                {
                    Title = request.Title,
                    SLA = request.SLA,
                    Filename = filePath,
                    Status = request.Status
                };

                _context.Add(task);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem in save changes");
            }
        }
    }
}