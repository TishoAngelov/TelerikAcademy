var givenText = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.",
    substringToSearch = 'in';

function countSubstringMatchesInText(text, substrToSearch) {
    'use strict';

    var substrCounter = 0,
        i;

    text = text.toLowerCase();  // For case insensitive search.

    for (i = 0; i < text.length; i += 1) {
        if (text.substr(i, substrToSearch.length) === substrToSearch) {
            substrCounter += 1;
        }
    }

    return substrCounter;
}

console.log('Given text: %s', givenText);
console.log('Substring to search: %s', substringToSearch);
console.log('Result: %d', countSubstringMatchesInText(givenText, substringToSearch));