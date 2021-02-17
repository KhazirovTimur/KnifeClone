using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameBehaviourScript : MonoBehaviour
{
    public Text score;
    public Text appleCount;
    public Text knifesCount;

    private int scoreValue = 0;
    private int appleCountValue = 0;
    private int knifeCountCurrentValue = 0;
    private int knifeCountAllValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        knifeCountCurrentValue = GameManager.gm.knifeCount;
        knifeCountAllValue = GameManager.gm.knifeCount;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void UpdateUI() {
        scoreValue = GameManager.gm.scoreGlobal + GameManager.gm.scoreRound;
        appleCountValue = GameManager.gm.appleCount;
        knifeCountCurrentValue = GameManager.gm.knifeCount;
        knifeCountAllValue = GameManager.gm.goal;
        score.text = scoreValue.ToString();
        appleCount.text = appleCountValue.ToString();
        string tmp = knifeCountCurrentValue.ToString() + "/" + knifeCountAllValue.ToString();
        knifesCount.text = tmp;    
    }
}
