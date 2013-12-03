<?php
mb_internal_encoding('UTF-8');

$db = mysqli_connect('localhost', 'pesho', 'pesho', 'books');
if (!$db) {
    echo 'No database';
}
mysqli_set_charset($db, 'utf8');