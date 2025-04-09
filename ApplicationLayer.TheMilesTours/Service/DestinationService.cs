using ApplicationLayer.TheMilesTours.IService;
using DomainLayer.TheMilesTours.Entities;
using Infrastructure.TheMilesTours.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.TheMilesTours.Service
{
   public class DestinationService:IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;
        public DestinationService(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<bool> Add(Destination destination)
        {
           return await _destinationRepository.Add(destination);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _destinationRepository.Delete(id);
        }

        public async Task<IEnumerable<Destination>> GetAll()
        {
            return await _destinationRepository.GetAll();
        }

        public async Task<Destination> GetById(Guid id)
        {
            return await _destinationRepository.GetById(id);
        }

        public async Task<bool> Update(Destination destination)
        {
            return await _destinationRepository.Update(destination);
        }
    }
}
