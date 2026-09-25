using SOFTEST_INTRO_Calculator;
using NUnit.Framework;
namespace SOFTEST_INTRO_Calculator.UnitTests;
public class CalculatorTests
{
	private Calculator _calculator = null!;

	[SetUp]
	public void SetUp()
	{
		_calculator = new Calculator();
	}

	[Test]
	public void Add_TwoPositiveNumbers_ReturnsSum()
	{
		// Arrange: the calculator is created in SetUp.
		// Act
		double result = _calculator.Add(10, 20);
		// Assert
		Assert.That(result, Is.EqualTo(30));
	}

	[TestCase(0, 0, 1)]
	[TestCase(0, 5, 5)]
	[TestCase(-3, 8, 5)]
	[TestCase(0.1, 0.2, 0.3)]
	public void Add_RepresentativeInputs_ReturnsSum(double a, double b, double expected)
	{
		double result = _calculator.Add(a, b);
		Assert.That(result, Is.EqualTo(expected).Within(1e-9));
	}

	[Test]
	public void Add_PostiveAndZero_ReturnsSameNumer()
	{
		double result = _calculator.Add(10, 0);
		Assert.That(result, Is.EqualTo(10));
	}

	[Test]
	public void Add_PostiveAndNegativeOppostieNumbers_ReturnsZero()
	{
		double result = _calculator.Add(10, -10);
		Assert.That(result, Is.EqualTo(0));
	}

	[Test]
	public void Add_TwoNegativeNumbers_ReturnsSum()
	{
		double result = _calculator.Add(-10, -20);
		Assert.That(result, Is.EqualTo(-30));
	}

	[Test]
	public void Subtract_TwoPositiveNumbers_ReturnsDifference()
	{
		double result = _calculator.Subtract(20, 10);
		Assert.That(result, Is.EqualTo(10));
	}

	[Test]
	public void Subtract_PositiveAndZero_ReturnsSameNumber()
	{
		double result = _calculator.Subtract(10, 0);
		Assert.That(result, Is.EqualTo(10));
	}

	[Test]
	public void Subtract_ZeroAndPositive_ReturnsNegative()
	{
		double result = _calculator.Subtract(0, 10);
		Assert.That(result, Is.EqualTo(-10));
	}

	[Test]
	public void Subtract_PositiveAndNegative_ReturnsSum()
	{
		double result = _calculator.Subtract(10, -10);
		Assert.That(result, Is.EqualTo(20));
	}

	[Test]
	public void Subtract_NegativeAndPositive_ReturnsDifference()
	{
		double result = _calculator.Subtract(-10, 10);
		Assert.That(result, Is.EqualTo(-20));
	}

	[Test]
	public void Subtract_NegativeAndZero_ReturnsSameNumber()
	{
		double result = _calculator.Subtract(-10, 0);
		Assert.That(result, Is.EqualTo(-10));
	}

	[Test]
	public void Subtract_ZeroAndNegative_ReturnsPositive()
	{
		double result = _calculator.Subtract(0, -10);
		Assert.That(result, Is.EqualTo(10));
	}

	[Test]
	public void Subtract_TwoNegativeNumbersBigSmall_ReturnsDifference()
	{
		double result = _calculator.Subtract(-20, -10);
		Assert.That(result, Is.EqualTo(-10));
	}

	[Test]
	public void Subtract_TwoNegativeNumbersSmallBig_ReturnsDifference()
	{
		double result = _calculator.Subtract(-10, -20);
		Assert.That(result, Is.EqualTo(10));
	}

	[Test]
	public void Multiply_TwoPostiveNumbers_ReturnsProduct()
	{
		double result = _calculator.Multiply(20, 10);
		Assert.That(result, Is.EqualTo(200));
	}

	[Test]
	public void Multiply_PositiveAndNegativeNumbers_ReturnsNegativeProduct()
	{
		double result = _calculator.Multiply(20, -10);
		Assert.That(result, Is.EqualTo(-200));
	}

	[Test]
	public void Multiply_PositiveAndZero_ReturnsZero()
	{
		double result = _calculator.Multiply(20, 0);
		Assert.That(result, Is.EqualTo(0));
	}

	[Test]
	public void Multiply_NegativeAndZeroNumbers_ReturnsZero()
	{
		double result = _calculator.Multiply(-20, 0);
		Assert.That(result, Is.EqualTo(0));
	}

	[Test]
	public void Multiply_TwoNegativeNumbers_ReturnsPositiveProduct()
	{
		double result = _calculator.Multiply(-20, -10);
		Assert.That(result, Is.EqualTo(200));
	}

	[TestCase(1,2,0.5)]
	[TestCase(0,15,0)]
	[TestCase(15,-3,-5)]
	public void Divide_RepresentativeInputs_ReturnsQuotient(double a, double b, double expected)
	{
		double result = _calculator.Divide(a, b);
		Assert.That(result, Is.EqualTo(expected).Within(1e-9));
	}

	[TestCase(15, 0)]
	[TestCase(0, 0)]
	public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
	{
		Assert.That(() => _calculator.Divide(a, b), Throws.TypeOf<ArgumentException>());
	}

	[Test]
	public void Factorial_Zero_ReturnsOne()
	{
		long result = _calculator.Factorial(0);
		Assert.That(result, Is.EqualTo(1L));
	}

