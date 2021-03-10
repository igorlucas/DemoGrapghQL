using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Contracts.IRepositories;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository) => _countryRepository = countryRepository;

        [HttpGet]
        public IEnumerable<Country> Get() => _countryRepository.Countries;


        [HttpPost]   
        public IActionResult Post([FromBody] Country country)
        {
            try
            {
                if (_countryRepository.CountryExists(country.Id))
                {
                    _countryRepository.UpdateCountry(country);
                    var result = _countryRepository.Commit();
                    if (result) return NoContent();
                    else return BadRequest();
                }
                else
                {
                    _countryRepository.CreateCountry(country);
                    var result = _countryRepository.Commit();
                    if (result) return StatusCode(201);
                    else return BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("updated/country")]
        public IActionResult WasUpdated([FromBody] Country country)
        {
            var updatedCountry = _countryRepository.CountryWasUpdated(country);
            return Ok(new { updatedCountry });
        }
    }
}
