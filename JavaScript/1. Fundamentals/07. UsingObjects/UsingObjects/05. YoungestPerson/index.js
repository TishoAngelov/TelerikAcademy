var persons = [
        { firstname : 'Gosho', lastname: 'Petrov', age: 32 },
        { firstname: 'Bay', lastname: 'Ivan', age: 81 },
        { firstname: 'Bay', lastname: 'Gosho', age: 3 }
    ];

function findYoungestPerson(persons) {
    'use strict';

    var nameOfYoungest = '',
        youngestPerson = 1000,
        i;

    for (i = 0; i < persons.length; i++) {
        if (youngestPerson > persons[i].age) {
            youngestPerson = persons[i].age;
            nameOfYoungest = persons[i].firstname + ' ' + persons[i].lastname;
        }
    }

    return nameOfYoungest;
}

console.log('Given persons');
for (var i = 0; i < persons.length; i++) {
    console.log('Name: %s %s, Age: %d',
        persons[i].firstname, persons[i].lastname, persons[i].age);
}

console.log('Youngest person: %s', findYoungestPerson(persons));