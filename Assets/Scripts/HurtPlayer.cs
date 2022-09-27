using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public float damageAmount = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<HealthSystem>().takeDamage(damageAmount);
        }
    }
}
