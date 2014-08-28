<!--Header-->
<?php
include 'header.php';
?>

<!--Body-->
<?php
// Check if a user is logged. If not, redirect him to the main page.
if (!isset($_SESSION)) {
    header('Location: index.php');
    exit;    
}

echo '<h1>Наддаване за '.$_GET['auction_title'].'</h1><br>';

$query = 'SELECT auctions.auction_desc, auctions.minimum_price, auctions.date_created,
            auction_prices.price, users.email
            FROM auctions
            JOIN auction_prices
            ON auction_prices.auction_id = auctions.auction_id
            JOIN users
            ON users.user_id = auctions.user_id
            WHERE auctions.auction_id = "'.mysqli_real_escape_string($connection, trim($_GET['auction_id'])).'"';

$completedQuery = mysqli_query($connection, $query);

if (!$completedQuery) {
    include '../system/error_in_query.php';
}
else {
    // Print table title cells
    echo '<table border = 2>
            <tr><td>Описание</td><td>Първоначална цена</td><td>Последно наддаване</td><td>Публикувал</td><td>Добавен на</td></tr>';
    $currPrice = '';
    
    while ($row = $completedQuery->fetch_assoc()){
        echo '<tr><td>'.$row['auction_desc'].'</td>
              <td>'.$row['minimum_price'].' лв.</td>
              <td>'.$row['price'].' лв.</td>
              <td>'.$row['email'].'</td>
              <td>'.$row['date_created'].'</td>
            </tr>';
        
        $currPrice = (float)$row['price'];
    }   

    echo '</table>';
}

if ($_POST) {
    $errors = array();
    
    $newPrice = (float)mysqli_real_escape_string($connection, trim($_POST['new_offer_price']));
    
    if ($newPrice <= $currPrice) {
        $errors[] = '<p>Новата оферта трябва да бъде по-голяма от текущата оферта!</p>';
    }
    
    if ($errors) {
        foreach ($errors as $error) {
            echo $error;            
        }
    }
    else {       
        $query = 'UPDATE auction_prices
                      SET price = "'.$newPrice.'"
                      WHERE auction_id = '.$_GET['auction_id'];

        $completedQuery = mysqli_query($connection, $query);

        if (!$completedQuery) {
          include '../system/error_in_query.php';
        }    
        else {
            echo '<h2>Новата оферта беше добавена!</h2>';          
        }
    }
}
?>
<form method="POST"><br><br>
    Твоята оферта <input type="text" name="new_offer_price">лв. (примерен формат 1.00) <br><br>
    <input type="submit" value="Добави">
</form><br>

<!--Footer-->
<?php
include '../views/footer.php';