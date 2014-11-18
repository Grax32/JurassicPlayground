using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Jurassic;
using Jurassic.Library;

namespace JurassicPlayground.ScriptableApi
{
    public class Giraffe : ObjectInstance
    {
        const string jsName = "Giraffe";
        string _name = "";
        string _funFact = "Giraffes only spend between 10 minutes and two hours asleep per day. They have one of the shortest sleep requirements of any mammal.";

        #region #JS Constructor
        public class GiraffeConstructor : ClrFunction
        {
            public GiraffeConstructor(ScriptEngine engine)
                : base(engine.Function.InstancePrototype, jsName, new Giraffe(engine.Object.InstancePrototype))
            { }

            [JSConstructorFunction]
            public Giraffe Construct(string name)
            {
                return new Giraffe(this.InstancePrototype, name);
            }
        }
        #endregion

        private Giraffe(ObjectInstance prototype)
            : base(prototype)
        {
            this.PopulateFunctions();
        }

        /// <summary>
        /// Create a new instance with name property
        /// </summary>
        /// <param name="prototype"></param>
        /// <param name="name"></param>
        public Giraffe(ObjectInstance prototype, string name)
            : base(prototype)
        {
            _name = name;
        }

        /// <summary>
        /// Add the constructor to the JavaScript environment
        /// </summary>
        /// <param name="engine"></param>
        public static void Initialize(ScriptEngine engine)
        {
            engine.SetGlobalValue(jsName, new GiraffeConstructor(engine));
        }

        /// <summary>
        /// Function to call from JavaScript
        /// </summary>
        [JSFunction]
        public void Drink()
        {
            Debug.Print("OK. Giraffe named " + _name + " is drinking.");
        }


        [JSProperty]
        public string FunFact
        {
            get { return _funFact; }
            set
            {
                Debug.Print("Changing FunFact to " + value);
                _funFact = value;
            }
        }
    }
}
