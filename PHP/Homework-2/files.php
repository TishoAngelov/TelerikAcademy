<!--Header-->
<?php
$pageTitle = 'Списък с файлове';
require 'header.php';
?>

<!--Body-->
<a href="home.php"><h3>Върни се към менюто</h3></a>

<?php
$allFiles = scandir($_SESSION['loggedUser'], 1);          // "1" is used to set the ".." and "." at the end of the array.
?>

<h1>Списък с файлове на потребител "<?=$_SESSION['loggedUser'];?>"</h1>

<table border="2">
    <tr>
        <td>Файл</td>
        <td>Размер</td>
    </tr>
    
    <?php
    for ($i = 0; $i < count($allFiles) - 2; $i++) {             // count($allFiles) - 2 because of ".." and "." at the end.  
        $currFileSizeInBytes = filesize($_SESSION['loggedUser'].DIRECTORY_SEPARATOR.$allFiles[$i]);  // Doesn't work for files bigger than 2 GB.
        $currFileSizeInKB = round($currFileSizeInBytes / 1024, 2);
                
        echo '<tr>
                <td><a href="'.$_SESSION['loggedUser'].DIRECTORY_SEPARATOR.$allFiles[$i].'" download="'.$allFiles[$i].'">'.$allFiles[$i].'</a></td>
                <td>'.$currFileSizeInBytes.' Bytes/ '.$currFileSizeInKB.' KB</td>
              </tr>';
    }
    ?>    
</table>

<!--Footer-->
<?php
include 'footer.php';
?>