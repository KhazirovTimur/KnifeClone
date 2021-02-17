using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsManager
{

    public static void HighScore() 
    { 
    
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
        if (PlayerPrefs.HasKey("AppleCount"))
             PlayerPrefs.SetInt("AppleCount", i);
        else
             PlayerPrefs.SetInt("AppleCount", 0);
    }
}
