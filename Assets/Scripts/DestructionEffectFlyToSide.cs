using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script is used for throwing objects to sides, making "explosion" effect

public class DestructionEffectFlyToSide : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float force = 100;
    public void DestructionEffect()
    {
        rb.isKinematic = false;
        float salt = Random.Range(1, 20);
        salt = salt / 10;
        rb.AddForce(new Vector2(this.transform.position.x * force*salt, this.transform.position.y * force/3 * salt));
        rb.gravityScale = 3;
    }
}
