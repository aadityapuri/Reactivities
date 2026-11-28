using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
    public class CreateActivity
    {
        public class Commands : IRequest<string>
        {
            public required Activity Activity {get; set;}
        }

        public class Handler(AppDbContext context) : IRequestHandler<Commands, string>
        {
            public async Task<string> Handle(Commands request, CancellationToken cancellationToken)
            {
                context.Activities.Add(request.Activity);

                await context.SaveChangesAsync(cancellationToken);

                return request.Activity.Id;
            }
        }
    }
}