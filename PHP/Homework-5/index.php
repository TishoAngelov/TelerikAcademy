<!--Header-->
<?php
$pageTitle = 'Списък с книги';
include 'header.php';
?>

<!--Body-->
<?php
echo '<h1>Списък с всички книги</h1>';

$query = 'SELECT books.book_id, books.book_title, books.count_comments, authors.author_name
            FROM books_authors
            INNER JOIN books ON books_authors.book_id = books.book_id
            INNER JOIN authors ON books_authors.author_id = authors.author_id';
$completedQuery = mysqli_query($connection, $query);

if (!$completedQuery) {
    include 'error_in_query.php';
}
else {
    // Print table title cells
    echo '<form method="GET">
            <table border = 2>
                <tr><td>Книга</td><td>Автори</td><td>Коментари</td></tr>';
            
    // If there are no results, print info message. Else get all books and show them in table.
    if ($completedQuery->num_rows <= 0) {
        echo '<h1>Няма въведени книги!</h1>';
    }
    else {
        $result = array();
        
        while ($row = $completedQuery->fetch_assoc()){           
            $result[$row['book_id']]['book_title'] = $row['book_title'];
            $result[$row['book_id']]['count_comments'] = $row['count_comments'];
            $result[$row['book_id']]['authors'][] = $row['author_name'];            
        }
        
        // Print each book title in separate cell.       
        foreach ($result as $key => $book) {
            echo '<tr><td><a href="book.php?book_title='.$book['book_title'].'&book_id='.$key.'">'.$book['book_title'].'</a></td>
                      <td>';
            
            // Show all authors of the current book in single cell. 
            foreach ($book['authors'] as $author) {
                echo '<a href="books_from_author.php?author_name='.$author.'">'.$author.'</a> ';
            }

            echo '</td><td>'.$book['count_comments'].'</td></tr>';
        }
    }
    
    // Links for adding new book and author
    echo '<tr>
            <td><a href="new_book.php">Добави нова книга</a></td>
            <td><a href="new_author.php">Добави нов автор</a></td>
          </tr>
        </table>
    </form><br>';
}
?>

<!--Footer-->
<?php
include 'footer.php';
?>