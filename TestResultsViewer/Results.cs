using System;
using System.Linq;
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

		public TestBase(TestBase tb = null)
		{
			if (tb == null) return;

			Id = tb.Id;
			Label = tb.Label;
			Asserts = tb.Asserts;
			Result = tb.Result;
			StartTime = tb.StartTime;
			EndTime = tb.EndTime;
			Duration = tb.Duration;
		}
	}

	public abstract class CollectionResults : TestBase
	{
		public int TestCaseCount { get; set; }
		public int Total { get; set; }
		public int Passed { get; set; }
		public int Failed { get; set; }
		public int Inconclusive { get; set; }
		public int Skipped { get; set; }

		public CollectionResults(CollectionResults cr = null) : base(cr)
		{
			if (cr == null) return;

			TestCaseCount = cr.TestCaseCount;
			Total = cr.Total;
			Passed = cr.Passed;
			Failed = cr.Failed;
			Inconclusive = cr.Inconclusive;
			Skipped = cr.Skipped;
		}
	}

	public class TestRun : CollectionResults
	{
		public string EngineVersion { get; set; }
		public string ClrVersion { get; set; }
		public string CommandLine { get; set; }
		public TestSuite TestSuite { get; set; }

		public TestRun(TestRun tr = null) : base(tr)
		{
			if (tr == null) return;

			EngineVersion = tr.EngineVersion;
			ClrVersion = tr.ClrVersion;
			CommandLine = tr.CommandLine;
			TestSuite = new TestSuite(tr.TestSuite, null);
		}
	}

	public class TestSuite : CollectionResults, IComparable
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
		public TestSuite Parent { get; set; }

		public TestSuite(TestSuite ts = null, TestSuite parent = null) : base(ts)
		{
			Parent = parent;

			if (ts == null) return;

			Type = ts.Type;
			Name = ts.Name;
			FullName = ts.FullName;
			ClassName = ts.ClassName;
			RunState = ts.RunState;
			Environment = new Environment(ts.Environment);
			Settings = new Settings(ts.Settings);
			Properties = new PropertyList(ts.Properties);
			Failure = new Failure(ts.Failure);
			TestSuites = new List<TestSuite>();
			foreach (var item in ts.TestSuites)
			{
				TestSuites.Add(new TestSuite(item, this));
			}

			Reason = new Reason(ts.Reason);
			TestCases = new List<TestCase>(ts.TestCases);
			foreach (var item in ts.TestCases)
			{
				TestCases.Add(new TestCase(item, this));
			}
		}

		public int CompareTo(object obj)
		{
			if (obj.GetType() != typeof(TestSuite))
			{
				throw new ArgumentException(obj.GetType().ToString() + " cannot be compared with type TestSuite");
			}

			return Name.CompareTo(((TestSuite)obj).Name);
		}
	}

	public class Results
	{
		public TestRun TestRun { get; set; }

		public Results(Results r = null)
		{
			if (r == null) return;

			TestRun = new TestRun(r.TestRun);
		}
	}

	public class TestCase : TestBase, IComparable
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
		public TestSuite Parent { get; set; }

		public TestCase(TestCase tc = null, TestSuite parent = null) : base(tc)
		{
			Parent = parent;

			if (tc == null) return;

			Name = tc.Name;
			FullName = tc.FullName;
			MethodName = tc.MethodName;
			ClassName = tc.ClassName;
			RunState = tc.RunState;
			Seed = tc.Seed;
			Site = tc.Site;
			Properties = new PropertyList(tc.Properties);
			Reason = new Reason(tc.Reason);
			Failure = new Failure(tc.Failure);
		}

		public int CompareTo(object obj)
		{
			if (obj.GetType() != typeof(TestCase))
			{
				throw new ArgumentException(obj.GetType().ToString() + " cannot be compared with type TestCase");
			}

			return Name.CompareTo(((TestCase)obj).Name);
		}
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

		public Environment(Environment e = null)
		{
			if (e == null) return;

			FrameworkVersion = e.FrameworkVersion;
			ClrVersion = e.ClrVersion;
			OsVersion = e.OsVersion;
			Platform = e.Platform;
			Cwd = e.Cwd;
			MachineName = e.MachineName;
			User = e.User;
			UserDomain = e.UserDomain;
			Culture = e.Culture;
			UiCulture = e.UiCulture;
			OsArchitecture = e.OsArchitecture;
		}
	}

	public class Setting
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public Setting(Setting s = null)
		{
			Name = s?.Name;
			Value = s?.Value;
		}
	}

	public class Settings : List<Setting>
	{
		public Settings(Settings s = null)
		{
			foreach (var item in s ?? Enumerable.Empty<Setting>())
			{
				Add(new Setting(item));
			}
		}
	}

	public class Property
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public Property(Property p = null)
		{
			Name = p?.Name;
			Value = p?.Value;
		}
	}

	public class PropertyList : List<Property>
	{
		public PropertyList(PropertyList pl = null)
		{
			foreach (var item in pl ?? Enumerable.Empty<Property>())
			{
				Add(new Property(item));
			}
		}
	}

	public class Failure
	{
		public string Message { get; set; }
		public string StackTrace { get; set; }

		public Failure(Failure f = null)
		{
			Message = f?.Message;
			StackTrace = f?.StackTrace;
		}
	}

	public class Reason
	{
		public string Message { get; set; }

		public Reason(Reason r = null)
		{
			Message = r?.Message;
		}
	}
}
