using TMPro;
using UnityEngine;

public class UIdisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;

    private void Awake()
    {
        if (FindObjectOfType<HunterScript>() != null)
        {
            ammoText.text = "Bullets: " + FindObjectOfType<Shooting>().GetAmmoCount.ToString();
            Shooting.AmmoUsed += ChangeAmmoCount;
        }
    }

    private void ChangeAmmoCount(int count)
    {
        ammoText.text = "Bullets: " + count;
    }

    private void OnDisable()
    {
        Shooting.AmmoUsed -= ChangeAmmoCount;
    }
}
