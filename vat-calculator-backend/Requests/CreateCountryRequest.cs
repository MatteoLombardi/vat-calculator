namespace vat_calculator_backend.Requests;

public class CreateCountryRequest
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public string ViewValue { get; set; }
    public IEnumerable<int> AvailableVatRates { get; set; }
}

