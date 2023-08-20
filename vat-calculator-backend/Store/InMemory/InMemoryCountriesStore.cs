namespace vat_calculator_backend.Store.InMemory;

public class InMemoryCountriesStore : ICountriesStore
{

    private readonly Dictionary<Guid, Country> repository = new Dictionary<Guid, Country>();

    public void Create(CreateCountryParams createCountryParams)
    {
        if (repository.ContainsKey(createCountryParams.Id))
        {
            throw new DuplicateKeyException($"Duplicate country id: {createCountryParams.Id} for country named: {createCountryParams.ViewValue}");
        }

        var country = new Country(
            createCountryParams.Id,
            createCountryParams.Value,
            createCountryParams.ViewValue,
            createCountryParams.AvailableVatRates
            );
        repository.Add(country.Id, country);
    }

    public void Delete(Guid id)
    {
        if (!repository.ContainsKey(id))
        {
            throw new RecordNotFoundException();
        }

        repository.Remove(id);
    }

    public IEnumerable<Country> GetAll()
    {
        IEnumerable<Country> countriesEnum = repository.Values.AsEnumerable();
        if (countriesEnum.Count() > 0)
        {
            return countriesEnum;
        }

        // Endpoint designed to work after countries have been added via post
        // This block is designed to bypass it for quick demo purposes
        IEnumerable<Country> demoList = new List<Country>
        {
            new Country(new Guid(), "at", "Austria", new List<int>() {5, 10, 13, 20}.AsEnumerable()),
            new Country(new Guid(), "uk", "United Kingdom", new List<int>() {5, 20}.AsEnumerable()),
            new Country(new Guid(), "pt", "Portugal", new List<int>() {6, 13, 23}.AsEnumerable()),
            new Country(new Guid(), "sgp", "Singapore", new List<int>() {7}.AsEnumerable())

        }.AsEnumerable();

        return demoList;
    }

    public Country? GetByID(Guid id)
    {
        if (repository.ContainsKey(id))
        {
            return repository[id];
        }

        return null;
    }

    public void Update(Guid id, UpdateCountryParams updateCountryParams)
    {
        if (!repository.ContainsKey(id))
        {
            throw new RecordNotFoundException();
        }

        var countryToUpdate = repository[id];
        var country = new Country(
            countryToUpdate.Id,
            updateCountryParams.Value,
            updateCountryParams.ViewValue,
            updateCountryParams.AvailableVatRates
            );

        repository[id] = country;
    }

}

