<?php
include '../views/header.php';
if (isset($_SESSION) && $_SESSION['is_logged']) {
    echo '<div><h1>Здравей ' . $_SESSION['user_data']['email'] . '</h1><br> <a href="?p=new_auction">Нова обява</a> <a href="?p=logout">Изход</a></div>';
} else {
    echo '<div><a href="?p=login">Вход</a> <a href="?p=register">Регистрация</a> </div>';
}
?>

<!--Body-->
<?php
$today = date("Y-m-d");
echo '<br><h3>Днешна дата: '.$today.'</h3><br>';

$query = 'SELECT auctions.auction_id, auctions.action_title, auctions.auction_desc, auctions.date_end, auctions.date_created,
            auction_prices.price, users.email
            FROM auctions
            JOIN auction_prices
            ON auction_prices.auction_id = auctions.auction_id
            JOIN users
            ON users.user_id = auctions.user_id
            WHERE date_end > "'.$today.'"';
$completedQuery = mysqli_query($connection, $query);

if (!$completedQuery) {
    include '../system/error_in_query.php';
}
else {    
    // If there are no results, print info message.
    if ($completedQuery->num_rows <= 0) {
        echo '<h2>Няма публикувани/активни търгове за момента! Моля да ни извините :).</h2>';
    }
    else {
        // Print table title cells
        echo '<form method="GET">
            <table border = 2>
                <tr><td>Име</td><td>Описание</td><td>Дата на изтичане</td><td>Последно наддаване</td><td>Публикувал</td><td>Добавен на</td></tr>';
       
        while ($row = $completedQuery->fetch_assoc()){
            echo '<tr>';
                
            // Ako e lognat potrebitel da moje da cykne na linka na dadeniq tyrg i da naddava.
            if (isset($_SESSION) && $_SESSION['is_logged']) {   
                echo '<td><a href="?p=new_offer&auction_id='.$row['auction_id'].'&auction_title='.$row['action_title'].'">'.$row['action_title'].'</a></td>';   
            }
            else {
                echo '<td>'.$row['action_title'].'</td>';
            }      
            
            echo '<td>'.$row['auction_desc'].'</td>
                  <td>'.$row['date_end'].'</td>
                  <td>'.$row['price'].' лв.</td>
                  <td>'.$row['email'].'</td>
                  <td>'.$row['date_created'].'</td>
                </tr>';
        }   
        
        echo '</table>
            </form>';
    }
}
?>

<!--Footer-->
<?php
include '../views/footer.php';


