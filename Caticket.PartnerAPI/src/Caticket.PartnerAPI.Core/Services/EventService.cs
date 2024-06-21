using Caticket.PartnerAPI.Core.Entities;
using Caticket.PartnerAPI.Core.Interfaces;

namespace Caticket.PartnerAPI.Core.Services;

public class EventService(IRepository<Event> eventRepository) {
    private readonly IRepository<Event> _eventRepository = eventRepository;
}