using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace TestResultsViewer
{
	public class Parser
	{
		private const string Zero = "0";

		//Element names
		private readonly XName TestRunElement = XName.Get("test-run");
		private readonly XName CommandLineElement = XName.Get("command-line");
		private readonly XName TestSuiteElement = XName.Get("test-suite");
		private readonly XName TestCaseElement = XName.Get("test-case");
		private readonly XName EnvironmentElement = XName.Get("environment");
		private readonly XName SettingsElement = XName.Get("settings");
		private readonly XName SettingElement = XName.Get("setting");
		private readonly XName PropertiesElement = XName.Get("properties");
		private readonly XName PropertyElement = XName.Get("property");
		private readonly XName FailureElement = XName.Get("failure");
		private readonly XName MessageElement = XName.Get("message");
		private readonly XName ReasonElement = XName.Get("reason");
		private readonly XName StackTraceElement = XName.Get("stack-trace");

		//Attribute names
		private readonly XName IdAttribute = XName.Get("id");
		private readonly XName TestCaseCountAttribute = XName.Get("testcasecount");
		private readonly XName ResultAttribute = XName.Get("result");
		private readonly XName LabelAttribute = XName.Get("label");
		private readonly XName TotalAttribute = XName.Get("total");
		private readonly XName PassedAttribute = XName.Get("passed");
		private readonly XName FailedAttribute = XName.Get("failed");
		private readonly XName InconclusiveAttribute = XName.Get("inconclusive");
		private readonly XName SkippedAttribute = XName.Get("skipped");
		private readonly XName AssertsAttribute = XName.Get("asserts");
		private readonly XName EngineVersionAttribute = XName.Get("engine-version");
		private readonly XName ClrVersionAttribute = XName.Get("clr-version");
		private readonly XName StartTimeAttribute = XName.Get("start-time");
		private readonly XName EndTimeAttribute = XName.Get("end-time");
		private readonly XName DurationAttribute = XName.Get("duration");
		private readonly XName NameAttribute = XName.Get("name");
		private readonly XName FullNameAttribute = XName.Get("fullname");
		private readonly XName MethodNameAttribute = XName.Get("methodname");
		private readonly XName ClassNameAttribute = XName.Get("classname");
		private readonly XName RunStateAttribute = XName.Get("runstate");
		private readonly XName SeedAttribute = XName.Get("seed");
		private readonly XName ValueAttribute = XName.Get("value");
		private readonly XName TypeAttribute = XName.Get("type");
		private readonly XName SiteAttribute = XName.Get("site");
		private readonly XName FrameworkVersionAttribute = XName.Get("framework-version");
		private readonly XName OsVersionAttribute = XName.Get("os-version");
		private readonly XName PlatformAttribute = XName.Get("platform");
		private readonly XName CwdAttribute = XName.Get("cwd");
		private readonly XName MachineNameAttribute = XName.Get("machine-name");
		private readonly XName UserAttribute = XName.Get("user");
		private readonly XName UserDomainAttribute = XName.Get("user-domain");
		private readonly XName CultureAttribute = XName.Get("culture");
		private readonly XName UiCultureAttribute = XName.Get("uiculture");
		private readonly XName OsArchitectureAttribute = XName.Get("os-architecture");

		private string _fileName;
		private XDocument _xdoc;

		public Parser(string fileName)
		{
			_fileName = fileName;
			_xdoc = XDocument.Load(_fileName);
		}

		public Results Results()
		{
			var results = new Results();
			results.TestRun = TestRun(_xdoc.Element(TestRunElement));
			return results;
		}

		public TestRun TestRun(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var testRun = new TestRun();
			testRun.Id = element.Attribute(IdAttribute)?.Value;
			testRun.TestCaseCount = int.Parse(element.Attribute(TestCaseCountAttribute)?.Value ?? Zero);
			testRun.Result = element.Attribute(ResultAttribute)?.Value;
			testRun.Label = element.Attribute(LabelAttribute)?.Value;
			testRun.Total = int.Parse(element.Attribute(TotalAttribute)?.Value ?? Zero);
			testRun.Passed = int.Parse(element.Attribute(PassedAttribute)?.Value ?? Zero);
			testRun.Failed = int.Parse(element.Attribute(FailedAttribute)?.Value ?? Zero);
			testRun.Inconclusive = int.Parse(element.Attribute(InconclusiveAttribute)?.Value ?? Zero);
			testRun.Skipped = int.Parse(element.Attribute(SkippedAttribute)?.Value ?? Zero);
			testRun.Asserts = int.Parse(element.Attribute(AssertsAttribute)?.Value ?? Zero);
			testRun.EngineVersion = element.Attribute(EngineVersionAttribute)?.Value;
			testRun.ClrVersion = element.Attribute(ClrVersionAttribute)?.Value;
			testRun.Duration = double.Parse(element.Attribute(DurationAttribute)?.Value ?? Zero);
			try
			{
				testRun.StartTime = DateTime.Parse(element.Attribute(StartTimeAttribute)?.Value);
			}
			catch {}

			try
			{
				testRun.EndTime = DateTime.Parse(element.Attribute(EndTimeAttribute)?.Value);
			}
			catch {}

			testRun.CommandLine = GetCdata(element.Element(CommandLineElement)?.FirstNode);
			testRun.TestSuite = TestSuite(element.Element(TestSuiteElement));
			return testRun;
		}

		public TestSuite TestSuite(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var testSuite = new TestSuite();
			testSuite.Type = element.Attribute(TypeAttribute)?.Value;
			testSuite.Id = element.Attribute(IdAttribute)?.Value;
			testSuite.Name = element.Attribute(NameAttribute)?.Value;
			testSuite.FullName = element.Attribute(FullNameAttribute)?.Value;
			testSuite.ClassName = element.Attribute(ClassNameAttribute)?.Value;
			testSuite.RunState = element.Attribute(RunStateAttribute)?.Value;
			testSuite.TestCaseCount = int.Parse(element.Attribute(TestCaseCountAttribute)?.Value ?? Zero);
			testSuite.Result = element.Attribute(ResultAttribute)?.Value;
			testSuite.Label = element.Attribute(LabelAttribute)?.Value;
			testSuite.Duration = double.Parse(element.Attribute(DurationAttribute)?.Value ?? Zero);
			testSuite.Total = int.Parse(element.Attribute(TotalAttribute)?.Value ?? Zero);
			testSuite.Passed = int.Parse(element.Attribute(PassedAttribute)?.Value ?? Zero);
			testSuite.Failed = int.Parse(element.Attribute(FailedAttribute)?.Value ?? Zero);
			testSuite.Inconclusive = int.Parse(element.Attribute(InconclusiveAttribute)?.Value ?? Zero);
			testSuite.Skipped = int.Parse(element.Attribute(SkippedAttribute)?.Value ?? Zero);
			testSuite.Asserts = int.Parse(element.Attribute(AssertsAttribute)?.Value ?? Zero);
			try
			{
				testSuite.StartTime = DateTime.Parse(element.Attribute(StartTimeAttribute)?.Value);
			}
			catch { }

			try
			{
				testSuite.EndTime = DateTime.Parse(element.Attribute(EndTimeAttribute)?.Value);
			}
			catch { }

			testSuite.Environment = Environment(element.Element(EnvironmentElement));
			testSuite.Settings = Settings(element.Element(SettingsElement));
			testSuite.Properties = PropertyList(element.Element(PropertiesElement));
			testSuite.Reason = Reason(element.Element(ReasonElement));
			testSuite.Failure = Failure(element.Element(FailureElement));
			testSuite.TestSuites = new List<TestSuite>();
			foreach (var ts in element.Elements(TestSuiteElement))
			{
				testSuite.TestSuites.Add(TestSuite(ts));
			}

			testSuite.TestCases = new List<TestCase>();
			foreach (var tc in element.Elements(TestCaseElement))
			{
				testSuite.TestCases.Add(TestCase(tc));
			}

			return testSuite;
		}

		public Environment Environment(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var environment = new Environment();
			environment.FrameworkVersion = element.Attribute(FrameworkVersionAttribute)?.Value;
			environment.ClrVersion = element.Attribute(ClrVersionAttribute)?.Value;
			environment.OsVersion = element.Attribute(OsVersionAttribute)?.Value;
			environment.Platform = element.Attribute(PlatformAttribute)?.Value;
			environment.Cwd = element.Attribute(CwdAttribute)?.Value;
			environment.MachineName = element.Attribute(MachineNameAttribute)?.Value;
			environment.User = element.Attribute(UserAttribute)?.Value;
			environment.UserDomain = element.Attribute(UserDomainAttribute)?.Value;
			environment.Culture = element.Attribute(CultureAttribute)?.Value;
			environment.UiCulture = element.Attribute(UiCultureAttribute)?.Value;
			environment.OsArchitecture = element.Attribute(OsArchitectureAttribute)?.Value;
			return environment;
		}

		public TestCase TestCase(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var testCase = new TestCase();
			testCase.Id = element.Attribute(IdAttribute)?.Value;
			testCase.Name = element.Attribute(NameAttribute)?.Value;
			testCase.FullName = element.Attribute(FullNameAttribute)?.Value;
			testCase.MethodName = element.Attribute(MethodNameAttribute)?.Value;
			testCase.ClassName = element.Attribute(ClassNameAttribute)?.Value;
			testCase.RunState = element.Attribute(RunStateAttribute)?.Value;
			testCase.Seed = int.Parse(element.Attribute(SeedAttribute)?.Value ?? Zero);
			testCase.Result = element.Attribute(ResultAttribute)?.Value;
			testCase.Label = element.Attribute(LabelAttribute)?.Value;
			testCase.Site = element.Attribute(SiteAttribute)?.Value;
			testCase.Duration = double.Parse(element.Attribute(DurationAttribute)?.Value ?? Zero);
			testCase.Asserts = int.Parse(element.Attribute(AssertsAttribute)?.Value ?? Zero);
			try
			{
				testCase.StartTime = DateTime.Parse(element.Attribute(StartTimeAttribute)?.Value);
			}
			catch { }

			try
			{
				testCase.EndTime = DateTime.Parse(element.Attribute(EndTimeAttribute)?.Value);
			}
			catch { }

			testCase.Properties = PropertyList(element.Element(PropertiesElement));
			testCase.Reason = Reason(element.Element(ReasonElement));
			testCase.Failure = Failure(element.Element(FailureElement));
			return testCase;
		}

		public Settings Settings(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var settings = new Settings();
			foreach (var setting in element.Elements(SettingElement))
			{
				settings.Add(Setting(setting));
			}
			return settings;
		}

		public Setting Setting(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var setting = new Setting();
			setting.Name = element.Attribute(NameAttribute)?.Value;
			setting.Value = element.Attribute(ValueAttribute)?.Value;
			return setting;
		}

		public PropertyList PropertyList(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var propertyList = new PropertyList();
			foreach (var property in element.Elements(PropertyElement))
			{
				propertyList.Add(Property(property));
			}
			return propertyList;
		}

		public Property Property(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var property = new Property();
			property.Name = element.Attribute(NameAttribute)?.Value;
			property.Value = element.Attribute(ValueAttribute)?.Value;
			return property;
		}

		public Reason Reason(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var reason = new Reason();
			reason.Message = GetCdata(element.Element(MessageElement)?.FirstNode);
			return reason;
		}

		public Failure Failure(XElement element)
		{
			if (element == null)
			{
				return null;
			}

			var failure = new Failure();
			failure.Message = GetCdata(element.Element(MessageElement)?.FirstNode);
			return failure;
		}

		private string GetCdata(XNode node)
		{
			if (node == null)
			{
				return null;
			}

			var reader = node.CreateReader();
			if (reader.NodeType == XmlNodeType.CDATA)
			{
				return reader.Value;
			}

			return null;
		}
	}
}
