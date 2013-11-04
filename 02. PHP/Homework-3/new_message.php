<!--Header-->
<?php
$pageTitle = 'Писане на ново съобщение';
include 'header.php';
?>

<!--Body-->
<?php
// Check if logged
if (!(isset($_SESSION['isLogged'])) && $_SESSION['isLogged'] != 1) {
    header('Location: index.php');    // Open the home page
    exit;
}

echo '<h1>Писане на ново съобщение</h1>';

if ($_POST) {
    $title = mysqli_real_escape_string($connection,trim($_POST['messageTitle']));     // Prevent SQL injection. Not 100% safe.
    $message = mysqli_real_escape_string($connection,trim($_POST['messageText']));     // Prevent SQL injection. Not 100% safe.
    $messageGroup = mysqli_real_escape_string($connection,trim($_POST['messageGroup']));     // Prevent SQL injection. Not 100% safe.
    $userPosted = $_SESSION['loggedUser'];
    
    $min = 1;
    $titleMax = 50;
    $messageMax = 250;
    
    // If length of input is correct, insert in DB.    
    if (
            (mb_strlen($title) < $min || mb_strlen($title) > $titleMax) ||
            (mb_strlen($message) < $min || mb_strlen($message) > $messageMax)
        ) {
            echo '<h1>Минималната дължина на заглавието и съобщението е 1 символ!<br>
                    Максималната дължина на заглавието е 50 символа, а на съобщението 250!</h1>';
    }
    else {
        $query = 'INSERT INTO messages (title, message, message_group, user_posted) 
                    VALUES("'.$title.'","'.$message.'","'.$messageGroup.'","'.$userPosted.'")';
        
        if(mysqli_query($connection, $query)){
            // Auto open the messages.php page after succesful post. Required in the task.
            header('Location: messages.php');
            exit;
        }
        else {
            echo '<h1>Възникна грешка!</h1>';  // Because the field user_name is unique in the DB.
            echo mysqli_error($connection);
        }
    }
}
?>

<form method="POST">
  Заглавие: <input type="text" size="50" name="messageTitle"><br><br>
  Съобщение: <textarea rows="6" cols="50" name="messageText"></textarea><br><br>
  Група: <input type="text" size="30" name="messageGroup"><br><br>
  <input type="submit" value="Публикувай">
</form>

<!--Footer-->
<?php
include 'footer.php';
?>