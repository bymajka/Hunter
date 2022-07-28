using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class HunterScript : MonoBehaviour
{
    [SerializeField] private float hunterSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    public delegate void OnDie();
    public static event OnDie ONDie;

    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(xDirection, yDirection).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * hunterSpeed, moveDirection.y * hunterSpeed);
    }

    protected internal void Die()
    {
        Destroy(gameObject);
        ONDie?.Invoke();
    }
}
