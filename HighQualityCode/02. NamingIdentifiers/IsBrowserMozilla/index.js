function onButtonClick(event, args) {
    'use strict';

    var currWindow = window,
        currBrowser = currWindow.navigator.appCodeName,
        isBrowserMozilla = currBrowser === "Mozilla";

    if (isBrowserMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
