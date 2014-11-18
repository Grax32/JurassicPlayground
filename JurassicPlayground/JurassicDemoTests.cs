using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Jurassic;
using Jurassic.Library;
using JurassicPlayground.ScriptableApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JurassicPlayground
{
    [TestClass]
    public class JavaScriptCallingCSharp
    {

        [TestMethod]
        public void ExecuteJavaScript()
        {
            var engine = JurassicFunctions.GetNewEngine();

            ScriptMe.Initialize(engine);

            // execute a script file
            engine.ExecuteFile("Scripts/Simple.js");

            // execute javascript code
            engine.Execute("SayHello('George')");

            // execute and get a return value
            var result = engine.Evaluate<string>("Combine('George','Costanza')");

            Debug.Print(result);
        }

        [TestMethod]
        public void JSError()
        {
            var engine = JurassicFunctions.GetNewEngine();

            engine.ExecuteFile(Path.Combine(Environment.CurrentDirectory, "Scripts/ThrowError.js"));
        }

        [TestMethod]
        public void ExecuteJavaScriptThatCallsCSharp()
        {
            var engine = JurassicFunctions.GetNewEngine();

            ScriptMe.Initialize(engine);

            engine.ExecuteFile("Scripts/ScriptMe.js");
        }

        [TestMethod]
        public void ExecuteJavaScriptThatGetsObjectFromCSharp()
        {
            var engine = JurassicFunctions.GetNewEngine();

            Giraffe.Initialize(engine);

            engine.ExecuteFile("Scripts/Giraffe.js");
        }




    }
}
