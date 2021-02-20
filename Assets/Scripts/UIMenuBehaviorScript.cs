using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuBehaviorScript : MonoBehaviour
{
    public Text highScore;
    public Text appleCount;
    public Text maxLevel;

    private int highScoreValue;
    private int appleCountValue;
    private int maxLevelValue;

    public GameEventSO ChangeWindowEv;
    // Start is called before the first frame update
    void Start()
    {
        appleCountValue = PlayerPrefsManager.GetApplesCount();
        highScoreValue = PlayerPrefsManager.GetHighScore();
        maxLevelValue = PlayerPrefsManager.GetMaxLevel();
        UpdateUI();
    }

    public void UpdateUI()
    {
        highScore.text = "High score: " + highScoreValue.ToString();
        appleCount.text =  appleCountValue.ToString();
        maxLevel.text = "Max Level: " + maxLevelValue.ToString();
    }

    public void ChangeWindow() {
        ChangeWindowEv.Raise();
    }
}
