using CQRS.CQRS.Commands;
using CQRS.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.CQRS.Handlers
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        readonly StudentContext _context;

        public RemoveStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = _context.Students.Find(request.Id);
            _context.Students.Remove(deletedEntity);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
