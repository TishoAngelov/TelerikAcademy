<!--Header-->
<?php
$pageTitle = 'Добавяне на автор';
include 'header.php';
?>

<!--Body-->
<?php
// If something is submitted
if ($_POST) {
    $minAuthorLength = 3;        
    
    // Get the input
    $author = mysqli_real_escape_string($connection,trim($_POST['author']));     // Prevent SQL injection. Not 100% safe.
        
    if (mb_strlen($author) < $minAuthorLength) {
        echo '<h1>Моля въведете поне '.$minAuthorLength.' символа!</h1>';        
    }
    else {
        // Check if author exists
        $query = 'SELECT author_name FROM authors WHERE author_name = "'.$author.'"';
        $completedQuery = mysqli_query($connection, $query);
        
        // If author exists, display error. Else insert him in DB.
        if ($completedQuery->num_rows > 0) {
            echo '<h1>Авторът вече съществува!</h1>';
        }
        else{
            // Insert the author in DB.
            $query = 'INSERT INTO authors(author_name) VALUES("'.$author.'")';
            $completedQuery = mysqli_query($connection, $query);    // Execute the query
            
            if (!$completedQuery) {
                include 'error_in_query.php';
            }
            else {                
                echo '<h1>Авторът е добавен успешно!</h1>';
            }
        }    
    }
}
?>

<h1>Добавяне на нов автор</h1>

<form method="POST">
    Автор: <input type="text" name="author">
    <input type="submit" value="Добави">
</form><br>

<?php
$query = 'SELECT author_name FROM authors ORDER BY author_name';
$completedQuery = mysqli_query($connection, $query);            // Execute the query

if ($completedQuery->num_rows <= 0) {           // Print info message if there are no authors inserted
    echo '<h1>Няма въведени автори!</h1>';
}
else {
    // List with all authors
    echo '<form method="GET">
            <table border = 2>
                <tr><td>Автори</td></tr>';

    while ($row = $completedQuery->fetch_assoc()) {
        echo '<tr><td><a href="books_from_author.php?author_name='.$row['author_name'].'">'.$row['author_name'].'</a></td></tr>';
    }

echo '</table>
    </form>';
}

echo '<a href="index.php"><h3>Книги</h3></a>';

// Footer
include 'footer.php';
?>