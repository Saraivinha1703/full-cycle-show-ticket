using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Interfaces;

namespace Caticket.PartnerAPI.Infrastructure.Repositories;

public class EventRepository(DatabaseContext dbContext) : Repository<Event>(dbContext)
{
}