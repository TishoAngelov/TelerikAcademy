var Student;

Student = function (firstName, lastName, age, marks) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.fullName = this.firstName + ' ' + this.lastName;
    this.age = age;
    this.marks = marks;
};