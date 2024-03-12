using AutoMapper;
using MediatR;
using Medium.Application.Abstactions;
using Medium.Application.UseCases.MediumUser.Commands;
using Medium.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Handlers
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        protected async override Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
