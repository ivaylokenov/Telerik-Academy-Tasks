function onBodyLoad() {

    function domModule() {

        var buffer = [];

        return {
            appendChildElement: function (element, selector) {
                var parent = document.querySelector(selector);
                parent.appendChild(element);
            },

            removeChildElement: function (parent, selector) {
                var parents = document.querySelectorAll(parent);
                selector = parent + " > " + selector;
                var toBeRemoved = document.querySelector(selector);

                for (var i = 0; i < parents.length; i++) {
                    parents[i].removeChild(toBeRemoved);
                }
            },

            addEventHandler: function (selector, eventName, listener) {
                var element = document.querySelector(selector);
                element.addEventListener(eventName, listener, false);
            },

            getElements: function (selector) {
                var elements = document.querySelectorAll(selector);
                return elements;
            },

            addToBuffer: function (parent, element) {
                if (!buffer[parent]) {
                    buffer[parent] = document.createDocumentFragment();
                }

                buffer[parent].appendChild(element);

                if (buffer[parent].childNodes.length === 100) { //make this === 5 to test the buffer
                    var appendTo = document.querySelector(parent);
                    appendTo.appendChild(buffer[parent]);
                    buffer[parent] = null;
                }
            },
        };
    }

    var module = new domModule();

    var divWrapper = document.createElement("div");
    divWrapper.id = "wrapper";
    divWrapper.innerHTML = "I am crazy rapper! Click on <strong>'Child: 1'</strong> for magic!";

    module.appendChildElement(divWrapper, "body");

    for (var i = 1; i <= 5; i++) {
        var div = document.createElement("div");
        div.id = "child" + i.toString();
        div.innerHTML ="Child: " + i;
        module.appendChildElement(div, "#wrapper");
    }

    module.removeChildElement("#wrapper", "#child3");
    module.removeChildElement("#wrapper", "div:last-child");

    module.addEventHandler("#child1", 'click', function (event) {
        event.currentTarget.style.fontSize = "25px";
    });

    var allDivChilds = module.getElements("#wrapper > div");
    console.log("Selected all div childs of #wrapper: " + allDivChilds.length);

    for (var j = 1; j <= 7; j++) {
        var someElement = document.createElement("div");
        someElement.innerHTML = "Buffer element " + j;
        module.addToBuffer("#wrapper", someElement);
    }
}

document.body.onload = onBodyLoad;