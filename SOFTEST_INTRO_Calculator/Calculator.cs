namespace SOFTEST_INTRO_Calculator;
public class Calculator
{
	public double Add(double a, double b) => a + b;

	// public double Add(double a, double b)
	// {
	// 	string binary = a.ToString() + b.ToString();
	// 	return Convert.ToInt32(binary, 2);
	// }
	public double Subtract(double a, double b) => a - b;
	public double Multiply(double a, double b) => a * b;
	// Starter version: complete the zero-divisor rule in section 5.
	public double Divide(double a, double b)
	{
		if (b == 0)
		{
			throw new ArgumentException("Cannot divide by zero.");
		}
		return a / b;
	}

	public long Factorial(int n)
	{
		if (n < 0 || n > 20)
			throw new ArgumentOutOfRangeException(" The upper limit prevents overflow beyond 20!");
		if (n == 0)
			return 1;
		else
			return n * Factorial(n - 1);
	}

	public double TriangleArea(double height, double width)
	{
		if (height < 0 || width < 0)
			throw new ArgumentOutOfRangeException("Height and width cannot be negative.");
		return (height * width) / 2;
	}

	public double CircleArea(double radius)
	{
		if (radius < 0)
			throw new ArgumentOutOfRangeException("Radius cannot be negative.");
		return Math.PI * radius * radius;
	}

	public long UnknownFunctionA(int n, int r)
	{
		if (n < 0 || r < 0 || n < r || n > 20)
		{
			throw new ArgumentOutOfRangeException("n and r must be non-negative, and n must be greater than or equal to r.");
		}
		long result = Factorial(n) / Factorial(n-r);
		return result;
	}

	public long UnknownFunctionB(int n, int r)
	{
		if (n < 0 || r < 0 || n < r || n > 20)
			throw new ArgumentOutOfRangeException("n and r must be non-negative, and n must be greater than or equal to r.");
		return Factorial(n) / (Factorial(r) * Factorial(n-r));
	}

	public double MTBF(double operatingTime, double failureCount)
	{
		if (operatingTime <= 0 || failureCount <= 0)
			throw new ArgumentOutOfRangeException("Time and failure count cannot be negative.");
		return Divide(operatingTime, failureCount);
	}

	public double Availability(double mtbf, double mttr)
	{
		if (mtbf < 0 || mttr < 0 || (mtbf + mttr <= 0))
			throw new ArgumentOutOfRangeException("MTBF and MTTR cannot be negative.");
		return mtbf / (mtbf + mttr);
	}

	public double CFI(double initialFailureIntensity, double expectedTotalFailures, double executionTime)
	{
		if (initialFailureIntensity <= 0 || expectedTotalFailures <= 0 || executionTime < 0)
			throw new ArgumentOutOfRangeException("Invalid inputs");
		return initialFailureIntensity * Math.Exp(-initialFailureIntensity * executionTime / expectedTotalFailures);
	}

	public double ECNF(double initialFailureIntensity, double expectedTotalFailures, double executionTime)
	{
		if (initialFailureIntensity <= 0 || expectedTotalFailures <= 0 || executionTime < 0)
			throw new ArgumentOutOfRangeException("Invalid inputs");
		return expectedTotalFailures * (1 - Math.Exp(-initialFailureIntensity * executionTime / expectedTotalFailures));
	}
	
	public double DoOperation(double a, double b, string op)
	{
		return op switch
		{
			"a" => Add(a, b),
			"s" => Subtract(a, b),
			"m" => Multiply(a, b),
			"d" => Divide(a, b),
			"t" => TriangleArea(a, b),
			_ => throw new ArgumentException("Unknown operation.")
		};
	}
}