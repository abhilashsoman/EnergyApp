using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class EnergyRepository : IEnergyRepository
    {
         private readonly DataContext _context;
         public EnergyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateEnergyUsage(EnergyUsage energyUsage)
        {
            _context.Add(energyUsage);
           
        }

        public async Task<IEnumerable<EnergyUsage>> GetEnergyUsagesAsync()
        {
            return await _context.EnergyUsage
            .ToListAsync();
        }
    }
}