using UnityEngine;

public class DamageDiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<HunterScript>() == null && !other.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
