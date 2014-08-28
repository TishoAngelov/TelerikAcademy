<?php
if (UserIsLogged()) {
    echo '<br><a href="destroy_session.php">Изход</a>';
}
else {
    echo '<br><a href="login.php">Вход</a>';
}
?>
    </body>
</html>