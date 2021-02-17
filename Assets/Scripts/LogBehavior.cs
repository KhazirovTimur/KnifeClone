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

    private void Awake()
    {
         logKnifes[0].SetActive(BoolGenerator());
         logKnifes[1].SetActive(BoolGenerator());
         logKnifes[2].SetActive(BoolGenerator());
        
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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, logObject.GetRotSpeed() * Time.deltaTime, Space.Self);
    }

    

    public void DestroyLog() {

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

    private bool BoolGenerator()
    {
        int prob = Random.Range(0,100);
        return prob <= 50;
    }

    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
