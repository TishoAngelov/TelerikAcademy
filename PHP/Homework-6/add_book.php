<?php
require './inc/functions.php';
    
if ($_POST) {
    $book_name = trim($_POST['book_name']);
    
    if (!isset($_POST['authors'])) {
        $_POST['authors'] = '';
    }
    
    $addBook['authors'] = $_POST['authors'];
    $er = [];
    
    if (mb_strlen($book_name) < 2) {
        $er[] = '<p>Невалидно име</p>';
    }
    
    if (!is_array($addBook['authors']) || count($addBook['authors']) == 0) {
        $er[] = '<p>Грешка</p>';
    }
    
    if (!isAuthorIdExists($db, $addBook['authors'])) {
        $er[] = 'невалиден автор';
    }

    if (count($er) > 0) {
        foreach ($er as $v) {
            echo '<p>' . $v . '</p>';
        }
    } else {
        mysqli_query($db, 'INSERT INTO books (book_title) VALUES("' .
                mysqli_real_escape_string($db, $book_name) . '")');
        
        if (mysqli_error($db)) {
            echo 'Error';
            
            exit;
        }
        
        $id = mysqli_insert_id($db);
        
        foreach ($addBook['authors'] as $author) {
            mysqli_query($db, 'INSERT INTO books_authors (book_id,author_id)
                VALUES (' . $id . ',' . $author . ')');
            
            if (mysqli_error($db)) {
                echo 'Error';
                echo mysqli_error($db);
                
                exit;
            }
        }
        
        echo 'Книгата е добавена';        
    }
}

$addBook = [];
$addBook['authors'] = getAuthors($db);
if ($addBook['authors'] === false) {
    echo 'Грешка';
}

$addBook['title'] = 'Нова книга';
visualize($addBook, './templates/add_book_view.php');