using CQRS.CQRS.Results;
using MediatR;
using System.Collections.Generic;

namespace CQRS.CQRS.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
