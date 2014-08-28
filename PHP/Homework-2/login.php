<!--Check user and pass-->
<?php
require 'users.php';

$loginError = true;

if ($_POST) {
    for ($index = (int)0; $index < count($users); $index++) {
        if (($users[$index] == $_POST['userName']) && ($passwords[$index] == $_POST['userPass'])) {            
            $_SESSION['loggedUser'] = $users[$index];
            
            $loginError = false;
           
            break;           
        }
    }

    if ($loginError) {
      echo '<h1>Грешно потребителско име и/или парола!</h1>';
    }
    else {
          header('Location: home.php?user='.$loggedUser);    // Open the home page
        exit;
    }    
}
?>

<form method="post">
  Потребителско име: <input type="text" name="userName"><br>
  Парола: <input type="password" name="userPass"><br>
  <input type="submit" value="Вход">
</form>