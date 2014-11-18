using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jurassic;
using Jurassic.Library;

namespace JurassicPlayground.ScriptableApi
{
    public class ScriptMe : ObjectInstance
    {
        private ScriptMe(ScriptEngine engine) : base(engine) { }

        public static void Initialize(ScriptEngine engine)
        {
            var scriptMe = new ScriptMe(engine);
            scriptMe.PopulateFunctions();

            engine.SetGlobalValue("ScriptMe", scriptMe);
        }

        [JSFunction]
        public static string GetNameById(int id)
        {
            switch (id)
            {
                case 1:
                    return ".NET User's Group";
                case 2:
                    return "Grax";
                default:
                    return null;
            }
        }
    }
}
