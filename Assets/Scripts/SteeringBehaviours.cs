using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{
    [SerializeField] protected float maxSpeed, maxForce;
    protected Vector3 Velocity;
    private Vector3 location;
    private Vector3 acceleration;

    protected void Start()
    {
        acceleration = Vector3.zero;
        Velocity = Vector3.zero;
        location = transform.position;
    }
    protected Vector3 AvoidEdges()
    {
        if (location.x < - FindObjectOfType<Spawner>().SpawnRangeX + FindObjectOfType<Spawner>().Bounds)
        {
            return SteerForWallAvoid(new Vector2(maxSpeed, Velocity.y));
        }
        if (location.x > FindObjectOfType<Spawner>().SpawnRangeX - FindObjectOfType<Spawner>().Bounds)
        {
            return SteerForWallAvoid(new Vector2(-maxSpeed, Velocity.y));
        }
        if (location.y < -FindObjectOfType<Spawner>().SpawnRangeY + FindObjectOfType<Spawner>().Bounds)
        {
            return SteerForWallAvoid(new Vector2(Velocity.x, maxSpeed));
        }
        if (location.y > FindObjectOfType<Spawner>().SpawnRangeY - FindObjectOfType<Spawner>().Bounds)
        {
            return SteerForWallAvoid(new Vector2(Velocity.x, -maxSpeed));
        }
        
        return Vector3.zero;
    }
    private Vector3 SteerForWallAvoid(Vector3 desired)
    {
        Vector3 steer = Vector3.ClampMagnitude(desired - Velocity, maxForce);
        return steer;
    }
    protected void RotateTowardTarget()
    {
        Vector3 dirToDesiredLoc = location - transform.position;
        dirToDesiredLoc.Normalize();
        float rotZ = Mathf.Atan2(dirToDesiredLoc.y, dirToDesiredLoc.x) * Mathf.Rad2Deg;
        rotZ -= 90;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    protected Vector3 Steer(Vector3 targetPosition)
    {
        Vector3 desired = targetPosition - location;
        desired.Normalize();
        desired *= maxSpeed;
        Vector3 steer = Vector3.ClampMagnitude(desired - Velocity, maxForce);
        return steer;
    }
    protected Vector3 Flee(Vector3 targetPosition)
    {
        Vector3 desired = targetPosition - location;
        desired.Normalize();
        desired *= -maxSpeed;
        Vector3 steer = Vector3.ClampMagnitude(desired - Velocity, maxForce);
        return steer;
    }
    protected void ApplyForce(Vector3 force)
    {
        acceleration += force;
    }
    protected void ApplySteeringToMotion()
    {
        Velocity = Vector3.ClampMagnitude(Velocity + acceleration, maxSpeed);
        location += Velocity * Time.deltaTime;
        acceleration = Vector3.zero;
        RotateTowardTarget();
        transform.position = location;
    }
}
