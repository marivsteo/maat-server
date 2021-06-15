using Maat.Domain.DTO;
using Maat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maat.Services.Abstractions
{
    public interface ISportEventService
    {
        List<SportEvent> GetAllSportEvents();

        List<SportEvent> GetAvailableSportEvents(int userId);

        SportEvent AddSportEvent(SportEvent sportEvent);

        List<SportEventDto> GetSportEventsCreatedByUser(int userId);

        List<SportEvent> GetParticipatingSportEvents(int userId);

        SportEvent GetSportEventById(int eventId);

        void AddSportEventParticipation(int eventId, int userId);
    }
}
