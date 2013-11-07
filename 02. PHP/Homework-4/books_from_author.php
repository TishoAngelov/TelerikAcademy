<!--Header-->
<?php
$currAuthorName = $_GET['author_name'];
$pageTitle = 'Книги от '.$currAuthorName;
include 'header.php';
?>

<!--Body-->
<?php
// Return to page with all books if the author name is empty
if ($currAuthorName == "" || $currAuthorName == null) {
    header('Location: index.php');
    exit;
}

echo '<h1>Книги от '.$currAuthorName.'</h1>';

// Check if the authors exists
$query = 'SELECT author_id FROM authors
            WHERE author_name = "'.$currAuthorName.'"';
$completedQuery = mysqli_query($connection, $query);

if ($completedQuery->num_rows <= 0) {
    echo '<h1>Несъществуващ автор!</h1>';
}
else {
    $query = 'SELECT books.book_id, books.book_title, authors.author_name 
            FROM books INNER JOIN books_authors
            ON books.book_id = books_authors.book_id
            INNER JOIN authors
            ON books_authors.author_id = authors.author_id
            WHERE books_authors.book_id IN (
                       SELECT books_authors.book_id
                       FROM books_authors INNER JOIN authors
                       ON books_authors.author_id = authors.author_id
                       WHERE authors.author_name = "' . $currAuthorName . '")';
    $completedQuery = mysqli_query($connection, $query);

    if (!$completedQuery) {
        include 'error_in_query.php';
    }
    else {
        if ($completedQuery->num_rows <= 0) {
            echo '<h1>Този автор все още няма книги!</h1>';
        }
        else {       
            echo '<form method = "GET">
                    <table border="2">
                        <tr><td><b>Книги</b></td><td>Автори</td></tr>';

            $result = array();

            while ($row = $completedQuery->fetch_assoc()){
                $result[$row['book_id']]['book'] = $row['book_title'];
                $result[$row['book_id']]['authors'][] = $row['author_name'];            
            }

            //echo '<pre>'.print_r($result, true).'</pre>';

            foreach ($result as $currBook) {
                echo '<tr><td>'.$currBook['book'].'</td><td>';

                foreach ($currBook['authors'] as $currAuthor) {
                    echo '<a href="books_from_author.php?author_name='.$currAuthor.'">'.$currAuthor.'</a> ';
                }

                echo '</td></tr>';
            }

            echo '</table>
                </form>';
        }    
    }
}
?>

<a href="index.php">Книги</a>

<!--Footer-->
<?php
include 'footer.php';
?>