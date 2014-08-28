<?php
if (isset($_SESSION['isLogged']) && $_SESSION['isLogged']) {
    echo '<a href="destroy_session.php"><h3>Изход</h3></a>';
}
?>

    </body>
</html>