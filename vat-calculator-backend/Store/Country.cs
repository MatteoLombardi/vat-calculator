namespace vat_calculator_backend.Store
{
    public class Country
    {
        public Guid Id { get; }
        public string Value { get; }
        public string ViewValue { get; }
        public IEnumerable<int> AvailableVatRates { get; }

        public Country(
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
}

