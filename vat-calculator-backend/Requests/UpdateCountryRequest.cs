namespace vat_calculator_backend.Requests;	

public class UpdateCountryRequest
{
	public string Value { get; set; }
	public string ViewValue { get; set; }
	public IEnumerable<int> AvailableVatRates { get; set; }
}

