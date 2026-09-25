using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorFactorialSteps
{
	private readonly CalculatorContext _context;

	public UsingCalculatorFactorialSteps(CalculatorContext context)
	{
		_context = context;
	}

	[When("I have entered {int} and press factorial")]
	public void WhenIHaveEnteredAndPressFactorial(int input)
	{
		try {
			_context.IntegerResult = _context.Calculator.Factorial(input);
		} catch (Exception ex) {
			_context.Error = ex;
		}
	}
}