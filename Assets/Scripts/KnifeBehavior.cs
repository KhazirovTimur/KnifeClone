using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : MonoBehaviour
{
    [SerializeField]
    List<knifeScriptableObject> knifeObject; //knife skins

    [SerializeField]
    private float knifeSpeed = 150f; 

    [SerializeField]
    private int skinToUse = 1;

    private Rigidbody2D rb;
    private List<BoxCollider2D> bc = new List<BoxCollider2D>();
    private bool wasUsed = false;

    public GameEventSO knifeHitLog;
    public GameEventSO knifeHitKnife;
    public GameObject particles;
    // Start is called before the first frame update
    private void Awake()
    {
        skinToUse = PlayerPrefsManager.GetKnifeNumber();
        Vibration.Init();
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc.Add(this.GetComponents<BoxCollider2D>()[0]);
        bc.Add(this.GetComponents<BoxCollider2D>()[1]);
        rb.isKinematic = true;
        bc[0].isTrigger = true;
        bc[1].isTrigger = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = knifeObject[skinToUse].GetSprite();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag is "Knife")
        {
            Vibration.VibratePeek();
            bc[0].isTrigger = true;
            bc[1].isTrigger = true;
            GameManager.gm.KnifeHitKnife();
            rb.velocity = new Vector2(0, 0);
            this.rb.gravityScale = 3;
            knifeHitKnife.Raise();
        }

        if (collision.gameObject.tag is "Log")
        {
            Vibration.VibratePop();
            this.transform.parent = collision.transform;
            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0;
            knifeHitLog.Raise();
        }

        
    }

    public void ThrowKnife()
    {
        if (!wasUsed)
        {
            rb.isKinematic = false;
            rb.velocity = (new Vector2(0, knifeSpeed));
            wasUsed = true;
            bc[0].isTrigger = false;
            bc[1].isTrigger = false;
        }
    }

    public void SetTrigger() { //set knife to trigger after getting WinEvent to exlcude situations, when triggering KnifeHitKnife after destroying log
        bc[0].isTrigger = true;
        bc[1].isTrigger = true;
    }

   
}
