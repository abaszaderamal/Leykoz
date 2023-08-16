using System.Collections.Generic;
using System.Threading.Tasks;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.ViewModels;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;

namespace Leykoz.Business.Service.Implementations
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventUpdateVM> GetByIdAsync(int id)
        {
            var dbEvent = await _unitOfWork.EventRepository
                .GetAsync(p => p.Id == id && p.IsDeleted == false);
            EventUpdateVM _event = new EventUpdateVM
            {
                Title = dbEvent.Title,
                Content = dbEvent.Content,
                EventDate = dbEvent.EventDate
            };
            return _event;
        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await _unitOfWork.EventRepository.GetAllByDesendingAsync();
        }

        public async Task AddAsync(EventVM eventVm)
        {
            Event nEvent = new Event
            {
                Title = eventVm.Title,
                Content = eventVm.Content,
                EventDate = eventVm.EventDate
            };
            await _unitOfWork.EventRepository.CreateAsync(nEvent);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(int id, EventUpdateVM eventVm)
        {
            Event dbEvent = await _unitOfWork.EventRepository.GetAsync(p => p.Id == id);
            dbEvent.Title = eventVm.Title;
            dbEvent.Content = eventVm.Content;
            dbEvent.EventDate = eventVm.EventDate == null ? dbEvent.EventDate : eventVm.EventDate;
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Event dbEvent = await _unitOfWork.EventRepository.GetAsync(p => p.Id == id);
            dbEvent.IsDeleted = true;
            await _unitOfWork.SaveAsync();
        }
    }
}