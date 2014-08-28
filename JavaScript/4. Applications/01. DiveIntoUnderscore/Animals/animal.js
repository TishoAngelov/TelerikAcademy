var Animal,
    allowedLegs,
    areLegsCorrect;

allowedLegs = [2, 4, 6, 8, 100];
areLegsCorrect = false;

Animal = function (name, species, legs) {
    this.name = name;
    this.species = species;

    for (var i = 0; i < allowedLegs.length; i++) {
        if (allowedLegs[i] === legs) {
            areLegsCorrect = true;
            break;
        }
    }

    // it's better using get() and set() functions for each "field".
    if (!areLegsCorrect) {
        throw {
            message: 'Incorrect legs count of animal with name: ' + this.name
        };
    }

    this.legs = legs;
};

Animal.prototype.toString = function () {
    return 'Name: ' + this.name + ', Species: ' + this.species + ', Legs: ' + this.legs;
}