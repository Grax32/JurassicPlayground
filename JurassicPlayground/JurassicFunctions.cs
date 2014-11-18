using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Jurassic;
using Jurassic.Library;

namespace JurassicPlayground
{
    public static class JurassicFunctions
    {
        public static ScriptEngine GetNewEngine()
        {
            var engine = new ScriptEngine { EnableDebugging = true };

            engine.SetGlobalValue("console", new FirebugConsole(engine));
            if (Debugger.IsAttached) { Console.SetOut(new DebugWriter()); }

            return engine;
        }


        /// <summary>
        /// A TextWriter that outputs to the debug output window
        /// </summary>
        class DebugWriter : TextWriter
        {
            public override void WriteLine(string value)
            {
                Debug.WriteLine("JS: " + value);
                base.WriteLine(value);
            }

            public override void Write(string value)
            {
                Debug.Write(value);
                base.Write(value);
            }

            public override Encoding Encoding { get { return Encoding.Unicode; } }
        }
    }
}
