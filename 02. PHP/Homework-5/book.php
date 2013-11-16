<!--Header-->
<?php
$pageTitle = 'Списък с книги';
require 'header.php';
?>

<!--Body-->
<?php
// Check if book_id and book_title are not empty. Else print error and exit.
if (isset($_GET['book_title']) && isset($_GET['book_id'])) {
    $currBook = $_GET['book_title'];
    $currBookID = $_GET['book_id'];
    
    CheckIfBookExists($connection, $currBookID, $currBook);
}
else {
    echo '<h1>Моля изберете книга от списъка!</h1>';
    echo '<h1>Върнете се в началото!</h1>';
    exit;
}

// Get book authors
$query = 'SELECT authors.author_name FROM books_authors
          INNER JOIN authors ON authors.author_id = books_authors.author_id
          WHERE books_authors.book_id = '.$currBookID;

$completedQuery = mysqli_query($connection, $query);

$currBookAuthors = '';

while ($row = $completedQuery->fetch_assoc()) {
    $currBookAuthors .= '<a href="books_from_author.php?author_name='.$row['author_name'].'">'.$row['author_name'].'</a> ';    
}

echo '<h2>Книга <b>"'.$currBook.'"</h2></b>';
echo '<h2>Автори: '.$currBookAuthors.'</h2>';

$query = 'SELECT users.user_name, books_comments.comment, books_comments.date_posted
          FROM books_comments
          INNER JOIN users ON users.user_id = books_comments.user_id
          WHERE books_comments.book_id = '.$currBookID.'
          ORDER BY books_comments.date_posted ASC';     // Хронологичен ред. Не трябва да е DESC.

$completedQuery = mysqli_query($connection, $query);

if (!$completedQuery) {
    include 'error_in_query.php';
}
else {
    if (UserIsLogged()) {
        echo '<form method = "GET">
                <h3><a href = "new_book_comment.php?book_title='.$currBook.'&book_id='.$currBookID.'">Добави нов коментар</a></h3>
              </form>';
    }
        
    if ($completedQuery->num_rows <= 0) {
        echo '<h1>Няма коментари за книгата</h1>';
    }
    else {        
        echo '<table border = 2>
            <tr><td><b>Потребител</b></td><td><b>Коментар</b></td><td><b>Дата</b></td></tr>';
        
        while($row = $completedQuery->fetch_assoc()) {
            echo '<tr><td><a href = "all_comments_of_user.php?user_name='.$row['user_name'].'">'.$row['user_name'].'</a></td><td>'.$row['comment'].'</td><td>'.$row['date_posted'].'</td></tr>';
        }
        echo '</table>';
    }
}
?>

<!--Footer-->
<?php
include 'footer.php';
?>
