using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject[] loadSlots;
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void Slot(int slotNum)
    {
        PlayerData.saveSlot = slotNum;
    }
    public void LoadSlots()
    {
        StartCoroutine(PlayerSelect(SlotsLoaded));
    }
    IEnumerator PlayerSelect(Action<string> doneFunction)
    {
        string databaseURL = "http://localhost/nsirpg/characterselect.php";
        WWWForm form = new WWWForm();
        UnityWebRequest webRequest = UnityWebRequest.Post(databaseURL, form);
        yield return webRequest.SendWebRequest();
        doneFunction(webRequest.downloadHandler.text);
    }
    public void SlotsLoaded(string done)
    {
        bool[] charsAvailable = new bool[3];
        Debug.Log(done);
        for (int i = 0; i < 3; i++)
        {
            charsAvailable[i] = false;
        }
        if (done.Contains("|") || (done.Equals("")))
        {
            foreach (var data in done.Split('|'))
            {
                if (!data.Equals(""))
                {
                    charsAvailable[System.Int32.Parse(data)] = true;
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            loadSlots[i].SetActive(charsAvailable[i]);
        }
    }
    IEnumerator LoadCharacterSlotSQLStuff(Action<string> done,int slotIDx)
    {
        string databaseURL = "http://localhost/nsirpg/LoadingCustomisation.php";
        WWWForm form = new WWWForm();
        form.AddField("slotIndex", slotIDx);
        UnityWebRequest webRequest = UnityWebRequest.Post(databaseURL, form);
        yield return webRequest.SendWebRequest();
        done(webRequest.downloadHandler.text);
    }
    public void LoadCharacterSlot(int slotIndex)
    {
        StartCoroutine(LoadCharacterSlotSQLStuff(ProcessCharacterInfo, slotIndex));
    }
    public void ProcessCharacterInfo(string result)
    {
        Debug.Log(result);
        if (result.Contains("|")||(result.Equals("")))
        {
            string[] blah = result.Split('|');
            PlayerDatabaseData database = new PlayerDatabaseData();
            database.skinIndex = System.Int32.Parse(blah[0]);
            database.hairIndex = System.Int32.Parse(blah[1]);
            database.mouthIndex = System.Int32.Parse(blah[2]);
            database.eyesIndex = System.Int32.Parse(blah[3]);
            database.clothesIndex = System.Int32.Parse(blah[4]);
            database.armourIndex = System.Int32.Parse(blah[5]);
            database.classEnumIndex = System.Int32.Parse(blah[6]);
            database.charName = blah[7];
            database.strengthStat = System.Int32.Parse(blah[8]);
            database.constitutionStat = System.Int32.Parse(blah[9]);
            database.dexterityStat = System.Int32.Parse(blah[10]);
            database.intelligenceStat = System.Int32.Parse(blah[11]);
            database.wisdomStat = System.Int32.Parse(blah[12]);
            database.charismaStat = System.Int32.Parse(blah[13]);
            PlayerSaveAndLoad.database = database;
            SceneManager.LoadScene(2);
        }
    }
}
