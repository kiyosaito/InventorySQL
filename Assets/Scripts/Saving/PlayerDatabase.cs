using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDatabase : MonoBehaviour
{
    public int skinIndex, hairIndex, mouthIndex, eyesIndex, clothesIndex, armourIndex, classEnumIndex, strengthStat, constitutionStat, dexterityStat, intelligenceStat, wisdomStat, charismaStat,slotIndex;
    public string charName;

    IEnumerator PlayerStats(Action<string> doneFunction, string playerName, int skin, int hair, int mouth, int eyes, int clothes, int armour, int classIndex, int strength, int constitution, int dexterity, int intelligence, int wisdom, int charisma,int slotIndex)
    {
        string databaseURL = "http://localhost/nsirpg/customisation.php";
        WWWForm form = new WWWForm();
        form.AddField("charName", playerName);
        form.AddField("skinIndex", skin);
        form.AddField("hairIndex", hair);
        form.AddField("mouthIndex", mouth);
        form.AddField("eyesIndex", eyes);
        form.AddField("clothesIndex", clothes);
        form.AddField("armourIndex", armour);
        form.AddField("classEnumIndex", classIndex);
        form.AddField("strengthStat", strength);
        form.AddField("constitutionStat", constitution);
        form.AddField("dexterityStat", dexterity);
        form.AddField("intelligenceStat", intelligence);
        form.AddField("wisdomStat", wisdom);
        form.AddField("charismaStat", charisma);
        form.AddField("slotIndex", slotIndex);
        UnityWebRequest webRequest = UnityWebRequest.Post(databaseURL, form);
        yield return webRequest.SendWebRequest();
        doneFunction(webRequest.downloadHandler.text);
    }

    public void SavingToDataBase(Action<string> doneFunction)
    {
        StartCoroutine(PlayerStats(doneFunction, charName, skinIndex, hairIndex, mouthIndex, eyesIndex, clothesIndex, armourIndex, classEnumIndex, strengthStat, constitutionStat, dexterityStat, intelligenceStat, wisdomStat, charismaStat,slotIndex));
        // This part might run before the webrequest is done
    }
}
public class PlayerDatabaseData
{
    public int skinIndex, hairIndex, mouthIndex, eyesIndex, clothesIndex, armourIndex, classEnumIndex, strengthStat, constitutionStat, dexterityStat, intelligenceStat, wisdomStat, charismaStat, slotIndex;
    public string charName;
}
