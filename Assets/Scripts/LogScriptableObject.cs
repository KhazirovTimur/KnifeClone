using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Log SO", menuName = "Log Data", order = 52)]
public class LogScriptableObject : ScriptableObject
{
    [SerializeField]
    private float appleSpawnChance = 0.25f;
    [SerializeField]
    private float rotSpeed = 180f;

    public float GetAppleSpawnChance() { return appleSpawnChance; }
    public float GetRotSpeed() { return rotSpeed; }
}
