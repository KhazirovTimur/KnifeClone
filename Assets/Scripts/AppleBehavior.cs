using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehavior : MonoBehaviour
{
    public List<GameObject> applePieces;
    public GameEventSO appleHit;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag is "Knife")
        {
            foreach (GameObject tmp in applePieces)
            {
                tmp.SetActive(true);
                tmp.transform.parent = null;
            }
            appleHit.Raise();
            this.gameObject.SetActive(false); 
        
        }
        
    }

}
