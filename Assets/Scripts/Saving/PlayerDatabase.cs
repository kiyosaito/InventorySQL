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
        string databaseURL = "http//localhost/nsirpg/customisation";
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
        yield return webRequest.SendWebRequest();
    }
    void Start()
    {
        example = (Example)enumIndex;
    }
    private void Update()
    {
        
    }
}
