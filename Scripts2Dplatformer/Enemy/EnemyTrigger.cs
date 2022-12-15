using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Health health;
    [SerializeField] private Collider2D trigger_BoxCollider; //  Коллайдер игрока для отнимания жизни

    public void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Player")
        if (other == trigger_BoxCollider)
        {
            health.TakeDamage(1);
        }
    }
}
