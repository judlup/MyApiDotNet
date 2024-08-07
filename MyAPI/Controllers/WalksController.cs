using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Models.Domain;
using MyAPI.Models.DTO;
using MyAPI.Repositories;

namespace MyAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class WalksController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IWalkRepository _walkRepository;

    public WalksController(IMapper mapper, IWalkRepository walkRepository) {
      this._mapper = mapper;
      this._walkRepository = walkRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto) {

      // Map DTO to domain model
      var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);
      await _walkRepository.CreateAsync(walkDomainModel);

      // Map Domain model to DTO
      var walkDto = _mapper.Map<WalkDto>(walkDomainModel);
      return Ok(walkDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
      var walksDomain = await _walkRepository.GetAllAsync();
      var walksDto = _mapper.Map<List<WalkDto>>(walksDomain);
      return Ok(walksDto);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id) {
      var walkDomain = await _walkRepository.GetByIdAsync(id);
      if (walkDomain == null) {
        return NotFound();
      }
      var walkDto = _mapper.Map<WalkDto>(walkDomain);
      return Ok(walkDto);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto) {
      var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);
      walkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);
      if (walkDomainModel == null) {
        return NotFound();
      }
      var walkDto = _mapper.Map(updateWalkRequestDto, walkDomainModel);
      return Ok(walkDto);
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id) {
      var walkDomainModel = await _walkRepository.DeleteAsync(id);
      if (walkDomainModel == null) {
        return NotFound();
      }
      var walkDto = _mapper.Map<WalkDto>(walkDomainModel);
      return Ok(walkDto);
    }
  }
}
