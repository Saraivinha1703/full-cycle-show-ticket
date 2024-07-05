using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Interfaces;
using Caticket.SalesAPI.Infrastructure.Data;
using Caticket.SalesAPI.Infrastructure.Interfaces;

namespace Caticket.SalesAPI.Infrastructure.Repositories;

public class TicketRepository(DatabaseContext dbContext) : Repository<Ticket>(dbContext), IRepository<Ticket> { }