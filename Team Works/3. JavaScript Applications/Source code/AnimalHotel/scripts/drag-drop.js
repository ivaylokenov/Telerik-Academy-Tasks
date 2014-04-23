
function drag(ev) {
    if (!ev) {
        ev = window.event;
    }
    // update
    dragSrcEl = (window.event) ? window.event.srcElement /* for IE */ : ev.target;
    var stringData = (dragSrcEl.id).toString();
    ev.dataTransfer.setData("Text", stringData);
};

function allowDrop(ev) {
    if (!ev)
        ev = window.event;
    ev.preventDefault();
};

function cure(ev) {
    var targ;
    if (!ev)
        ev = window.event;
    if (ev.target)
        targ = ev.target;
    else if (ev.srcElement) targ = ev.srcElement;

    ev.preventDefault();
    var data = ev.dataTransfer.getData("Text");
    var doctorsLeft = parseInt($('#doctors-left').text());

    if (doctorsLeft == 0) {
        return;
    }
    else if (data.substring(0, 3) == "cat") {
        doctorsLeft--;
        $('#doctors-left').text(doctorsLeft);
        roomId = data.substring(data.indexOf('t') + 1);
        sanMarino.rooms[parseInt(roomId)].roomer._super.health += 1;
    }
}

function dragonFeed(ev) {
    var targ;
    if (!ev)
        ev = window.event;
    ev.preventDefault();
    var data = ev.dataTransfer.getData("Text");
    if (data.substring(0, 3) == "cat") {
        roomId = data.substring(data.indexOf('t') + 1);
        sanMarino.rooms[11].roomer._super.hunger += 10;
        sanMarino.rooms[parseInt(roomId)].removeRoomer();
    }
    if (data == "food") {
        sanMarino.rooms[11].roomer._super.hunger -= 100;
    }
}

function findCat(ev) {
    var targ;
    if (!ev)
        ev = window.event;
    if (ev.target)
        targ = ev.target;
    else if (ev.srcElement) targ = ev.srcElement;

    ev.preventDefault();

    var data = ev.dataTransfer.getData("Text");
    if (data == "food" && targ.id.substring(0, 3) == "cat") {
        var roomId = targ.parentNode.parentNode.id;
        roomId = roomId.substring(roomId.indexOf('m') + 1);

        sanMarino.rooms[parseInt(roomId)].roomer._super.hunger = 10;
    }
}

function catWalk(ev) {
    if (!ev) {
        ev = window.event;
    }
    ev.preventDefault();
    var data = ev.dataTransfer.getData("Text");
    if (data.substring(0, 3) == "cat") {
        roomId = data.substring(data.indexOf('t') + 1);
        if (sanMarino.rooms[parseInt(roomId)].roomer.mood == 0) {
            sanMarino.rooms[parseInt(roomId)].roomer.mood += 0;
        }

        else {
            sanMarino.rooms[parseInt(roomId)].roomer.mood += 10;
        }
    }
}