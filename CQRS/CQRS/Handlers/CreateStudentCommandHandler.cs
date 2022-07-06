using CQRS.CQRS.Commands;
using CQRS.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.CQRS.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        readonly StudentContext _context;

        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _context.Students.Add(new Student { Age = request.Age, Name = request.Name, Surname = request.Surname });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
