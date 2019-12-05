<?php
//server login variables
    $server_name = "localhost";
    $server_username = "root";
    $server_password = "";
    $database_name = "nsirpg";
//Variables
	
    //check connection
$conn = new mysqli($server_name,$server_username,$server_password,$database_name);
if(!$conn){
    die("Connection Failed.".mysqli_connect_error());
}
$charResults = "";
	$charactersGetQuery = "SELECT Slot FROM characters";
	$charactersGet = mysqli_query($conn, $charactersGetQuery);
	while($row = mysqli_fetch_assoc($charactersGet))
	{
	   $charResults .= $row['Slot']."|";
	}
	echo $charResults;
?>