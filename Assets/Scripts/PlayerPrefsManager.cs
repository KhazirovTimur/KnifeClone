using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsManager
{

    public static int GetHighScore() 
    {
        if (PlayerPrefs.HasKey("HighScore"))
            return PlayerPrefs.GetInt("HighScore");
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
            return 0;
        }
    }

    public static void SetHighScore(int i)
    {

            PlayerPrefs.SetInt("HighScore", i);

    }

        public static int GetKnifeNumber() 
    {
        if (PlayerPrefs.HasKey("KnifeNumber"))
            return PlayerPrefs.GetInt("KnifeNumber");
        else
        {
            PlayerPrefs.SetInt("KnifeNumber", 1);
            return 1;
        }
    }

    public static void SetKnifeNumber(int i)
    {
            PlayerPrefs.SetInt("KnifeNumber", i);

    }

    public static int GetApplesCount()
    {
        if (PlayerPrefs.HasKey("AppleCount"))
            return PlayerPrefs.GetInt("AppleCount");
        else
        { 
          PlayerPrefs.SetInt("AppleCount", 0);
          return 0;
        }
    }

    public static void SetApplesCount(int i)
    {

             PlayerPrefs.SetInt("AppleCount", i);

    }

    public static int GetMaxLevel()
    {
        if (PlayerPrefs.HasKey("MaxLevel"))
            return PlayerPrefs.GetInt("MaxLevel");
        else
        {
            PlayerPrefs.SetInt("MaxLevel", 1);
            return 1;
        }
    }

    public static void SetMaxLevel(int i)
    {

        PlayerPrefs.SetInt("MaxLevel", i);

    }
}
