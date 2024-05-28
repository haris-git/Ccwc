using Ccwc.Dtos;

namespace Ccwc.Classes
{
	public class GeneralInputHandler
	{
		private readonly InputArgumentsDto _inputArgumentsDto;

		public GeneralInputHandler(string[] inputArguments)
		{
			_inputArgumentsDto = FindCommandsAndTextFromArguments(inputArguments);
		}

		public string Handle()
		{
			var wordCounterMainInstance = new WordCounterMain(_inputArgumentsDto.InputText);
            return wordCounterMainInstance.Count(_inputArgumentsDto.InputCommands);
        }

		/// <summary>
		/// It handles the input, in order to find the parameters which begin with the character - and the filename.
		/// It splits those two different data in order to be distinct, when we want to use them later.
		/// </summary>
		/// <param name="inputArguments"></param>
		/// <returns></returns>
		private InputArgumentsDto FindCommandsAndTextFromArguments(string[] inputArguments)
		{
			var commands = new List<string>();
			var textFile = new List<string>();

			foreach (var argument in inputArguments)
			{
				if (argument.StartsWith('-'))
					commands.Add(argument);
				else
					textFile.Add(argument);
			}

			return new InputArgumentsDto(commands.ToArray(), textFile.ToArray());
		}
	}
}
