<!--Header-->
<?php
$pageTitle = 'Коментари на потребител';
include 'header.php';
?>

<!--Body-->
<?php
$currUser = $_GET['user_name'];

// Check if user exists
$query = 'SELECT user_id FROM users
          WHERE user_name = "'.$currUser.'"';
$completedQuery = mysqli_query($connection, $query);

if (!$completedQuery) {
    include 'error_in_query.php';
}
else {
    if ($completedQuery->num_rows <=0) {
        echo '<h1>Несъществуващ потребител!</h1>';
        
        exit;
    }
}

// Show all comments of the current user.
echo '<h1> Коментари на потребител "'.$currUser.'"</h1>';

$query = 'SELECT books.book_title, books.book_id, books_comments.comment, books_comments.date_posted FROM books_comments
          INNER JOIN users ON books_comments.user_id = users.user_id
          INNER JOIN books ON books_comments.book_id = books.book_id
          WHERE users.user_name = "'.$currUser.'"
          ORDER BY date_posted ASC';
$completedQuery = mysqli_query($connection, $query);

if (!$completedQuery) {
    include 'error_in_query.php';
}
else {
    if ($completedQuery->num_rows <=0) {
        echo '<h1>Потребителят все още няма коментари!</h1>';
    }
    else {
        echo '<table border = 2>
            <tr><td>Книга</td><td>Коментар</td><td>Дата</td></tr>';
        
        while ($row = $completedQuery->fetch_assoc()) {
            echo '<tr>
                    <td><a href="book.php?book_title='.$row['book_title'].'&book_id='.$row['book_id'].'">'.$row['book_title'].'</a></td>
                    <td>'.$row['comment'].'</td>
                    <td>'.$row['date_posted'].'</td>
                  </tr>';
        }
        
        echo '</table>';
    }
}
?>

<!--Footer-->
<?php
include 'footer.php';
?>