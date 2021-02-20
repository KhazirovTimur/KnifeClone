using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverBehaviorScript : MonoBehaviour
{


    public Text score;
    public Text level;

    private int scoreValue = 0;
    private int levelValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        scoreValue = GameManager.gm.scoreGlobal + GameManager.gm.scoreRound;
        levelValue = GameManager.gm.level;
        score.text = scoreValue.ToString();
        level.text = "Level " + levelValue.ToString();
    }

    public void SetChildrensActive() {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
            this.transform.GetChild(i).gameObject.SetActive(true);
            
    }
}
