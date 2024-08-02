using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Interfaces;

namespace Caticket.PartnerAPI.Infrastructure.Repositories;

public class TicketRepository(DatabaseContext dbContext, TenantProvider tenantProvider) : Repository<Ticket>(dbContext, tenantProvider)
{
}