public class UpdateCountryParams
{
    public string Value { get; }
    public string ViewValue { get; }
    public IEnumerable<int> AvailableVatRates { get; }

    public UpdateCountryParams(string value, string viewValue, IEnumerable<int> availableVatRates)
    {
        Value = value;
        ViewValue = viewValue;
        AvailableVatRates = availableVatRates;
    }
}