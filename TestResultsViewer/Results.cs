using System;
using System.Collections.Generic;

namespace TestResultsViewer
{
	class Results
	{
		public TestRun testRun;
	}

	abstract class TestBase
	{
		public string id;
		public string label;
		public int asserts;
		public string result;
		public DateTime startTime;
		public DateTime endTime;
		public double duration;
	}

	abstract class CollectionResults : TestBase
	{
		public int testCaseCount;
		public int total;
		public int passed;
		public int failed;
		public int inconclusive;
		public int skipped;
	}

	class TestRun : CollectionResults
	{
		public string engineVersion;
		public string clrVersion;
		public string commandLine;
		public TestSuite testSuite;
	}

	class TestSuite : CollectionResults
	{
		public string type;
		public string name;
		public string fullName;
		public string className;
		public string runState;
		public Environment environment;
		public Settings settings;
		public PropertyList properties;
		public Failure failure;
		public List<TestSuite> testSuites;
		public string reason;
		public List<TestCase> testCases;
	}

	class TestCase : TestBase
	{
		public string name;
		public string fullName;
		public string methodName;
		public string className;
		public string runState;
		public int seed;
		public string site;
		public PropertyList properties;
		public Reason reason;
		public Failure failure;
	}

	class Environment
	{
		public string frameworkVersion;
		public string clrVersion;
		public string osVersion;
		public string platform;
		public string cwd;
		public string machineName;
		public string user;
		public string userDomain;
		public string culture;
		public string uiCulture;
		public string osArchitecture;
	}

	class Setting
	{
		public string name;
		public string value;
	}

	class Settings : List<Setting>
	{
	}

	class Property
	{
		public string name;
		public string value;
	}

	class PropertyList : List<Property>
	{
	}

	class Failure
	{
		public string message;
		public string stackTrace;
	}

	class Reason
	{
		public string message;
	}
}
