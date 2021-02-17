using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New KnifeData", menuName = "Knife Data", order = 51)]
public class knifeScriptableObject : ScriptableObject
{

    [SerializeField]
    private Sprite knifePicture;

    public Sprite GetSprite() {
        return knifePicture;
    }
    
    // Start is called before the first frame update
    
}