	[TestCase(1, 1)]
	[TestCase(5, 120)]
	[TestCase(20, 2432902008176640000L)]
	public void Factorial_ValidInput_ReturnsFactorial(int n, long expected)
	{
		long result = _calculator.Factorial(n);
		Assert.That(result, Is.EqualTo(expected));
	}

	[TestCase(-1)]
	[TestCase(21)]
	public void Factorial_InvalidInput_ThrowsArgumentOutOfRangeException(int n)
	{
		Assert.That(() => _calculator.Factorial(n), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[TestCase(3, 4, 6)]
	[TestCase(5, 10, 25)]
	[TestCase(0, 10, 0)]
	public void TriangleArea_ValidInput_ReturnsArea(double height, double width, double expected)
	{
		double result = _calculator.TriangleArea(height, width);
		Assert.That(result, Is.EqualTo(expected).Within(1e-9));
	}

	[TestCase(5, 5, 120, 1)]
	[TestCase(5, 4, 120, 5)]
	[TestCase(5, 3, 60, 10)]
	[TestCase(5, 0, 1, 1)]
	[TestCase(0, 0, 1, 1)]
	[TestCase(4, 2, 12, 6)]
	public void UnknownFunctions_ValidInput_ReturnsFinal(int n, int r, int ExpectedA, int ExpectedB)
	{
		long resultA = _calculator.UnknownFunctionA(n, r);
		long resultB = _calculator.UnknownFunctionB(n, r);
		Assert.That(resultA, Is.EqualTo(ExpectedA));
		Assert.That(resultB, Is.EqualTo(ExpectedB));
	}

	[TestCase(-4, 5)]
	[TestCase(4, 5)]
	public void UnknownFunctions_InvalidInput_ReturnsFinal(int n, int r)
	{
		Assert.That(() => _calculator.UnknownFunctionA(n, r), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => _calculator.UnknownFunctionB(n, r), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[TestCase(200, 10, 20)]
	[TestCase(100, 1, 100)]
	public void MTBF_ReturnsExpectedValue(
		double operatingTime,
		double failureCount,
		double expected)
	{
		Assert.That(_calculator.MTBF(operatingTime, failureCount),
			Is.EqualTo(expected).Within(1e-9));
	}

	[TestCase(0, 10)]
	[TestCase(100, 0)]
	[TestCase(-100, 10)]
	[TestCase(100, -10)]
	public void MTBF_RejectsInvalidInputs(
		double operatingTime,
		double failureCount)
	{
		Assert.Throws<ArgumentOutOfRangeException>(
			() => _calculator.MTBF(operatingTime, failureCount));
	}

	[TestCase(200, 10, 0.9523809523809523)]
	[TestCase(100, 0, 1)]
	[TestCase(0, 100, 0)]
	public void Availability_ReturnsExpectedValue(
		double mtbf,
		double mttr,
		double expected)
	{
		Assert.That(_calculator.Availability(mtbf, mttr),
			Is.EqualTo(expected).Within(1e-9));
	}

	[TestCase(-100, 10)]
	[TestCase(10, -10)]
	[TestCase(0, 0)]
	public void Availability_RejectsInvalidInputs(
		double mtbf,
		double mttr)
	{
		Assert.Throws<ArgumentOutOfRangeException>(
			() => _calculator.Availability(mtbf, mttr));
	}

	[TestCase(10, 100, 10, 3.678794412)]
	public void CFI_ReturnsExpectedValue(
		double initialFailureIntensity,
		double expectedTotalFailures,
		double executionTime,
		double expected)
	{
		Assert.That(
			_calculator.CFI(
				initialFailureIntensity,
				expectedTotalFailures,
				executionTime),
			Is.EqualTo(expected).Within(1e-9));
	}

	[Test]
	public void CFI_AtZeroExecutionTime_ReturnsInitialFailureIntensity()
	{
		Assert.That(
			_calculator.CFI(10, 100, 0),
			Is.EqualTo(10).Within(1e-9));
	}

	[TestCase(0, 100, 10)]
	[TestCase(-1, 100, 10)]
	[TestCase(10, 0, 10)]
	[TestCase(10, -1, 10)]
	[TestCase(10, 100, -1)]
	public void CFI_RejectsInvalidInputs(
		double initialFailureIntensity,
		double expectedTotalFailures,
		double executionTime)
	{
		Assert.Throws<ArgumentOutOfRangeException>(
			() => _calculator.CFI(
				initialFailureIntensity,
				expectedTotalFailures,
				executionTime));
	}

	[Test]
	public void ECNF_ReturnsExpectedValue()
	{
		Assert.That(
			_calculator.ECNF(10, 100, 10),
			Is.EqualTo(63.21205588).Within(1e-8));
	}

	[Test]
	public void ECNF_AtZeroExecutionTime_ReturnsZero()
	{
		Assert.That(
			_calculator.ECNF(10, 100, 0),
			Is.EqualTo(0).Within(1e-8));
	}

	[TestCase(0, 100, 10)]
	[TestCase(-1, 100, 10)]
	[TestCase(10, 0, 10)]
	[TestCase(10, -1, 10)]
	[TestCase(10, 100, -1)]
	public void ECNF_RejectsInvalidInputs(
		double initialFailureIntensity,
		double expectedTotalFailures,
		double executionTime)
	{
		Assert.Throws<ArgumentOutOfRangeException>(
			() => _calculator.ECNF(
				initialFailureIntensity,
				expectedTotalFailures,
				executionTime));
	}
}