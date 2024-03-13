using AutoMapper;
using MediatR;
using Medium.Application.Abstactions;
using Medium.Application.UseCases.MediumUser.Commands;
using Medium.Domain.Entities.DTOs;
using Medium.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.isDeleted != true);
        
            if (user is not null)
            {
                user.ModifiedDate = DateTime.UtcNow;
                user.Name = request.Name;
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.Bio = request.Bio;
                user.PhotoPath = request.PhotoPath;
                user.FollowersCount = request.FollowersCount;
                user.Login = request.Login;
                user.Password = request.Password;

                await _context.SaveChangesAsync();

                return user;
            }

            return null;
        }
    }
}
