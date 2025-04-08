using UnityEngine;
public class AcelerometerMovement : MonoBehaviour
{
    [Header("Configurable")]
    public SelectedShipDataSO selectedShipData;
    public float maxYPosition = 5f;
    public float minYPosition = -5f;

    private float moveSpeed;
    private Vector3 acceleration;

    private void Start()
    {
        moveSpeed = selectedShipData.selectedShip.handling;
    }

    private void Update()
    {
        MoverNave();
    }

    private void MoverNave()
    {
        acceleration = Input.acceleration;
        float movimientoVertical = acceleration.y * moveSpeed * Time.deltaTime;

        float nuevaPosicionY = Mathf.Clamp(transform.position.y + movimientoVertical, minYPosition, maxYPosition);

        transform.position = new Vector3(transform.position.x, nuevaPosicionY, transform.position.z);
    }
}

