var Human;

Human = function (firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
};

Human.prototype.toString = function () {
    return 'Firstname: ' + this.firstName + ', Lastname: ' + this.lastName;
}