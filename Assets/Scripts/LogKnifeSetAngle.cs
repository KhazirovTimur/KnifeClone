using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogKnifeSetAngle : MonoBehaviour
{
    public int minAngle = 0;
    public int maxAngle = 90;
    private bool done = false;
    public Collider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rot = Quaternion.Euler(0, 0, Random.Range(minAngle, maxAngle));//
        this.transform.rotation = rot;
    }

    public void SetTrigger()
    {
        bc.isTrigger = true;
    }

}
