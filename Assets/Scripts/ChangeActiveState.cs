using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActiveState : MonoBehaviour
{
    // Start is called before the first frame update
    public void Change()
    {
        if(this.isActiveAndEnabled)
         this.gameObject.SetActive(false);
     
    }
}
