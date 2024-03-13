using MediatR;
using Medium.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Queries
{
    public class GetByIdUserQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
