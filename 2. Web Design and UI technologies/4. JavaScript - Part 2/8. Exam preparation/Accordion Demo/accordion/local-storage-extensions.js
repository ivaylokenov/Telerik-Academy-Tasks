(function() {
  if (!Storage.prototype.setObject) {
    Storage.prototype.setObject = function(key, obj) {
      this.setItem(key, JSON.stringify(obj));
    }
  }

  if (!Storage.prototype.getObject) {
    Storage.prototype.getObject = function(key) {
      return JSON.parse(this.getItem(key));
    }
  }
}());