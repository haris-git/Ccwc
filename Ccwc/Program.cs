// See https://aka.ms/new-console-template for more information

using Ccwc.Classes;

if (Console.IsInputRedirected)
{
	Console.WriteLine("Input redirected");
	using (var stream = Console.OpenStandardInput())
	{

	}
}
//Console.WriteLine($"Number of arguments: {args.Length}\n");
//string[] argsB = Environment.GetCommandLineArgs();
//Console.WriteLine($"Number of argumentsB: {argsB.Length}\n{argsB[0]}\n");
var result = new GeneralInputHandler(args);

Console.WriteLine(result.Handle());