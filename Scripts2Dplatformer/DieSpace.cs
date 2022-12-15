using UnityEngine;

public class DieSpace : MonoBehaviour
{
    public GameObject respawn;
    public Health health;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            health.TakeDamage(1);
            other.transform.position = respawn.transform.position;
        }
    }

}
