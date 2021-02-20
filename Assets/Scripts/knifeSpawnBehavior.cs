using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeSpawnBehavior : MonoBehaviour
{

    public GameObject knife;
   
    [SerializeField]
    private float delay = 0.5f;
    
    private float cooldown;
    private bool lastKnife = false;

    public GameEventSO ThrowKnife;

    // Start is called before the first frame update
    void Start()
    {
        Spawnknife();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time>cooldown && !GameManager.gm.gameIsOver)
        {
            ThrowKnife.Raise();
            if(!lastKnife)
                Spawnknife();
            cooldown = Time.time + delay;
        }
    }

    public void SetLastknife()
    {
        lastKnife = true;
    }

    public void ResetLastKnife() {
        lastKnife = false;
    }

    public void Spawnknife() {
        Instantiate(knife, transform.position, transform.rotation);
    }
 
}
