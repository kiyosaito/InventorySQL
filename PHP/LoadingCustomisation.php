<?php
//server login variables
    $server_name = "localhost";
    $server_username = "root";
    $server_password = "";
    $database_name = "nsirpg";
//Variables
	$slot = $_POST["slotIndex"];
    //check connection
$conn = new mysqli($server_name,$server_username,$server_password,$database_name);
if(!$conn){
    die("Connection Failed.".mysqli_connect_error());
}
$charResults = "";
	$characterInfo = "SELECT skin,hair,mouth,eyes,clothes,armour,class,name,strength,constitution,dexterity,intelligence,wisdom,charisma FROM characters WHERE slot = '".$slot."';";
	$charactersGet = mysqli_query($conn, $characterInfo);
	$row = mysqli_fetch_assoc($charactersGet);
	
	
	$charResults .= $row['skin']."|";
	$charResults .= $row['hair']."|";
	$charResults .= $row['mouth']."|";
	$charResults .= $row['eyes']."|";
	$charResults .= $row['clothes']."|";
	$charResults .= $row['armour']."|";
	$charResults .= $row['class']."|";
	$charResults .= $row['name']."|";
	$charResults .= $row['strength']."|";
	$charResults .= $row['constitution']."|";
	$charResults .= $row['dexterity']."|";
	$charResults .= $row['intelligence']."|";
	$charResults .= $row['wisdom']."|";
	$charResults .= $row['charisma'];
	
	echo $charResults;
?>