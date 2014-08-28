var Book;

Book = function (title, author) {
    this.title = title;
    this.author = author;
};

Book.prototype.toString = function () {
    return 'Title: ' + this.title + ', Author: ' + this.author;
}