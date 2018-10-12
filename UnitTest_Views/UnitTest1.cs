using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp_View;

namespace UnitTest_Views
{
	[TestClass]
	public class UnitTest_WpfApp_View
	{
		[TestMethod]
		public void NegativeColorSelector_Basic()
		{
			// ASSEMBLE
			NegativeColorSelector objUnderTest = new NegativeColorSelector();

			// ACT

			// ASSERT
			Assert.AreEqual("Black", (string)objUnderTest.Convert(1, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("Red", (string)objUnderTest.Convert(-1, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("Black", (string)objUnderTest.Convert(0, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("Black", (string)objUnderTest.Convert(9999, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("Red", (string)objUnderTest.Convert(-9999, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
		}

		[TestMethod]
		public void NegativeTextSelector_Int()
		{
			// ASSEMBLE
			NegativeTextSelector objUnderTest = new NegativeTextSelector();

			// ACT

			// ASSERT
			Assert.AreEqual("1", (string)objUnderTest.Convert(1, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("0", (string)objUnderTest.Convert(0, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("(1)", (string)objUnderTest.Convert(-1, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
		}

		[TestMethod]
		public void NegativeTextSelector_Decimal()
		{
			// ASSEMBLE
			NegativeTextSelector objUnderTest = new NegativeTextSelector();

			// ACT

			// ASSERT
			Assert.AreEqual("1.0", (string)objUnderTest.Convert(1.0M, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("1.00", (string)objUnderTest.Convert(1.00M, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("0.0", (string)objUnderTest.Convert(0.0M, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("(1.0)", (string)objUnderTest.Convert(-1.0M, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("(1.00)", (string)objUnderTest.Convert(-1.00M, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
		}

		[TestMethod]
		public void NegativeTextSelector_Float()
		{
			// ASSEMBLE
			NegativeTextSelector objUnderTest = new NegativeTextSelector();

			// ACT

			// ASSERT
			Assert.AreEqual("1", (string)objUnderTest.Convert(1.0f, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("1", (string)objUnderTest.Convert(1.00f, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("0", (string)objUnderTest.Convert(0.0f, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("(1)", (string)objUnderTest.Convert(-1.0f, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
			Assert.AreEqual("(1)", (string)objUnderTest.Convert(-1.00f, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture));
		}
	}
}
