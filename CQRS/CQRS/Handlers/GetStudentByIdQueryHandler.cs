using CQRS.CQRS.Queries;
using CQRS.CQRS.Results;
using CQRS.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.CQRS.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResult>
    {
        readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Set<Student>().FindAsync(request.Id);
            return new GetStudentByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname
            };
        }
    }
}
