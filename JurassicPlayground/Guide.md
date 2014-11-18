#JavaScript Testing in MS Unit Tests

---

Web-based projects usually have a lot of JavaScript code.  By unit-testing your JavaScript, you can ensure that it performs as you intend.

Set "Default project" to target your unit tests

`install-package jurassic`

###Link JavaScript file to test into testing project

* Use Add / Existing Item
* Navigate to JavaScript file in web project
* Change the "Add" dropdown to "Add As Link"

###Decorate test class with DeploymentItem attribute

`[DeploymentItem(@".\Scripts\", "Scripts")]`

##Create new Unit Test file

###Create script engine in C# 

    var engine = new ScriptEngine
    {
        EnableDebugging = true
    };
			
###Create necessary fakes to execute JavaScript file to test

    engine.Execute(@"
        var jQueryFunctions = [];
        var jQuery = function() { return jQueryFunctions; };
        var $ = jQuery;
    ");
			
###Create new unit test

Create code to 

* arrange (arrange your test), 
* act (perform the tested action),
* assert (assert that the correct result is returned or the expected action happens)

As part of the arrange, create JavaScript fakes to satisfy dependencies of the JavaScript function you are testing

Assert that expected result is returned or the expected action occurs
