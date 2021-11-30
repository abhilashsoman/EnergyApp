using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IEnergyRepository
    {
        Task<IEnumerable<EnergyUsage>> GetEnergyUsagesAsync();
        void UpdateEnergyUsage(EnergyUsage energyUsage);
        Task<bool> SaveAllAsync();
    }
}