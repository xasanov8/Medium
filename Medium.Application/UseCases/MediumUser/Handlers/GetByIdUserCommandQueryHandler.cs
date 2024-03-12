using AutoMapper;
using MediatR;
using Medium.Application.Abstactions;
using Medium.Application.UseCases.MediumUser.Queries;
using Medium.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Handlers
{
    public class GetByIdUserCommandQueryHandler : IRequestHandler<GetByIdUserCommandQuery, User>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetByIdUserCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(GetByIdUserCommandQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.isDeleted != true);

            return user;
        }
    }
}
