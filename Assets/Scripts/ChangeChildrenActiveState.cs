using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChildrenActiveState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChildrensActive()
    {
        if(this.transform.GetChild(0).gameObject.activeSelf == false )
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
                this.transform.GetChild(i).gameObject.SetActive(true);
        else
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
                this.transform.GetChild(i).gameObject.SetActive(false);
    }
}
