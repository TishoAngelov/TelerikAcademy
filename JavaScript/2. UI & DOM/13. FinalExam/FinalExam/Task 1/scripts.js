function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector),
        wholeSection = document.createElement('div'),
        selectedSection = document.createElement('div'),
        filterSideBar = document.createElement('div'),
        filterBox = document.createElement('div'),
        filterItemTitle = document.createElement('h1'),
        filterItemContent = document.createElement('img');

    var docFragment = document.createDocumentFragment();
    var searchField = document.createElement('input');
    searchField.type = 'text';
    var searchFieldTitle = document.createElement('p');
    searchFieldTitle.textContent = 'Filter';

    // Styles
    wholeSection.style.height = '370px';
    wholeSection.style.position = 'relative'

    selectedSection.style.styleFloat = 'left';
    selectedSection.style.width = '380px';
    selectedSection.style.height = '100%';
    selectedSection.style.display = 'inline-block';
    selectedSection.style.position = 'relative'

    filterSideBar.style.styleFloat = 'left';
    filterSideBar.style.display = 'inline-block';
    filterSideBar.style.overflowY = 'scroll';
    filterSideBar.style.position = 'relative'
    filterSideBar.style.height = '100%';
    filterSideBar.style.textAlign = 'center';

    filterItemContent.style.width = '120px';
    filterItemContent.style.borderRadius = '5px';
    filterItemTitle.style.fontSize = '20px';

    filterBox.style.width = 'auto';
    filterBox.style.height = 'auto';

    // Selected section
    function createSelectedSection(title, image) {
        var section = selectedSection.cloneNode(true),
            sectionTitle = document.createElement('h1'),
            sectionImage = document.createElement('img');


        sectionTitle.textContent = title;
        sectionImage.src = image;

        section.appendChild(sectionTitle);
        section.appendChild(sectionImage);

        selectedSection = section;        
    }

    createSelectedSection(items[0].title, items[0].url);

    

    // Filter sidebar
    filterSideBar.appendChild(searchFieldTitle)
    filterSideBar.appendChild(searchField)
    
    function onFilterBoxMouseover(ev) {
        this.style.background = '#ccc';
    }

    function onFilterBoxMouseout(ev) {
        this.style.background = '';
    }
    var documentFragmentForFilter = document.createDocumentFragment();

    for (var i = 0; i < items.length; i++) {
        var box = filterBox.cloneNode(true);
        var title = filterItemTitle.cloneNode(true);
        title.textContent = items[i].title;


        var content = filterItemContent.cloneNode(true);
        content.src = items[i].url;

        box.appendChild(title);
        box.appendChild(content);
        box.addEventListener('click', function () {
            createSelectedSection(items[i].title, items[i].url);
        });
        box.addEventListener('mouseover', onFilterBoxMouseover);
        box.addEventListener('mouseout', onFilterBoxMouseout)
        documentFragmentForFilter.appendChild(box);
    }
    filterSideBar.appendChild(documentFragmentForFilter);

    wholeSection.appendChild(selectedSection)
    wholeSection.appendChild(filterSideBar);
        
    docFragment.appendChild(wholeSection);
    container.appendChild(docFragment);
}