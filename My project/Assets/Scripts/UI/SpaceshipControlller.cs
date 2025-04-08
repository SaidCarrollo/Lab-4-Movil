using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private Gyroscope gyroscope;
    private Vector3 acceleration;
    private Quaternion rotation;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Acelerómetro para movimiento
        acceleration = Input.acceleration;
        Vector3 movement = new Vector3(0, acceleration.y, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (gyroscope != null)
        {
            rotation = gyroscope.attitude;
            // Ajuste de rotación para que sea en el eje vertical
            rotation = new Quaternion(-rotation.y, -rotation.x, rotation.z, rotation.w);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
