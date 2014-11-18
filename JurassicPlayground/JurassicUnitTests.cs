using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JurassicPlayground
{
    [TestClass]
    public class JurassicUnitTests
    {
        [TestMethod]
        public void FormatDateTest()
        {
            var engine = JurassicFunctions.GetNewEngine();

            engine.ExecuteFile("Scripts/Testme.js");

            var result = engine.Evaluate<string>("FormatDate(new Date(1995,9,2))");

            Assert.AreEqual("10/02/1995", result);
        }

        [TestMethod]
        public void OnCurrencyKeyPressTest()
        {
            var engine = JurassicFunctions.GetNewEngine();

            engine.ExecuteFile("Scripts/TestMe.js");

            engine.Execute(@"
                var e = [];
                e.target = [];
                e.target.value = 37.954;

                var textbox = [];

                var jqueryObject = [];
                jqueryObject.data = function () { return textbox; }

                var $ = function () { return jqueryObject; }
            ");

            engine.Execute("OnCurrencyKeyPress(e)");

            var result = engine.Evaluate<int>("textbox.digits");

            Assert.AreEqual(3, result);
        }
    }
}
