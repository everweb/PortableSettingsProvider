using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crdx.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Configuration;
namespace crdx.Settings.Tests
{
	[TestClass()]
	public class PortableSettingsProviderTests
	{

		[TestMethod()]
		public void SetPropertyValuesTest()
		{			
			string expected = "Chips";
			Properties.Settings.Default.TestSetting = expected;
			string actual = Properties.Settings.Default.TestSetting;
			Assert.AreEqual(expected, actual);
		}


		[TestMethod()]
		public void GetBlankXmlDocumentTest()
		{
			PortableSettingsProvider psp = new PortableSettingsProvider();
			XmlDocument blank = psp.GetBlankXmlDocument();
			string expected = @"<?xml version=""1.0"" encoding=""utf-8""?><settings />";
			Assert.AreEqual(expected, blank.InnerXml);
		}

		[TestMethod()]
		public void ResetTest()
		{
			//TEST//PortableSettingsProvider.OverrideMachineName("_the_machine_");
			string expected = "Chips";
			Properties.Settings.Default.TestSetting = expected;
			string actual = Properties.Settings.Default.TestSetting;
			Assert.AreEqual(expected, actual);
			//Save a known setting
			Properties.Settings.Default.Save();
			
			//Set a different value
			Properties.Settings.Default.TestSetting = "unexpected";

			//Reset
			Properties.Settings.Default.Reset();

			//Verify that the known value is restored
			Assert.AreEqual(expected, actual);
		}	

	}
}
