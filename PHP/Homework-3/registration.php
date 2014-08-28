<!--Header-->
<?php
$pageTitle = 'Register';
include 'header.php';
?>

<!--Body-->
<?php
echo '<h1>Регистрация на нов потребител</h1>';

if ($_POST) {
    $user = mysqli_real_escape_string($connection,trim($_POST['userName']));     // Prevent SQL injection. Not 100% safe.
    $pass = mysqli_real_escape_string($connection,trim($_POST['userPass']));     // Prevent SQL injection. Not 100% safe.

    $min = 5;
    $max = 50;
    
    // If length of input is correct, insert user and pass in DB.    
    if (
            (mb_strlen($user) < $min || mb_strlen($user) > $max) ||
            (mb_strlen($pass) < $min || mb_strlen($pass) > $max)
        ) {
            echo '<h1>Минималната дължина на името и паролата е 5 символа, а максималната е 50!</h1>';
    }
    else {
        $query = 'INSERT INTO users (user_name, user_pass) 
                    VALUES("'.$user.'","'.$pass.'")';
        
        if(mysqli_query($connection, $query)){
            // Auto open the home page after succesful registration. Required in the task.
            header('Location: index.php');
            exit;
        }
        else {
            echo '<h1>Потребителското име е заето!</h1>';  // Because the field user_name is unique in the DB.    
        }
    }
}

?>

<form method="POST">
  Потребителско име: <input type="text" name="userName"><br>
  Парола: <input type="password" name="userPass"><br>
  <input type="submit" value="Регистрация">
</form>

<a href="index.php"><h3>Върни се назад</h3></a>

<!--Footer-->
<?php
include 'footer.php';
?>