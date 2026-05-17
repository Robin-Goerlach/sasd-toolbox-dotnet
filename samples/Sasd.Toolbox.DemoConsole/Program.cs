using Sasd.Toolbox.Numerics;
using Sasd.Toolbox.Numerics.RootFinding;

Console.WriteLine("SASD Toolbox for .NET - Numerics Preview");
Console.WriteLine("========================================");
Console.WriteLine();

double[] values = [2, 4, 4, 4, 5, 5, 7, 9];

Console.WriteLine("Statistics");
Console.WriteLine("----------");
Console.WriteLine($"Values:            {string.Join(", ", values)}");
Console.WriteLine($"Mean:              {Statistics.Mean(values):F4}");
Console.WriteLine($"Median:            {Statistics.Median(values):F4}");
Console.WriteLine($"Population var.:   {Statistics.Variance(values, VarianceMode.Population):F4}");
Console.WriteLine($"Sample var.:       {Statistics.Variance(values, VarianceMode.Sample):F4}");
Console.WriteLine();

Console.WriteLine("Linear interpolation");
Console.WriteLine("--------------------");
var interpolated = Interpolation.Linear(
    x0: 0,
    y0: 0,
    x1: 10,
    y1: 100,
    x: 2.5);
Console.WriteLine($"Interpolated value at x = 2.5 between (0, 0) and (10, 100): {interpolated:F4}");
Console.WriteLine();

Console.WriteLine("Bisection root finding");
Console.WriteLine("----------------------");

// Find the positive root of x² - 2 = 0. The result should be close to sqrt(2).
var result = BisectionRootFinder.FindRoot(
    function: x => (x * x) - 2.0,
    lowerBound: 1.0,
    upperBound: 2.0,
    options: new BisectionOptions(Tolerance: 1e-12, MaxIterations: 200));

Console.WriteLine($"Root:              {result.Root:F12}");
Console.WriteLine($"Function value:    {result.FunctionValue:E4}");
Console.WriteLine($"Iterations:        {result.Iterations}");
Console.WriteLine($"Converged:         {result.Converged}");
