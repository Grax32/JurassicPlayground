# Creating scriptable applications with Jurassic
####Twitter: @grax
####Web: http://grax.com/ 
####GitHub: https://github.com/Grax32/
####CodePlex: https://ffastinjector.codeplex.com/

---
## What is Jurassic?

Jurassic is an implementation of the ECMAScript language and runtime. It aims to provide the best performing and most standards-compliant implementation of JavaScript for .NET. Jurassic is not intended for end-users; instead it is intended to be integrated into .NET programs. If you are the author of a .NET program, you can use Jurassic to compile and execute JavaScript code.

## Install Jurassic

[Source Code and Documentation: https://jurassic.codeplex.com/](https://jurassic.codeplex.com/)

`install-package jurassic`

## Call a JavaScript from C# 

###Set Build Action on JavaScript files to "Content" and "Copy Always"

###Create script engine in C# 

    var engine = new ScriptEngine
    {
        EnableDebugging = true // do not enable in production
    };

    engine.ExecuteFile("Scripts/ScriptMe.js");
    engine.Execute(@"
        var name = 'George';
        SayHello(name);
    ")

## Call a C# function from JavaScript

* Inherit from ObjectInstance
* Pass a ScriptEngine object to the constructor
* Decorate functions to call with [JSFunction]
* Call PopulateFunctions when creating new instance
* Call `engine.SetGlobalValue("ScriptMe", scriptMe);` to create global variable that will be accessible in JavaScript

## Return a C# object to JavaScript

* Two Classes, Class to return and Constructor class
* I have nested them in my demo.  The documentation shows them as 2 distinct classes
* Constructor class
    - inherits from ClrFunction
    - contains one method called Construct and decorated with `[JSConstructorFunction]`
    - Construct method accepts the parameters that will be passed to the instance constructor

* Instance class
    - inherits from ObjectInstance
    - has two constructors, one for "setup" and one for creating a new instance
    - calls PopulateFunctions in the "setup" constructor
    - Processes passed-in parameters in the "instance" constructor

## Create an MS Unit Test

###Link JavaScript file to test into testing project

* Use Add / Existing Item
* Navigate to JavaScript file in web project
* Change the "Add" dropdown to "Add As Link"

## Fakes in JavaScript

###Two things to be faked.  Objects and functions

####Object fake 
    var ObjectFake = []

Now you can read any property on ObjectFake by calling

    var result = ObjectFake.AnyProperty

and it will returned undefined
You can set any property on ObjectFake by doing something like

    ObjectFake.AnyProperty = 47;

###Function fake
    function ConvertDateString() {} // returns undefined

    function $() {} // $ is just another function name

    ObjectFake.UpdateObject = function () {}

    ObjectFake.GetDescription = function () {
        return "Something"; 
    }

###Mix and Match

    var jQueryObject = [];
    jQueryObject.find = function () { return true; }
    var $ = function () { return jQueryObject; }

called with

    var result = $(anything, anything).find(anything);

