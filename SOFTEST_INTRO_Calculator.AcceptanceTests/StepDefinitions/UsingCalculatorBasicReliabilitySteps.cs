using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
	private readonly CalculatorContext _context;

	public UsingCalculatorBasicReliabilitySteps(CalculatorContext context)
    {
        _context = context;
    }

	[When("I have entered {double}, {double} and {double} into the Calculator and press Current Failure Intensity")]
	public void WhenIHaveEnteredAndPressCFI(double initial, double expected, double execution)
	{
		try
		{
			_context.Result = _context.Calculator.CFI(initial, expected, execution);
		} catch (Exception ex)
		{
			_context.Error = ex;
		}
	}

	[When("I have entered {double}, {double} and {double} into the Calculator and press Expected Cumulative Number of Failures")]
	public void WhenIHaveEnteredAndPressECNF(double initial, double expected, double execution)
	{
		try
		{
			_context.Result = _context.Calculator.ECNF(initial, expected, execution);
		} catch (Exception ex)
		{
			_context.Error = ex;
		}
	}
}