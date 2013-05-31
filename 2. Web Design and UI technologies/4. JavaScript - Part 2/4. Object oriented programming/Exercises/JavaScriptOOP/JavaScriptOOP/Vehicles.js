Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
};

Function.prototype.extend = function (parent) {
    for (var i = 1; i < arguments.length; i += 1) {
        var property = arguments[i];
        this.prototype[property] = parent.prototype[property];
    }

    return this;
}

//propulsion unit details
function PropulsionUnit() {
}

PropulsionUnit.prototype.Acceleration = function () {
    throw new Error("Acceleration is not defined!");
};

//wheel details
function Wheel(radius) {
    this.radius = radius;

}

Wheel.inherit(PropulsionUnit);

Wheel.prototype.Acceleration = function () {
    return 2 * Math.PI * this.radius;
};

//propelling nozzle details
function PropellingNozzle(power, afterburnerSwitch) {
    this.afterburner = afterburnerSwitch;
    this.power = power;
}

PropellingNozzle.inherit(PropulsionUnit);

PropellingNozzle.prototype.Acceleration = function () {
    if (this.afterburner === "ON") {
        return this.power * 2;
    }
    else if (this.afterburner === "OFF") {
        return this.power;
    }
    else {
        throw new Error("Afterburner state is not correctly defined!");
    }
};

//propeller details
function Propeller(fins, spinDirection) {
    this.spin = spinDirection;
    this.fins = fins;
}

Propeller.inherit(PropulsionUnit);

Propeller.prototype.Acceleration = function () {
    if (this.spin === "clockwise") {
        return this.fins;
    }
    else if (this.spin === "counter-clockwise") {
        return -this.fins;
    }
    else {
        throw new Error("Spin direction is not correctly defined!");
    }
};

//Vehicle details
function Vehicle(propulsionUnits) {
    this.speed = 0;
    this.propulsionUnits = propulsionUnits;
}

Vehicle.prototype.Accelerate = function () {
    for (var i = 0; i < this.propulsionUnits.length; i++) {
        this.speed += this.propulsionUnits[i].Acceleration();
    }
};

//Land vehicle details
function LandVehicle(wheels) {
    if (wheels.length !== 4) {
        throw new Error("Land vehicles can have 4 wheels!");
    }
    Vehicle.call(this, wheels);
}

LandVehicle.inherit(Vehicle);

//Air vehicle details
function AirVehicle(propellingNozzle) {
    if (arguments.length != 1) {
        throw new Error("Air vehicles can have 1 propelling nozzle!");
    }
    Vehicle.call(this, propellingNozzle);
}

AirVehicle.inherit(Vehicle);

AirVehicle.prototype.changeAfterburnerState = function () {
    for (var i = 0; i < this.propulsionUnits.length; i++) {
        if (this.propulsionUnits[i] instanceof PropellingNozzle) {
            if (this.propulsionUnits[i].afterburner === "ON") {
                this.propulsionUnits[i].afterburner = "OFF";
            }
            else if (this.propulsionUnits[i].afterburner === "OFF") {
                this.propulsionUnits[i].afterburner = "ON";
            }
            else {
                throw new Error("Afterburner state is not valid!");
            }
        }
    }
}

//water vehicle details
function WaterVehicle(propellers) {
    var propeler = [];
    propeler.push(propellers);
    Vehicle.call(this, propeler);
}

WaterVehicle.inherit(Vehicle);

WaterVehicle.prototype.changePropellersSpinDirection = function () {
    for (var i = 0; i < this.propulsionUnits.length; i++) {
        if (this.propulsionUnits[i] instanceof Propeller) {
            if (this.propulsionUnits[i].spin === "clockwise") {
                this.propulsionUnits[i].spin = "counter-clockwise";
            }
            else if (this.propulsionUnits[i].spin === "counter-clockwise") {
                this.propulsionUnits[i].spin = "clockwise";
            }
            else {
                throw new Error("Spin direction is not valid!");
            }
        }
    }
}

//amphibious vehicle details
function AmphibiousVehicle(propeller, wheels, state) {
    var propulsionUnits = [];
    propulsionUnits.push(propeller);

    for (var i = 0; i < wheels.length; i++) {
        propulsionUnits.push(wheels[i]);
    }

    Vehicle.call(this, propulsionUnits);
    this.state = state;
}

AmphibiousVehicle.inherit(Vehicle);
AmphibiousVehicle.extend(WaterVehicle, "changePropellersSpinDirection");

AmphibiousVehicle.prototype.changeState = function () {
    if (this.state === "Land") {
        this.state = "Water";
    }
    else if (this.state === "Water") {
        this.state = "Land";
    }
    else {
        throw new Error("State is not correctly defined!");
    }
}

AmphibiousVehicle.prototype.Accelerate = function () {
    if (this.state === "Land") {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof Wheel) {
                this.speed += this.propulsionUnits[i].Acceleration();
            }
        }
    }
    else if (this.state === "Water") {
        this.speed += this.propulsionUnits[0].Acceleration();
    }
}

//Testing
var wheels = [];
wheels.push(new Wheel(4));
wheels.push(new Wheel(5));
wheels.push(new Wheel(2));
wheels.push(new Wheel(1));

var landVehicle = new LandVehicle(wheels);
landVehicle.Accelerate();
console.log(landVehicle.speed);

var nozzles = [];
nozzles.push(new PropellingNozzle(8, "ON"));
nozzles.push(new PropellingNozzle(8, "OFF"));
nozzles.push(new PropellingNozzle(9, "ON"));
nozzles.push(new PropellingNozzle(10, "ON"));

var airVehicle = new AirVehicle(nozzles);
airVehicle.Accelerate();
console.log(airVehicle.speed);
airVehicle.changeAfterburnerState();
airVehicle.speed = 0;
airVehicle.Accelerate();
console.log(airVehicle.speed);

var somePropeller = new Propeller(5, "counter-clockwise");
var waterVehicle = new WaterVehicle(somePropeller);
waterVehicle.changePropellersSpinDirection();
waterVehicle.Accelerate();
console.log(waterVehicle.speed);

var amphibia = new AmphibiousVehicle(somePropeller, wheels, "Land");
amphibia.changeState();
amphibia.Accelerate();
console.log(amphibia.speed);