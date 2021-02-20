using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int knifeCount {  get; private set; } = 5;
    public int goal { get; private set; }
    public int scoreRound { get; private set; } = 0;
    public int scoreGlobal { get; private set; } = 0;
    public int appleCount { get; private set; } 
    public int level { get; private set; } = 1;

    public static GameManager gm;
    public bool gameIsOver = false;
    private int highScore;
    private int maxLevel;
    private int maxKnifes = 10;
    private int minKnifes;
    

    public GameEventSO WinEvent;
    public GameEventSO lastKnife;
    public GameEventSO UpdateUi;
    public GameEventSO NextLevel;
    public GameEventSO GameOver;
    
    public LogBehavior log;
    // Start is called before the first frame update
    private void Awake()
    {
        if (gm == null)
            gm = this;
        highScore = PlayerPrefsManager.GetHighScore();
        appleCount = PlayerPrefsManager.GetApplesCount();
        maxLevel = PlayerPrefsManager.GetMaxLevel();
    }
    void Start()
    {
        goal = knifeCount;
        minKnifes = knifeCount;
        UpdateUi.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameIsOver)
        if(goal == scoreRound)
        {
            gameIsOver = true;
            Win();
        }
    }

    public void knifeReduce() 
    {
        knifeCount -= 1;
        if (knifeCount == 0)
            lastKnife.Raise();
        UpdateUi.Raise();
    }

    public void KnifeHitKnife() {
        gameIsOver = true;
        if (highScore < scoreGlobal+scoreRound)
            PlayerPrefsManager.SetHighScore(scoreGlobal+scoreRound);
        if (maxLevel < level)
            PlayerPrefsManager.SetMaxLevel(level);
        StartCoroutine(GameOverState());
    }


    public void UpdateScore() {
        scoreRound = log.GetScore();
        UpdateUi.Raise();
    }

    public void AppleIncrease() {
        appleCount++;
        PlayerPrefsManager.SetApplesCount(appleCount);
        UpdateUi.Raise();
    }


    void Win()
    {
        WinEvent.Raise();
        StartCoroutine(StartingNextLevel());
    }

    IEnumerator StartingNextLevel() {
        yield return new WaitForSeconds(1);
        scoreGlobal += scoreRound;
        log.gameObject.SetActive(true);
        Destroy(log.gameObject);
        yield return new WaitForSeconds(1);
        level++;
        knifeCount = Random.Range(minKnifes, maxKnifes);
        if(log.BoolGenerator())
            maxKnifes++;
        if (log.BoolGenerator() && maxKnifes - minKnifes > 2)
            minKnifes++;
        goal = knifeCount;
        gameIsOver = false;
        scoreRound = 0;
        NextLevel.Raise();
        log = FindObjectOfType<LogBehavior>();
        UpdateUi.Raise();
    }

    IEnumerator GameOverState() {
        yield return new WaitForSeconds(1);
        GameOver.Raise();
    }
}
