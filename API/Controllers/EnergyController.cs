using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    
    public class EnergyController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IEnergyRepository _energyRepository;
        public EnergyController(IEnergyRepository energyRepository,IMapper mapper)
        {
           _energyRepository = energyRepository;
           _mapper = mapper;
        }
         [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyDto>>> GetEnergyUsages()
        {
            var energyUsages = await _energyRepository.GetEnergyUsagesAsync();       
            var energyUsageDetails= _mapper.Map<IEnumerable<EnergyDto>>(energyUsages);
            return Ok(energyUsageDetails);
        }

        [HttpPost]
        public async Task<ActionResult> InputUsage(EnergyUsage energyUsageInput)
        {
            
            if (energyUsageInput.EnergyType.ToUpper()!="GAS" && energyUsageInput.EnergyType.ToUpper()!="ELECTRICITY")
            {
               return BadRequest("Please enter a valid energy type");
            }

            var energyUsage = new EnergyUsage
            {                
                InputDate=energyUsageInput.InputDate,
                Price=energyUsageInput.Price,
                EnergyType=energyUsageInput.EnergyType                
            };

            _energyRepository.UpdateEnergyUsage(energyUsage);
            if (await _energyRepository.SaveAllAsync())
            {
               return Ok();
            }

             return BadRequest("Failed to input energy details");
        }

    }
}