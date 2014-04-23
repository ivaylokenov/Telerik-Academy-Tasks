if (!Object.create) {
    Object.create = function (obj) {
        function createObj() { };
        createObj.prototype = obj;
        return new createObj();
    }
}
if (!Object.prototype.extend) {
    Object.prototype.extendmethod = function (properties) {
        function createObj() { };
        createObj.prototype = Object.create(this);
        for (var prop in properties) {
            createObj.prototype[prop] = properties[prop];
        }
        createObj.prototype._super = this;
        return new createObj();
    }
}

