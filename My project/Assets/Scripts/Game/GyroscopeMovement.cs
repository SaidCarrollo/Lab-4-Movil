using UnityEngine;

public class GyroscopeMovement : MonoBehaviour
{
    private Gyroscope gyroscope;
    private Quaternion rotation;

    [Header("References")]
    public SelectedShipDataSO selectedShipData;

    [Header("Position Limits")]
    public float minXPosition = -5f;
    public float maxXPosition = 5f;
    public float minYPosition = -5f;
    public float maxYPosition = 5f;

    private float handling = 1f;

    private void Start()
    {
        // Configura el handling desde el SO
        if (selectedShipData != null && selectedShipData.selectedShip != null)
        {
            handling = selectedShipData.selectedShip.handling;
        }

        // Activa giroscopio
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
        }
    }

    private void Update()
    {
        ControlarNave();
    }

    private void ControlarNave()
    {
        if (gyroscope != null)
        {
            // Obtener rotación del giroscopio
            rotation = gyroscope.attitude;

            // Ajuste para Landscape Left
            rotation = new Quaternion(-rotation.y, -rotation.x, rotation.z, rotation.w);

            // Rotar nave suavemente según el handling
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, handling * Time.deltaTime);

            // MOVIMIENTO vertical con inclinación
            // Usamos la rotación en X del giroscopio como inclinación vertical
            float verticalTilt = rotation.eulerAngles.x;
            if (verticalTilt > 180f) verticalTilt -= 360f; // Convertir a rango -180 a 180

            float verticalMovement = -verticalTilt / 90f * handling * Time.deltaTime * 5f;

            // Nueva posición Y limitada
            float newY = Mathf.Clamp(transform.position.y + verticalMovement, minYPosition, maxYPosition);
            float newX = Mathf.Clamp(transform.position.x, minXPosition, maxXPosition);

            // Aplicar nueva posición
            transform.position = new Vector3(newX, newY, transform.position.z);
        }
    }
}



