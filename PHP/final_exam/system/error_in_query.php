<?php
echo '<h1>Възникна грешка! Моля опитайте отново по-късно.</h1>';

// Print stack trace of error message if debug mode is on.
if ($debug) {
    echo mysqli_error($connection);     
    
    exit;
}
?>
