function countDivsOnCurrentWebPage() {
    'use strict';

    console.log('There are %d div elements.',
        document.getElementsByTagName("div").length);
}

window.onload = function onWindowLoad() {
    'use strict';

    countDivsOnCurrentWebPage();
};