<!--Header-->
<?php
$pageTitle = 'Нов коментар';
require 'header.php';
?>

<!--Body-->
<?php
// Return to home page if the user is not logged and try to reach this page by URL.
if (!UserIsLogged()) {
    header('Location: index.php');
    exit;
}

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

// Adding new comment for the current book
echo '<h2>Добавяне на нов коментар за книгата "'.$currBook.'"</h2>';

if ($_POST) {
    $commentMinLen = 1;
    
    $comment = mysqli_real_escape_string($connection,trim($_POST['comment']));     // Prevent SQL injection. Not 100% safe.
        
    if (mb_strlen($comment) < $commentMinLen) {
        echo '<h1>Моля въведете поне '.$commentMinLen.' символ!</h1>';        
    }
    else {
        // Insert the comment in DB.
        $query = 'INSERT INTO books_comments(book_id, user_id, comment) 
            VALUES('.$currBookID.','.$_SESSION['loggedUserID'].',"'.$_POST['comment'].'")';
        $completedQuery = mysqli_query($connection, $query);    // Execute the query

        if (!$completedQuery) {
            include 'error_in_query.php';
        }
        else {     
            echo '<h1>Коментарът е добавен успешно!</h1>';
            
            // Update the comment counter in table books
            $query = 'UPDATE books
                      SET count_comments = count_comments + 1
                      WHERE book_id = '.$currBookID;
            $completedQuery = mysqli_query($connection, $query);
            
            if (!$completedQuery) {
                include 'error_in_query.php';
            }
        }
    }
}
?>

<form method="POST">
    Коментар: <textarea rows="6" cols="50" name="comment"></textarea><br><br>
    <input type="submit" value="Добави">
</form>

<div><h3><a href="book.php?book_title=<?=$currBook;?>&book_id=<?=$currBookID;?>">Върни се назад</a></h3></div>

<!--Footer-->
<?php
include 'footer.php';
?>