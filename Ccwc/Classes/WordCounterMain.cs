using System.Text.RegularExpressions;

namespace Ccwc.Classes
{
	public class WordCounterMain
	{
		private readonly string[] _inputFiles;
		private string _outputString;

		public WordCounterMain(string[] inputFiles)
		{
			_inputFiles = inputFiles;
			_outputString = string.Empty;
		}

		/// <summary>
		/// Depending on the input arguments, it implements the counting calculations.
		/// </summary>
		/// <param name="inputArguments"></param>
		/// <returns>It returns the string which be printed in the terminal.</returns>
		public string Count(string[] inputArguments)
        {
            if (inputArguments.Length == 0)
                inputArguments = new string[] { "-c", "-l", "-w" };

            if (inputArguments.Contains(("--help")))
				return HelpMessage();

			var tempFilePath = _inputFiles.FirstOrDefault();
			if (string.IsNullOrEmpty(tempFilePath))
				return "Ccwc: filename was not specified!\n";

			_outputString = string.Empty;
			
			if (inputArguments.Contains("-l")) // number of lines
                _outputString += $" {FindNumberOfLines(tempFilePath)}";

			if (inputArguments.Contains("-w")) //number of words
                _outputString += $" {FindNumberOfWords(tempFilePath)}";

            if (inputArguments.Contains("-c")) //number of bytes
                _outputString += $" {FindNumberOfBytes(tempFilePath)}";

			if (inputArguments.Contains("-m")) //number of characters
                _outputString += $" {FindNumberOfCharacters(tempFilePath)}";

			if(string.IsNullOrEmpty(_outputString))
				return $"Ccwc: unknown input option.\nTry Ccwc --help for more information.\n";

			return $"{_outputString} {tempFilePath}\n";
		}

		/// <summary>
		/// It returns the number of bytes of the input file.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private int FindNumberOfBytes(string filePath)
		{
			if(!File.Exists(filePath))
				return 0;
			
			var textBytes = File.ReadAllBytes(filePath);
			return textBytes.Length;
		}

		/// <summary>
		/// It returns the number of lines of the input file.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private int FindNumberOfLines(string filePath)
		{
			if (!File.Exists(filePath))
				return 0;

			var textLines = File.ReadAllLines(filePath);
			return textLines.Length;
		}

		/// <summary>
		/// It returns the number of the words of the input file.
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns></returns>
		private int FindNumberOfWords(string filePath)
		{
			if (!File.Exists(filePath))
				return 0;

			var text = File.ReadAllText(filePath);
			return Regex.Matches(text, @"[\S]+").Count;
		}

		/// <summary>
		/// It returns the number of characters of the input file.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private int FindNumberOfCharacters(string filePath)
		{
			if (!File.Exists(filePath))
				return 0;

            var allText = File.ReadAllText(filePath);
            return allText.Length;
        }

		/// <summary>
		/// It displays a helping message.
		/// </summary>
		/// <returns></returns>
		private string HelpMessage()
		{
			return "This is a console program which handles any input text, either from a text file or from standard input of the terminal.\n" + 
                    "It can count the number of the bytes, the number of the lines, the number of the words and the number of the characters.\n" +
                    "The available input commands are the following:\n\n" +

                    "-c: outputs the number of bytes in a file\n" +
                    "-l: outputs the number of lines in a file\n" +
                    "-w: outputs the number of words in a file\n" +
                    "-m: outputs the number of characters in a file\n" +
					"--help: it show this text\n\n" +
                    
                    "If no command is given, then by default the output will be the same as if the -c -l -w commands were given.";
		}

	}
}
