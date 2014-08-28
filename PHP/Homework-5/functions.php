<?php
// Check if there is a logged user.
function UserIsLogged() {
    if (isset($_SESSION['isLogged']) && $_SESSION['isLogged'] == true) {
        return true;
    }
    
    return false;
}

// Check if the books exists. Prevent DB injections.
function CheckIfBookExists($connection, $book_id, $book_title) {
    $query = 'SELECT book_id FROM books
          WHERE book_id = '.$book_id.'
          AND book_title = "'.$book_title.'"';
    $completedQuery = mysqli_query($connection, $query);
    
    if (!$completedQuery) {
        include 'error_in_query.php';
    }
    else {
        if ($completedQuery->num_rows <= 0) {
            echo '<h1>Книгата несъществува!</h1>';
            exit;
        }
    }
}
?>