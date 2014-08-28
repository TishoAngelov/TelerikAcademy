<?php
require 'header.php';
?>
<a href="index.php">Списък</a>
<form method="post" action="add_book.php">
    Име: <input type="text" name="book_name" />    
    <div>Автори:<select name="authors[]" multiple style="width: 200px">
            <?php
            foreach ($data['authors'] as $author) {
                echo '<option value="' . $author['author_id'] . '">
                    ' . $author['author_name'] . '</option>';
            }
            ?>
        </select></div>
    <input type="submit" value="Добави" />    
</form>
<?php
include 'footer.php';
?>