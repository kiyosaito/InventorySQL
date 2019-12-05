using UnityEngine;
public class PlayerSaveAndLoad : MonoBehaviour
{
    public PlayerHandler player;
    public bool custom;
    public static PlayerDatabaseData database;
    private void Start()
    {
      if(!custom)
        {
            Debug.Log("Load Binary shiz");
            Load();
        }
    }    
    public void Save()
    {
        PlayerBinary.SavePlayerData(player);
    }
    public void Load()
    {
        //PlayerData data = PlayerBinary.LoadData(player);
        player.name = database.charName;
       /* player.curCheckPoint = GameObject.Find(data.checkPoint).GetComponent<Transform>();
        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxStamina = data.maxStamina;

        player.curHealth = data.curHealth;
        player.curMana = data.curMana;
        player.curStamina = data.curStamina;

        if (!(data.pX == 0 && data.pY == 0 && data.pZ == 0))
        {
            player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
            player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
        }
        else
        {
            player.transform.position = player.curCheckPoint.position;
            player.transform.rotation = player.curCheckPoint.rotation;
        }*/
        player.skinIndex = database.skinIndex;
        player.hairIndex = database.hairIndex;
        player.mouthIndex = database.mouthIndex;
        player.eyesIndex = database.eyesIndex;
        player.clothesIndex = database.clothesIndex;
        player.armourIndex = database.armourIndex;

        player.characterClass = (CharacterClass)database.classEnumIndex;
        player.characterName = database.charName;

     
        player.stats[0].value = database.strengthStat;
        player.stats[1].value = database.dexterityStat;
        player.stats[2].value = database.constitutionStat;
        player.stats[3].value = database.wisdomStat;
        player.stats[4].value = database.intelligenceStat;
        player.stats[5].value = database.charismaStat;
        LoadCustomisation.SetTexture("Skin", database.skinIndex);
        LoadCustomisation.SetTexture("Hair", database.hairIndex);
        LoadCustomisation.SetTexture("Mouth", database.mouthIndex);
        LoadCustomisation.SetTexture("Eyes", database.eyesIndex);
        LoadCustomisation.SetTexture("Clothes", database.clothesIndex);
        LoadCustomisation.SetTexture("Armour", database.armourIndex);
    }
}
