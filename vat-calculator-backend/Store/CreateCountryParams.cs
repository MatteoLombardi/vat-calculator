public class CreateCountryParams
{
    public Guid Id { get; }
    public string Value { get; }
    public string ViewValue { get; }
    public IEnumerable<int> AvailableVatRates { get; }

    public CreateCountryParams(
        Guid id,
        string value,
        string viewValue,
        IEnumerable<int> availableVatRates
        )
    {
        Id = id;
        Value = value;
        ViewValue = viewValue;
        AvailableVatRates = availableVatRates;
    }
}