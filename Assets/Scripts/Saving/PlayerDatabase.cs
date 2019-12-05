using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDatabase : MonoBehaviour
{
    public int skinIndex, hairIndex, mouthIndex, eyesIndex, clothesIndex, armourIndex,classEnumIndex;
    public string charName;

    IEnumerator PlayerStats(string playerName, int skin, int hair, int mouth, int eyes, int clothes, int armour,int classIndex)
    {
        Debug.Log("work");
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
        UnityWebRequest webRequest = UnityWebRequest.Post(databaseURL, form);
        Debug.Log("working");
        yield return webRequest.SendWebRequest();
        Debug.Log("workingx2");
        Debug.Log(webRequest.downloadHandler.text);
        yield return null;
    }
    
    public void SavingToDataBase()
    {
        StartCoroutine(PlayerStats(charName, skinIndex, hairIndex, mouthIndex, eyesIndex, clothesIndex, armourIndex, classEnumIndex));
    }
}
