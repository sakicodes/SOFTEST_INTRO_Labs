using System.Globalization;
using SOFTEST_INTRO_Calculator;

var calculator = new Calculator();

Console.WriteLine("Calculator operations:");
Console.WriteLine("a=add, s=subtract, m=multiply, d=divide, f=factorial");

Console.Write("Operation: ");
string op = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

if (op != "f" && op != "c")
{
	Console.Write("First number: ");
	string first = Console.ReadLine() ?? "";

	Console.Write("Second number: ");
	string second = Console.ReadLine() ?? "";

	bool firstOk = double.TryParse(
		first,
		NumberStyles.Float,
		CultureInfo.InvariantCulture,
		out double a);

	bool secondOk = double.TryParse(
		second,
		NumberStyles.Float,
		CultureInfo.InvariantCulture,
		out double b);

	if (!firstOk || !secondOk || !double.IsFinite(a) || !double.IsFinite(b))
	{
		Console.WriteLine("Enter finite numbers; use . for decimals.");
		return;
	}

	try
	{
		double result = calculator.DoOperation(a, b, op);
		string text = result.ToString(CultureInfo.InvariantCulture);
		Console.WriteLine("Result: " + text);
	}
	catch (ArgumentException error)
	{
		Console.WriteLine(error.Message);
	}
} else if (op == "f")
{
	Console.Write("Number: ");
	string numInput = Console.ReadLine() ?? "";

	bool intOk = int.TryParse(
		numInput,
		NumberStyles.Integer,
		CultureInfo.InvariantCulture,
		out int n);
	
	if (!intOk)
	{
		Console.WriteLine("Enter a valid integer.");
		return;
	}

	try
	{
		long result = calculator.Factorial(n);
		string text = result.ToString(CultureInfo.InvariantCulture);
		Console.WriteLine("Result: " + text);
	} catch (ArgumentOutOfRangeException error)
	{
		Console.WriteLine(error.Message);
	}
} else if (op == "c")
{
	Console.Write("Radius: ");
	string radInput = Console.ReadLine() ?? "";

	bool radOk = double.TryParse(
		radInput,
		NumberStyles.Float,
		CultureInfo.InvariantCulture,
		out double rad);
	
	if (!radOk || !double.IsFinite(rad))
	{
		Console.WriteLine("Enter finite numbers; use . for decimals.");
		return;
	}

	try
	{
		double result = calculator.CircleArea(rad);
		string text = result.ToString(CultureInfo.InvariantCulture);
		Console.WriteLine("Result: " + text);
	} catch (ArgumentOutOfRangeException error)
	{
		Console.WriteLine(error.Message);
	}
}