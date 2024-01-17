using TechChallenge.Application.Core.Abstractions.Data;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Repositories;
using TechChallenge.Persistence.Core.Primitives;

namespace TechChallenge.Persistence.Repositories
{
    internal sealed class TicketRepository : GenericRepository<Ticket, int>, ITicketRepository
    {
        #region Constructors

        public TicketRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        #endregion
    }
}
