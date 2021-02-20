using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseKnife : MonoBehaviour
{
    public int knifeNumber = 0;

    public GameEventSO ChangeWindowEv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoseKnifeFu() {
        PlayerPrefsManager.SetKnifeNumber(knifeNumber);
        ChangeWindowEv.Raise();
    }
}
