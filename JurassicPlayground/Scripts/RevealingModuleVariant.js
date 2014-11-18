var AppGlobal = {
    exposePrivateVariablesForTesting: true
};

var testableObject = function (exposePrivateVariablesForTesting) {
    var _privateVar = "can't see this";
    var _publicVar = "we see this fine";

    function _privateFunction() {
        console.log("Executed Private");
    }

    function _exposedFunction() {
        console.log("Exposed Function");
    }

    var returnValue = {
        ExposedFunction: _exposedFunction,
        ExposedVariable: _publicVar
    };

    if (exposePrivateVariablesForTesting) {
        $.extend(returnValue, {
            PrivateVar: _privateVar,
            PrivateFunction: _privateFunction
        });
    }

    return returnValue;
}(AppGlobal.exposePrivateVariablesForTesting);


testableObject.ExposedFunction();
console.log(testableObject.ExposedVariable);

testableObject.PrivateFunction();
console.log(testableObject.PrivateVar);

