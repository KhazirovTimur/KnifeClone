using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBehavior : MonoBehaviour
{
    public LogScriptableObject logObject;
    public GameObject apple;
    public List<GameObject> logKnifes;
    public List<GameObject> pieces; 
    public GameEventSO destrEffect;

    private int childCountStart;
    private float speedSeed;
    private float minSpeed ;
    private float minSpeedSeed;
    private float interval;
    private bool fixSpeed;
    private float changeSpeedTime;
    private bool setTime = true;
    private bool accelUp = false;
    private bool accelDown = true;
    private float roundSpeed;
    private float changeSpeed;
    private float minSpeedInterval;

    private void Awake()
    {
         logKnifes[0].SetActive(BoolGenerator());
         logKnifes[1].SetActive(BoolGenerator());
         logKnifes[2].SetActive(BoolGenerator());
         Vibration.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        float chance = logObject.GetAppleSpawnChance();
        if (Random.Range(0, 100) < chance)
            apple.SetActive(true);
        else
            apple.SetActive(false);
        
        childCountStart = gameObject.transform.childCount;


        speedSeed = Random.Range(0, logObject.GetRotSpeedSeed());
        minSpeedSeed = Random.Range(0, logObject.GetMinSpeedSeed());
        minSpeed = logObject.GetMinSpeed() + minSpeedSeed;
        interval = logObject.GetInterval();
        fixSpeed = BoolGenerator();
        roundSpeed = logObject.GetRotSpeed() + speedSeed;
        changeSpeed = roundSpeed;
        minSpeedInterval = logObject.GetMinSpeedInterval();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, changeSpeed *Time.deltaTime, Space.Self);

        if(!fixSpeed)
        {
            if (setTime)
            { 
                changeSpeedTime = Time.time + interval;
                setTime = false;
            }
            if (!setTime && Time.time > changeSpeedTime)
            {
                if(accelDown)
                    StartCoroutine(acceleration(minSpeed));
                if(accelUp)
                    StartCoroutine(acceleration(roundSpeed));
            }
        }
    }

    

    public void DestroyLog() {

        Vibration.Vibrate(500);
        foreach (Transform child in this.GetComponentsInChildren<Transform>())
        {
            child.parent = null;
        }
        
        foreach (GameObject tmp in pieces)
        {
            tmp.SetActive(true);
            tmp.transform.parent = null;
        }
        destrEffect.Raise();
        this.gameObject.SetActive(false);

    }

    public int GetScore()
    {
        return this.gameObject.transform.childCount - childCountStart;
    }

    public bool BoolGenerator()
    {
        int prob = Random.Range(0,100);
        return prob <= 50;
    }

    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }

    IEnumerator acceleration(float SetSpeed)
    {
        if (SetSpeed < changeSpeed)
        {
            while (changeSpeed > SetSpeed + (SetSpeed*0.1f)+1 && this.isActiveAndEnabled)
            {
                changeSpeed += (SetSpeed - changeSpeed) * 0.001f;
                //changeSpeed -= 0.05f;
                yield return new WaitForFixedUpdate();
            }
            changeSpeed = SetSpeed;
            accelDown = false;
            accelUp = true;
            setTime = false;
            changeSpeedTime = minSpeedInterval + Time.time;
        }
        else
        {
            while (changeSpeed < SetSpeed - (SetSpeed * 0.01f) - 1 && this.isActiveAndEnabled)
            {
                changeSpeed += (SetSpeed - changeSpeed) * 0.001f;
                //changeSpeed += 0.05f;
                yield return new WaitForFixedUpdate();
            }
            changeSpeed = SetSpeed;
            accelDown = true;
            accelUp = false;
            setTime = true;
        }
    }
}
