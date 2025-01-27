using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Jigsaw Variables
    public bool isJigsaw = false;
    public static int lockedPieces = 0;
    public static int usedMap = 0;
    GameObject winScreen;
    GameObject winText;
    GameObject highscore;

    float timer = 0;

    void Start()
    {
        if (isJigsaw == true)
        {
            winScreen = GameObject.Find("Win_Screen");
            winText = GameObject.Find("Time_Taken");
            highscore = GameObject.Find("Highscore 1");
            winScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lockedPieces);
        if (lockedPieces == 36)
        {
            winScreen.SetActive(true);
            winText.GetComponent<Text>().text = "Du har brugt " + timer + " sek. & \"Vis kort\" " + usedMap + " gange.";

            if (timer < PlayerPrefs.GetFloat("Highscore_Time") || PlayerPrefs.GetFloat("Highscore_Time") < 0)
            {
                PlayerPrefs.SetFloat("Highscore_Time", timer);
            }
            if (usedMap < PlayerPrefs.GetInt("Highscore_MapUse") || PlayerPrefs.GetInt("Highscore_MapUse") < 0)
            {
                PlayerPrefs.SetInt("Highscore_MapUse", usedMap);
            }

            highscore.GetComponent<Text>().text = PlayerPrefs.GetFloat("Highscore_Time") + " sekunder, " + PlayerPrefs.GetInt("Highscore_MapUse") + " Vis Kort ";
            PlayerPrefs.Save();
        }
        if (lockedPieces < 36)
        {
            timer += Time.deltaTime;
        }
        Debug.Log(PlayerPrefs.GetFloat("Highscore_MapUse"));
    }
    public void DebugWin()
    {
        lockedPieces = 36;
    }

    public void ResetHighscore()
    {
        lockedPieces++;
        PlayerPrefs.SetFloat("Highscore_Time", -1);
        PlayerPrefs.SetInt("Highscore_MapUse", -1);
    }
}