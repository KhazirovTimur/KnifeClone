using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;

    public void SpawnObj() {
        Instantiate(obj, this.transform.position, this.transform.rotation);
    }
    
}
