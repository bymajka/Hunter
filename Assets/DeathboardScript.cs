using UnityEngine;

public class DeathboardScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HunterScript hunter = other.GetComponent<HunterScript>();
            if (hunter != null)
            {
                hunter.Die();
            }
        }
        else
        {
            foreach (Transform child in other.gameObject.transform)
            {
                if (child.CompareTag("Creature"))
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
