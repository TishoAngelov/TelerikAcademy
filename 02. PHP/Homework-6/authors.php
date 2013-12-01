<?php
require './inc/functions.php';

if ($_POST) {
    $author_name = trim($_POST['author_name']);
    
    if (mb_strlen($author_name) < 2) {
        echo '<p>Невалидно име</p>';
    } else {
        $author_esc = mysqli_real_escape_string($db, $author_name);
        $q = mysqli_query($db, 'SELECT * FROM authors WHERE
        author_name="' . $author_esc . '"');
        
        if (mysqli_error($db)) {
            echo 'Грешка';
        }
        else{
            if (mysqli_num_rows($q) > 0) {
                echo 'Има такъв автор';
            } else {
                mysqli_query($db, 'INSERT INTO authors (author_name)
                VALUES("' . $author_esc . '")');

                if (mysqli_error($db)) {
                    echo 'Грешка';
                } else {
                    echo 'Успешен запис';
                }
            }
        }
    }
}

$data['authors'] = getAuthors($db);

if ($data['authors'] === false) {
    echo 'Грешка';
}
else {
    $data['title'] = 'Автори';
    
    visualize($data, './templates/authors_view.php');
}