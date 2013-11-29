<!--Header-->
<?php
$pageTitle = 'Регистрация';
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

echo '<h1>Регистрация на нов потребител</h1>';

if ($_POST) {
    $user = mysqli_real_escape_string($connection,trim($_POST['userName']));     // Prevent SQL injection. Not 100% safe.
    $pass = mysqli_real_escape_string($connection,trim($_POST['userPass']));     // Prevent SQL injection. Not 100% safe.

    $min = 3;
    $max = 50;
    
    // If length of input is correct, insert user and pass in DB.    
    if (
            (mb_strlen($user) < $min || mb_strlen($user) > $max) ||
            (mb_strlen($pass) < $min || mb_strlen($pass) > $max)
        ) {
            echo '<h1>Минималната дължина на името и паролата е '.$min.' символа, а максималната е '.$max.'!</h1>';
    }
    else {
        // Check if user exists
        $query = 'SELECT user_name FROM users
                    WHERE user_name = "'.$user.'"';
        $completedQuery = mysqli_query($connection, $query);
        
        if($completedQuery->num_rows >= 1){
            echo '<h1>Потребителското име е заето!</h1>';
        }
        else {
            // Insert the user
            $query = 'INSERT INTO users (user_name, user_pass) 
                        VALUES("'.$user.'","'.$pass.'")';
            $completedQuery = mysqli_query($connection, $query);

            if($completedQuery){
                $user_id = mysqli_insert_id($connection);       // Gets last added user_id
                
                // Auto login and open the home page after succesful registration.               
                $_SESSION['loggedUser'] = $user;
                $_SESSION['loggedUserID'] = $user_id;
                $_SESSION['isLogged'] = true;
                
                header('Location: index.php');
                exit;
            }
            else {
                include 'error_in_query.php';
            }
        }       
    }
}
?>

<form method="POST">
  Потребителско име: <input type="text" name="userName"><br><br>
  Парола: <input type="password" name="userPass"><br><br>
  <input type="submit" value="Регистрация">
</form>

<!--Footer-->
<?php
include 'footer.php';
?>