function changeBodyColor() {
    var inputColorElement = document.querySelector('input[type="color"]');

    document.body.style.backgroundColor = inputColorElement.value;
}