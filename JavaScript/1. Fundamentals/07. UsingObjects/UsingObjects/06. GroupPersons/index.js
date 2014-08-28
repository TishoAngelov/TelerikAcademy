var persons = [
        { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
        { firstname: 'Bay', lastname: 'Ivan', age: 81 },
        { firstname: 'Bay', lastname: 'Gosho', age: 3 }
    ],
    groupedByFname,
    groupedByAge;

function groupPersonsByProperty(persons, prop) {
    'use strict';

    var groupedPersons = [],
        i;

    for (i = 0; i < persons.length; i++) {
        if (groupedPersons[persons[i][prop]] === undefined) {
            groupedPersons[persons[i][prop]] = [];
        }

        groupedPersons[persons[i][prop]].push(persons[i]);
    }

    return groupedPersons;
}

function printGroupedPersons(groupedPersons, byProp) {
    'use strict';
    var currPerson,
        key,
        i;

    for (key in groupedPersons) {
        console.log('By %s - %s =>', byProp, key);

        for (i = 0; i < groupedPersons[key].length; i++) {
            currPerson = groupedPersons[key][i];
            console.log('\t %s %s %d',
                currPerson.firstname, currPerson.lastname, currPerson.age);
        }
    }
}

groupedByFname = groupPersonsByProperty(persons, 'firstname');
groupedByAge = groupPersonsByProperty(persons, 'age');

console.log(groupedByFname);
console.log(groupedByAge);
console.log();

printGroupedPersons(groupedByFname, 'firstname');
printGroupedPersons(groupedByAge, 'age');