using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Data;
using MyAPI.Models.Domain;
using MyAPI.Models.Dto;
using MyAPI.Models.DTO;
using MyAPI.Repositories;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }
        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {     
            var regionDomain = await _regionRepository.GetAllAsync();
            var regionsDto = _mapper.Map<List<RegionDto>>(regionDomain);
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await _regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            var regionDto = _mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);
            
            regionDomainModel = await _regionRepository.CreateAsync(regionDomainModel);

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);
            
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);
            
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
            
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {            
            var regionDomainModel = await _regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}
