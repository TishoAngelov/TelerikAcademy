<?php
echo '<h1>Възникна грешка! Моля опитайте отново по-късно.</h1>';
        
if ($debug) {
    echo mysqli_error($connection);     // Print stack trace of error message if we are in debug mode.
}
?>
