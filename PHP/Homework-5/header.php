<?php
// Settings
mb_internal_encoding('utf8');

session_start();  // start session
$connection = mysqli_connect('localhost', 'pesho', 'pesho', 'homework_5');    // Connect to datebase
$debug = false;      // Set to true to see all error messages with full explanation for them

if (!$connection) {
    echo 'Неуспешна връзка с базата данни!';
    exit;
}

mysqli_set_charset($connection, 'utf8');        // Allows using cyrilic

require 'functions.php';
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
        <?php
        if (UserIsLogged()) {
            echo '<div><h1>Здравей '.$_SESSION['loggedUser'].'!</h1></div>';
        }
        ?>
        
        <a href="index.php"><h3>Начало</h3></a>