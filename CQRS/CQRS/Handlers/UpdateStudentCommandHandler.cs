using CQRS.CQRS.Commands;
using CQRS.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.CQRS.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        readonly StudentContext _context;

        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }
        public void Handle(UpdateStudentCommand command)
        {

        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _context.Students.Find(request.Id);
            student.Age = request.Age;
            student.Name = request.Name;
            student.Surname = request.Surname;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
