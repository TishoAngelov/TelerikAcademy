<!DOCTYPE html>
<?php
$connection = mysqli_connect('localhost', 'telerik', 'qwerty', 'auction', 3306);
$debug = true;

if (!$connection) {
    echo 'Неуспешна връзка с базата данни!';
    exit;
}

mysqli_set_charset($connection, 'utf8');        // Allows using cyrilic
?>

<html>
    <head>
        <meta charset="UTF-8">
        <title><?=$page_title;?></title>
    </head>
    <body>
    