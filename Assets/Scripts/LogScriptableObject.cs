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
    [SerializeField]
    private float rotSpeedSeed = 180f;
    [SerializeField]
    private float minSpeed = 0f;
    [SerializeField]
    private float minSpeedSeed = 60f;
    [SerializeField]
    private float interval = 2f;
    [SerializeField]
    private float minSpeedInterval = 2f;

    public float GetAppleSpawnChance() { return appleSpawnChance; }
    public float GetRotSpeed() { return rotSpeed; }

    public float GetRotSpeedSeed() { return rotSpeedSeed; }

    public float GetMinSpeed() { return minSpeed; }
    public float GetMinSpeedSeed() { return minSpeedSeed; }
    public float GetInterval() { return interval; }
    public float GetMinSpeedInterval() { return minSpeedInterval; }

}
