<!--Header-->
<?php
$pageTitle = 'Съобщения';
include 'header.php';
?>

<!--Body-->
<?php
// Check if logged
if (!(isset($_SESSION['isLogged'])) && $_SESSION['isLogged'] != 1) {
    header('Location: index.php');    // Open the home page
    exit;
}

echo '<h1>Публикувани съобщения по дата</h1>';
 
$query = 'SELECT title, message, user_posted, date_posted FROM messages ORDER BY date_posted DESC';
$completedQuery = mysqli_query($connection, $query);

if (!$completedQuery) {
    echo 'error';
    echo mysqli_error($connection);    
}
 else {
    if ($completedQuery->num_rows > 0) {
        echo '<table border="2">
                <tr>
                    <td><b>Заглавие</b></td>
                    <td><b>Съобщение</b></td>
                    <td><b>Публикувал</b></td>
                    <td><b>Публикувано на</b></td>
                </tr>';
        
        while ($row = $completedQuery->fetch_assoc()){
            echo '<tr>
                    <td>'.$row['title'].'</td>
                    <td>'.$row['message'].'</td>
                    <td>'.$row['user_posted'].'</td>
                    <td>'.$row['date_posted'].'</td>
                  </tr>';
        }

        echo '</table>';
    }
    else {
        echo '<h1>Няма съобщения</h1>';
    }    
}
?>

<a href="new_message.php"><h3>Добави ново съобщение</h3></a>

<!--Footer-->
<?php
include 'footer.php';
?>