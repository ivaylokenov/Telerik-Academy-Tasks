var controls = (function () {

    var Accordion = function (holder) {

        var items = [];
        var accHolder = document.querySelector(holder);
        var mainList = document.createElement("ul");
        mainList.style.listStyleType = "none";
        accHolder.appendChild(mainList);

        accHolder.addEventListener("click", function (event) {
            event.stopPropagation();
            event.preventDefault();

            var clickedItem = event.target;

            if (!(clickedItem instanceof HTMLAnchorElement)) {
                return;
            }

            var ulSibling = clickedItem.nextElementSibling;

            if (!ulSibling) {
                return;
            }

            if (ulSibling.style.display === "none") {
                ulSibling.style.display = "";
            }
            else {
                ulSibling.style.display = "none";
            }

            var parent = clickedItem.parentNode;
            var prev = parent.previousElementSibling;
            var next = parent.nextElementSibling;

            while (prev) {
                var childrenPrev = prev.childNodes;

                for (var i = 0; i < childrenPrev.length; i++) {
                    if (childrenPrev[i] instanceof HTMLUListElement) {
                        childrenPrev[i].style.display = "none";
                    }
                }

                prev = prev.previousElementSibling;
            }

            while (next) {
                var childrenNext = next.childNodes;

                for (var i = 0; i < childrenNext.length; i++) {
                    if (childrenNext[i] instanceof HTMLUListElement) {
                        childrenNext[i].style.display = "none";
                    }
                }

                next = next.nextElementSibling;
            }

        }, false);

        this.add = function (title) {
            var itemNode = new Item(title)
            items.push(itemNode);
            return itemNode;
        }

        this.addReadyItem = function (item) {
            items.push(item);
        }

        this.render = function () {
            for (var i = 0; i < items.length; i++) {
                var liitem = document.createElement("li");
                liitem.innerHTML = "<a href='#' >" + items[i].title + "</a>";
                var childs = items[i].render();
                if (childs != 0) {
                    liitem.appendChild(childs);
                }
                mainList.appendChild(liitem);
            }
            accHolder.appendChild(mainList);
        }

        this.serialize = function () {

            var result = [];

            for (var i = 0; i < items.length; i++) {
                var serializedItem = items[i].serialize();
                result.push(serializedItem);
            }

            return JSON.stringify(result);

        }
    }

    var Item = function (title) {
        this.title = title;
        var subItems = [];

        this.add = function (title) {
            var itemNode = new Item(title)
            subItems.push(itemNode);
            return itemNode;
        }

        this.addReadyItem = function (item) {
            subItems.push(item);
        }

        this.render = function () {
            var list = document.createElement("ul");
            list.style.listStyleType = "none";
            list.style.display = "none";

            if (subItems.length > 0) {
                for (var i = 0; i < subItems.length; i++) {
                    var liitem = document.createElement("li");
                    liitem.innerHTML = "<a href='#' >" + subItems[i].title + "</a>";
                    var childs = subItems[i].render();
                    if (childs != 0) {
                        liitem.appendChild(childs);
                    }
                    list.appendChild(liitem);
                }
                return list;
            }
            else {
                return 0;
            }
        }

        this.subItems = subItems;

        this.serialize = function () {
            
            var result = [];
            
            result.push(this.title);

            if (subItems.length > 0) {
                for (var i = 0; i < subItems.length; i++) {
                    var serializedItem = subItems[i].serialize();
                    result.push(serializedItem);
                }
            }

            return result;
        }
    }

    function getAccordion(holder) {
        return new Accordion(holder);
    }

    function deserializeItem(arrayItem) {
        var currentItem = new Item(arrayItem[0]);

        if (arrayItem.length > 1) {
            for (var i = 1; i < arrayItem.length; i++) {
                var item = deserializeItem(arrayItem[i]);
                currentItem.addReadyItem(item);
            }
        }

        return currentItem;
    }

    function getDeserializedAccordion(selector, data) {
        var deserializedData = JSON.parse(data);

        var accordion = new Accordion(selector);

        for (var i = 0; i < deserializedData.length; i++) {
            var item = deserializeItem(deserializedData[i]);
            accordion.addReadyItem(item);
        }

        return accordion;

        console.log(deserializedData);
    }

    return {
        getAccordion: getAccordion,
        getDeserializedAccordion: getDeserializedAccordion
    }

}());

var accordion = controls.getAccordion("#accordion-holder");

var webItem = accordion.add("Web");

var html = webItem.add("HTML");

var html5 = html.add("5.0");

html5.add("div element");
html5.add("div rapyr!");

html.add("4.1");

webItem.add("CSS");
var js = webItem.add("JavaScript");

js.add("Stupid language");
js.add("No, it's sexy language!");

webItem.add("jQuery");
webItem.add("ASP.NET MVC");

accordion.add("Desktop");

var mobile = accordion.add("Mobile");

mobile.add("Android");
mobile.add("MacOS");

accordion.add("Embedded");

accordion.render();

var state = accordion.serialize();

localStorage.setItem("accordion-state", state);

state = localStorage.getItem("accordion-state");

var copiedAcc = controls.getDeserializedAccordion("#copied", state);

copiedAcc.render();