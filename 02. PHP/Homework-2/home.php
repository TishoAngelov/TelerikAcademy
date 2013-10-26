<!--Header-->
<?php
$pageTitle = 'Home';
require 'header.php';
?>

<!--Body-->
<h1>Здравей <?=$_SESSION['loggedUser'];?>!</h1><br>

<h1>MENU</h1>
<a href="upload.php"><h3>Качи файл</h3></a>
<a href="files.php"><h3>Списък с файлове</h3></a>

<!--Footer-->
<?php
include 'footer.php';
?>