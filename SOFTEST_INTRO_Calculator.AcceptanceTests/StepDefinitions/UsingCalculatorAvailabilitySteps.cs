using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorAvailabilitySteps
{
	private readonly CalculatorContext _context;
	private readonly ReliabilityContext _reliability;

	public UsingCalculatorAvailabilitySteps(CalculatorContext context, ReliabilityContext reliability)
    {
        _context = context;
		_reliability = reliability;
    }

	[Given("the reliability values are")]
	public void GivenTheReliabilityValuesAre(DataTable table)
	{
		var values = table.Rows[0];
		_reliability.Mtbf = double.Parse(values["MTBF"]);
		_reliability.Mttr = double.Parse(values["MTTR"]);
	}

	[When("I have entered {double} and {double} into the calculator and press MTBF")]
	public void WhenIHaveEnteredAndPressMTBF(double operatingTime, double failureCount)
	{
		try
		{
			_context.Result = _context.Calculator.MTBF(operatingTime, failureCount);
		}
		catch (Exception ex)
		{
			_context.Error = ex;
		}
	}

	[When("I have entered {double} and {double} into the calculator and press Availability")]
	public void WhenIHaveEnteredAndPressAvailability(double mtbf, double mttr)
	{
		try
		{
			_context.Result = _context.Calculator.Availability(mtbf, mttr);
		}
		catch (Exception ex)
		{
			_context.Error = ex;
		}
	}

	[When("I calculate Availability from these values")]
	public void WhenICalculateAvailabilityFromTheseValues()
	{
		_context.Result = _context.Calculator.Availability(_reliability.Mtbf, _reliability.Mttr);
	}
}