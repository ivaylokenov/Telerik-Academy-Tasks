var customConsole = (function () {
    function formatString(formatedTokens) {
        var result = formatedTokens[0].toString();

        for (var i = 1; i < formatedTokens.length; i++) {
            var searchedString = "{" + (i-1) + "}";
            result = result.replace(searchedString, formatedTokens[i]);
        }

        return result.toString();
    }

    return {
        writeLine: function () {
            var message = arguments[0].toString();
            if (arguments.length == 1) {
                console.log(message.toString());
            }
            else {
                var tokens = arguments;
                message = formatString(tokens);
                console.log(message.toString());
            }
        },

        writeError: function () {
            var message = arguments[0].toString();
            if (arguments.length == 1) {
                console.error("Error: " + message.toString());
            }
            else {
                var tokens = arguments;
                message = formatString(tokens);
                console.error(message.toString());
            }
        },

        writeWarning: function () {
        var message = arguments[0].toString();
        if (arguments.length == 1) {
            console.warning("Warning: " + message.toString());
        }
        else {
            var tokens = arguments;
            message = formatString(tokens);
            console.warning(message.toString());
        }
    }
    }
})();

customConsole.writeLine("Some testing thing!");
var word = "Another";
customConsole.writeLine("{0} {1} {2}{3}", word, "testing", "thing", "!");
customConsole.writeError("{0}", "Error!");
customConsole.writeWarning("{0} {1}", word, "warning!");