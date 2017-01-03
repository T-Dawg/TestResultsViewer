using System;
using System.Collections.Generic;

namespace TestResultsViewer
{
	public static class ErrorHandler
	{
		private static List<string> _errorMessages = new List<string>();

		public static void AddError(string errorMessage)
		{
			_errorMessages.Add(errorMessage);
		}

		public static bool HasErrors
		{
			get { return _errorMessages.Count > 0; }
		}

		public static string GetErrorsList()
		{
			return string.Join("\n", _errorMessages);
		}

		public static void Clear()
		{
			_errorMessages.Clear();
		}
	}

	public class HandledException : Exception
	{
	}
}
