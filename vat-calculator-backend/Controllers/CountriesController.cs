using Microsoft.AspNetCore.Mvc;
using vat_calculator_backend.Requests;
using vat_calculator_backend.Store;

namespace vat_calculator_backend.Controllers;

[Route("api/[controller]")]
public class CountriesController : Controller
{
    private readonly ICountriesStore countriesStore;

    public CountriesController(ICountriesStore countriesStore)
    {
        this.countriesStore = countriesStore;
    }

    // GET: api/countries
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Domain.Country>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        var countries = countriesStore.GetAll().Select(x => new Domain.Country(x));
        return Ok(countries);
    }

    // GET: api/countries/{id}
    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Domain.Country), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Domain.Country), StatusCodes.Status404NotFound)]
    public IActionResult Get(Guid id)
    {
        var country = countriesStore.GetByID(id);
        if (country == null)
        {
            return NotFound();
        }

        return Ok(new Domain.Country(country));
    }

    // POST: api/countries
    [HttpPost]
    [Consumes(typeof(CreateCountryRequest), "application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult Post([FromBody] CreateCountryRequest request)
    {
        try
        {
            countriesStore.Create(new CreateCountryParams(
                request.Id,
                request.Value,
                request.ViewValue,
                request.AvailableVatRates
                ));
        }
        catch (DuplicateKeyException)
        {
            return Conflict();
        }

        return Ok();
    }

    // PUT: api/countries/{id}
    [HttpPut("{id}")]
    [Consumes(typeof(UpdateCountryRequest), "application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Put(Guid id, [FromBody] UpdateCountryRequest request)
    {
        try
        {
            countriesStore.Update(id, new UpdateCountryParams(
                request.Value,
                request.ViewValue,
                request.AvailableVatRates
                ));
        }
        catch (RecordNotFoundException)
        {
            return NotFound();
        }

        return Ok();
    }

    // DELETE api/countries/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        try
        {
            countriesStore.Delete(id);
        }
        catch (RecordNotFoundException)
        {
            return NotFound();
        }

        return Ok();
    }
}