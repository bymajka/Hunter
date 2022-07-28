using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Shooting : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileLifeTime = 2f;
    private Vector3 mousePos;

    public delegate void RunOutOfAmmo();
    public static event RunOutOfAmmo runOutOfAmmo;

    [Header("PlayerSettings")] 
    [SerializeField] private int ammoCount;
    public delegate void AmmoCounter(int count);
    public static AmmoCounter AmmoUsed;
    public int GetAmmoCount => ammoCount;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        var currentPosition = transform.position;
        Vector3 rotation = currentPosition - mousePos;
        Vector3 direction = mousePos - currentPosition;
        TakeShot(direction, rotation);
    }

    private void TakeShot(Vector3 directionValue, Vector3 rotationValue)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoCount > 0)
        {
            GameObject instance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = instance.GetComponent<Rigidbody2D>();
            ammoCount--;
            AmmoUsed(ammoCount);
            if (bulletRb != null)
            {
                bulletRb.velocity = new Vector2(directionValue.x, directionValue.y).normalized * projectileSpeed;
                float rot = Mathf.Atan2(rotationValue.y, rotationValue.x) * Mathf.Rad2Deg;
                bulletRb.transform.rotation = Quaternion.Euler(0,0,rot + 90);
                Destroy(instance, projectileLifeTime);
            }
        }
        else if(ammoCount <= 0)
        {
            runOutOfAmmo();
        }
    }
}
