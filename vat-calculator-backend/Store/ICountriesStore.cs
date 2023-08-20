namespace vat_calculator_backend.Store;

public interface ICountriesStore
{
    IEnumerable<Country> GetAll();
    Country GetByID(Guid id);
    void Create(CreateCountryParams createCountryParams);
    void Update(Guid id, UpdateCountryParams updateCountryParams);
    void Delete(Guid id);
}