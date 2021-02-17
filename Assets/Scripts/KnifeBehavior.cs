using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : MonoBehaviour
{
    [SerializeField]
    private float knifeSpeed = 150f;
    [SerializeField]
    List<knifeScriptableObject> knifeObject;
    [SerializeField]
    private int skinToUse = 0;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private bool wasUsed = false;

    public GameEventSO knifeHitLog;
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
        rb.isKinematic = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = knifeObject[skinToUse].GetSprite();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag is "Knife")
        {
            GameManager.gm.KnifeHitKnife();
            rb.velocity = new Vector2(0, 0);
            this.rb.gravityScale = 3;
            Debug.Log("DANGER");
        }

        if (collision.gameObject.tag is "Log")
        {
            this.transform.parent = collision.transform;
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
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
            bc.isTrigger = false;
        }
    }

    public void SetTrigger() {
        bc.isTrigger = true;
    }

   
}
