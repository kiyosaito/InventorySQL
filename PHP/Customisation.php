<?php
//server login variables
    $server_name = "localhost";
    $server_username = "root";
    $server_password = "";
    $database_name = "nsirpg";
//Variables
	$slot = $_POST["slotIndex"];
    $skin = $_POST["skinIndex"];
    $hair = $_POST["hairIndex"];
    $mouth = $_POST["mouthIndex"];
    $eyes = $_POST["eyesIndex"];
    $clothes = $_POST["clothesIndex"];
    $armour = $_POST["armourIndex"];
    $class = $_POST["classEnumIndex"];
    $name = $_POST["charName"];
	$strength = $_POST["strengthStat"];
	$constitution = $_POST["constitutionStat"];
	$dexterity = $_POST["dexterityStat"];
	$intelligence = $_POST["intelligenceStat"];
	$wisdom = $_POST["wisdomStat"];
	$charisma = $_POST["charismaStat"];
    //check connection
$conn = new mysqli($server_name,$server_username,$server_password,$database_name);
if(!$conn){
    die("Connection Failed.".mysqli_connect_error());
}
	$charactersDelQuery = "DELETE FROM characters WHERE slot = '".$slot."';";
	mysqli_query($conn, $charactersDelQuery) or die("Error, deletion failed");
$characterInfo = "INSERT INTO characters (skin,hair,mouth,eyes,clothes,armour,class,name,strength,constitution,dexterity,intelligence,wisdom,charisma,slot) 
VALUES ('".$skin."','".$hair."','".$mouth."','".$eyes."','".$clothes."','".$armour."','".$class."','".$name."','".$strength."','".$constitution."','".$dexterity."','".$intelligence."','".$wisdom."','".$charisma."','".$slot."');";
$updateResult = mysqli_query($conn, $characterInfo)or die("error insert failed");
if ($updateResult) {
    echo "Success";
}
?>