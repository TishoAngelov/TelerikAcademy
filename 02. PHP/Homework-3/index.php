<!--Header-->
<?php
$pageTitle = 'Home page';
include 'header.php';
?>

<!--Body-->
<?php
if (isset($_SESSION['isLogged']) && $_SESSION['isLogged'] == true)
{
    header('Location: messages.php');
    echo '<div><a href="destroy.php">Изход</a></div>';
}
if ($_POST) {
    $user = mysqli_real_escape_string($connection,trim($_POST['userName']));     // Prevent SQL injection. Not 100% safe.
    $pass = mysqli_real_escape_string($connection,trim($_POST['userPass']));     // Prevent SQL injection. Not 100% safe.
    
    $q = mysqli_query($connection, 'SELECT user_name, user_pass FROM users
                    WHERE user_name = "'.$user.'" AND
                        user_pass = "'.$pass.'"');

    if (!$q) {
        echo '<h1>Възникна грешка при обработването на данните! Моля опитайте пак.</h1>';
    
        if ($debug) {
            echo mysqli_error($connection);
        }   
    }
    else {
        if ($q->num_rows > 0) {
            $_SESSION['loggedUser'] = $user;
            $_SESSION['isLogged'] = true;
            
            header('Location: messages.php');    // Open the home page
            exit;
        }
        else {
            echo '<h1>Грешно потребителско име и/или парола!</h1>';
        }
    }
}
?>

<form method="POST">
  Потребителско име: <input type="text" name="userName"><br>
  Парола: <input type="password" name="userPass"><br>
  <input type="submit" value="Вход">
</form>

<a href="registration.php"><h3>Нямаш регистрация?</h3></a>

<!--Footer-->
<?php
include 'footer.php';
?>