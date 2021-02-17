using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KnifesCountSO", menuName = "Knifes Count SO", order = 53)]
public class KnifesCountSO : ScriptableObject
{
    [SerializeField]
    private int knifesCount = 5;

    public GameEventSO knifesOut;


}
