<!--Header-->
<?php
$pageTitle = 'Добавяне на нова книга';
include 'header.php';
?>

<!--Body-->
<?php
// If something is submitted
if ($_GET) {
    $error = false;
    $minBookLen = 3;
    
    // Get the input
    $book = mysqli_real_escape_string($connection,trim($_GET['book']));     // Prevent SQL injection. Not 100% safe.
        
    if (mb_strlen($book) < $minBookLen) {             // Check if book len is correct.
        echo '<h1>Моля въведете поне '.$minBookLen.' символа!</h1>';
        $error = true;
    }
    else {
        // Check if book exists
        $query = 'SELECT book_title FROM books WHERE book_title = "'.$book.'"';
        $completedQuery = mysqli_query($connection, $query);        // Execute the query.
        
        if (!$completedQuery) {
            include 'error_in_query';
            $error = true;
        }
        else {
            // If book exists, display error. Else insert the book in DB.
            if ($completedQuery->num_rows > 0) {
                echo '<h1>Книгата вече съществува!</h1>';
                $error = true;
            }
            else {
                $query = 'INSERT INTO books(book_title) VALUES("'.$book.'")';      // Query for inserting a book in DB.
                $completedQuery = mysqli_query($connection, $query);               // Execute the query.
                
                if (!$completedQuery) {          // Check if there is error.
                    include 'error_in_query.php';            
                    $error = true;
                }
                else {
                    echo '<h1>Книгата е добавена успешно!</h1>';                    
                }
            }        
        }        
    }
    
    // If no error occured, proceed with inserting the authors_id in DB
    if (!$error) {
        $book_id = mysqli_insert_id($connection);       // Gets last added book_id
        
        // Insert each selected author_id (and current book_id) in books_authors table.
        foreach ($_GET['authors'] as $selectedOption) {            
            $query = 'INSERT INTO books_authors(book_id, author_id) VALUES('.$book_id.', '.$selectedOption.')';     // Query for inserting the current author_id and last book_id in books_authors
            $completedQuery = mysqli_query($connection, $query);        // Execute the query
            
            if (!$completedQuery) {              // Check for error
                include 'error_in_query.php';
                $error = true;
            }
        }
    }    
}

echo '<h1>Добавяне на нова книга</h1>';
echo '<h3>Задръж Ctrl, за да избереш няколко автора.</h3>';

$query = 'SELECT author_id, author_name FROM authors ORDER BY author_name';
$completedQuery = mysqli_query($connection, $query);

echo '<form method="GET">
        Книга: <input type="text" name="book"><br><br>
        Избери автор/и: <br><select name="authors[]" multiple required>';

while ($row = $completedQuery->fetch_assoc()) {
    echo '<option value='.$row['author_id'].'>'.$row['author_name'].'</option>';
}

echo '</select>
        <br><br><input type="submit" value="Добави"">
      </form>';
?>

<a href="index.php"><h3>Книги</h3></a>

<!--Footer-->
<?php
include 'footer.php';
?>