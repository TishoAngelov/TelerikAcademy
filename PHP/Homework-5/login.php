<!--Header-->
<?php
$pageTitle = 'Вход';
include 'header.php';
?>

<!--Body-->
<?php
// Return to the home page if a user is already logged in.
if (UserIsLogged())
{
    header('Location: index.php');
    exit;
}

if ($_POST) {
    $user = mysqli_real_escape_string($connection,trim($_POST['userName']));     // Prevent SQL injection. Not 100% safe.
    $pass = mysqli_real_escape_string($connection,trim($_POST['userPass']));     // Prevent SQL injection. Not 100% safe.
        
    $query = 'SELECT user_id, user_name, user_pass FROM users
              WHERE user_name = "'.$user.'" 
              AND user_pass = "'.$pass.'"';
    $completedQuery = mysqli_query($connection, $query);
    
    if (!$completedQuery) {
        include 'error_in_query.php'; 
    }
    else {
        if ($completedQuery->num_rows > 0) {
            $row = $completedQuery->fetch_assoc();
            
            $_SESSION['loggedUser'] = $row['user_name'];
            $_SESSION['loggedUserID'] = $row['user_id'];
            $_SESSION['isLogged'] = true;
            
            // Open the home page after succesuful login
            header('Location: index.php');    
            exit;
        }
        else {
            echo '<h1>Грешно потребителско име и/или парола!</h1>';
        }
    }
}
?>

<form method="POST">
  Потребителско име: <input type="text" name="userName"><br><br>
  Парола: <input type="password" name="userPass"><br><br>
  <input type="submit" value="Вход">
</form>

<a href="registration.php"><h3>Нямаш регистрация?</h3></a>