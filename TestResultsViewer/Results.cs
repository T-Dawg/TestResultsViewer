using System;
using System.Collections.Generic;

namespace TestResultsViewer
{
	public abstract class TestBase
	{
		public string Id { get; set; }
		public string Label { get; set; }
		public int Asserts { get; set; }
		public string Result { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public double Duration { get; set; }
	}

	public abstract class CollectionResults : TestBase
	{
		public int TestCaseCount { get; set; }
		public int Total { get; set; }
		public int Passed { get; set; }
		public int Failed { get; set; }
		public int Inconclusive { get; set; }
		public int Skipped { get; set; }
	}

	public class TestRun : CollectionResults
	{
		public string EngineVersion { get; set; }
		public string ClrVersion { get; set; }
		public string CommandLine { get; set; }
		public TestSuite TestSuite { get; set; }
	}

	public class TestSuite : CollectionResults
	{
		public string Type { get; set; }
		public string Name { get; set; }
		public string FullName { get; set; }
		public string ClassName { get; set; }
		public string RunState { get; set; }
		public Environment Environment { get; set; }
		public Settings Settings { get; set; }
		public PropertyList Properties { get; set; }
		public Failure Failure { get; set; }
		public List<TestSuite> TestSuites { get; set; }
		public Reason Reason { get; set; }
		public List<TestCase> TestCases { get; set; }
	}

	public class Results
	{
		public TestRun TestRun { get; set; }
	}

	public class TestCase : TestBase
	{
		public string Name { get; set; }
		public string FullName { get; set; }
		public string MethodName { get; set; }
		public string ClassName { get; set; }
		public string RunState { get; set; }
		public int Seed { get; set; }
		public string Site { get; set; }
		public PropertyList Properties { get; set; }
		public Reason Reason { get; set; }
		public Failure Failure { get; set; }
	}

	public class Environment
	{
		public string FrameworkVersion { get; set; }
		public string ClrVersion { get; set; }
		public string OsVersion { get; set; }
		public string Platform { get; set; }
		public string Cwd { get; set; }
		public string MachineName { get; set; }
		public string User { get; set; }
		public string UserDomain { get; set; }
		public string Culture { get; set; }
		public string UiCulture { get; set; }
		public string OsArchitecture { get; set; }
	}

	public class Setting
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}

	public class Settings : List<Setting>
	{
	}

	public class Property
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}

	public class PropertyList : List<Property>
	{
	}

	public class Failure
	{
		public string Message { get; set; }
		public string StackTrace { get; set; }
	}

	public class Reason
	{
		public string Message { get; set; }
	}
}
