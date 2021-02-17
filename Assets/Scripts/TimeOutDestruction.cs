using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutDestruction : MonoBehaviour
{
    public float lifetime = 2;

    private float timeout;

    private void Start()
    {
        timeout = Time.time + lifetime;
    }
    void Update()
    {
        if (Time.time > timeout)
            Destroy(this.gameObject);
    }
}
