<?php
mb_internal_encoding('utf8');

session_start();  // start session
$connection = mysqli_connect('localhost', 'pesho', 'pesho', 'homework_3');    // Connect to datebase

if (!$connection) {
    echo 'Грешка при свързването с базата данни! Моля опитайте по-късно.';
    exit;
}

mysqli_set_charset($connection, 'utf8');        // Allows using cyrilic
?>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title><?=$pageTitle;?></title>
        
           <style>
                table {border-collapse:collapse; table-layout:fixed; width:900px;}
                table td {border:solid 2px #5c3; width:300px; word-wrap:break-word;}
           </style>
    </head>
    <body>