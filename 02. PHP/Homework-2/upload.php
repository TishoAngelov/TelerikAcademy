<!--Header-->
<?php
$pageTitle = 'Качване на файл';
require 'header.php';
require 'users.php';
?>

<!--Body-->
<?php
if ($_POST) {
    // Check if dir exists. If not -> create it
    if (!file_exists($_SESSION['loggedUser'])) {
       mkdir($_SESSION['loggedUser']);
    }

    // Check if file is uploaded and try to move it
    if (count($_FILES) > 0) {
        if (move_uploaded_file($_FILES['fileUpload']['tmp_name'], 
                $_SESSION['loggedUser'].DIRECTORY_SEPARATOR.$_FILES['fileUpload']['name'])) {
            echo 'Файлът беше качен успешно!<br>';
        }
        else {
            echo 'Грешка при качване на файла!!<br>'; 
        }
    }
}
?>

<a href="home.php"><h3>Върни се към менюто</h3></a>

<form method="POST" enctype="multipart/form-data">
    <div>Избери файл:<input type="file" name="fileUpload" /></div> 
    <div><input type="submit" value="Качи" name="submit"/></div> 
</form>

<!--Footer-->
<?php
include 'footer.php';
?>