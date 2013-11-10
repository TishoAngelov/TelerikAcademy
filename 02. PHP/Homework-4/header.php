<?php
mb_internal_encoding('utf8');

$connection = mysqli_connect('localhost', 'pesho', 'pesho', 'books');    // Connect to datebase
$debug = true;      // Set to true to see all error messages with full explanation for them

if (!$connection) {
    echo 'Неуспешна връзка с базата данни!';
    exit;
}

mysqli_set_charset($connection, 'utf8');        // Allows using cyrilic
?>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title><?=$pageTitle;?></title>
        
<!--           <style>
                table {border-collapse:collapse; table-layout:fixed; width:900px;}
                table td {border:solid 2px #5c3; width:300px; word-wrap:break-word;}
           </style>-->
    </head>
    <body>