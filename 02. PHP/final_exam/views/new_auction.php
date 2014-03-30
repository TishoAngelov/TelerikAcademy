<!--Header-->
<?php
include '../views/header.php';
?>

<!--Body-->
<?php
// Return to home page if the user is not logged and try to reach this page by URL.
if (!$_SESSION['is_logged']) {
    header('Location: index.php');
    exit;
}

echo '<h1>Публикуване на нова обява</h1>';

if ($_POST) {
    $errors = array();
    $user_id = $_SESSION['user_data']['user_id'];
    
    // Secure the data
    $auction_title = mysqli_real_escape_string($connection, trim($_POST['auction_name']));
    $auction_desc = mysqli_real_escape_string($connection, trim($_POST['auction_desc']));
    $auction_startPrice = (float)mysqli_real_escape_string($connection, trim($_POST['start_price']));
    $datetime = mysqli_real_escape_string($connection, trim($_POST['auction_duration']));
    
    try {         
         $datetime = new DateTime($datetime);
         $new_date = $datetime->format('Y-m-d');
         
         $auction_duration = $new_date;
    }
    catch (Exception $ex){
        $errors[] = '<p>Невалиден формат за дата!</p>';
    }
    
    // Validate the data   
    if (mb_strlen($auction_title) < 4) {
        $errors[] = '<p>Името трябва да бъде поне 4 символа!</p>';
    }
    
    if (mb_strlen($auction_desc) < 10) {
        $errors[] = '<p>Описанието трябва да бъде поне 10 символа!</p>';
    }
    
    if ($auction_startPrice <= 0) {
        $errors[] = '<p>Началната цена трябва да бъде по-голяма от нула лева!</p>';
    }
    
    $today = date("Y-m-d");    
    if ($auction_duration <= $today) {
        $errors[] = '<p>Датата трябва да бъде по-голяма от днешната!</p>';
    }  
    ////////////////////////
    
    // Continue if there are no errors or print the errors
    if ($errors) {
        foreach ($errors as $error) {
            echo $error;            
        }
    }
    else {
        // Add the data in auction
        $query = 'INSERT INTO auctions(user_id, minimum_price, date_end, action_title, auction_desc) 
            VALUES ('.$user_id.', "'.$auction_startPrice.'", "'.$auction_duration.'", "'.$auction_title.'", "'.$auction_desc.'")';
        $completedQuery = mysqli_query($connection, $query);

        if (!$completedQuery) {
          include '../system/error_in_query.php';
        }        
        
        // Add the data in auction_prices
        $auction_id = mysqli_insert_id($connection);       // Gets the last added auction_id
        
        $query = 'INSERT INTO auction_prices(auction_id, user_id, price)
                    VALUES ('.$auction_id.', '.$user_id.', '.$auction_startPrice.')';
        $completedQuery = mysqli_query($connection, $query);

        if (!$completedQuery) {
          include '../system/error_in_query.php';
        }    
        else {
            echo '<h2>Търгът беше добавен успешно!</h2>';          
        }
    }
}
?>

<form method="POST">
    Име на търга (продукта) <input type="text" name="auction_name"><br><br>
    Описание на търга (продукта) <input type="text" name="auction_desc"><br><br>
    Първоначална цена на продукта <input type="text" name="start_price">лв. (примерен формат 1.00) <br><br>
    Продължителност на търга <input type="datetime" name="auction_duration"> (примерен формат 2012-12-06)<br><br><br>
    <input type="submit" value="Добави">
</form><br>

<!--Footer-->
<?php
include '../views/footer.php';
?>