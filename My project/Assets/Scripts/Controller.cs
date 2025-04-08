using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [HideInInspector] public Transform cube;
    [SerializeField] private Transform cube2;

    [Header("Accelerator")]
    public Vector3 dataAccelerator;
    public Vector3 datadataAcceleratorScaled;

    public bool useAccelerator = true;
    
    [Header("Gyroscope")]
    public Quaternion dataGyroscope;
    public Vector3 datadataGyroscopeScaled;

    public bool useGyroscope = false;

    private float _xScale = 1f;
    private float _yScale = 1f;
    private float _zScale = 1f;

    private Gyroscope gyroscope;

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;

            Debug.Log("Gyroscope enable");
        }
    }


    private void Update()
    {
        if (useAccelerator)
        {
            dataAccelerator = Input.acceleration;

            datadataAcceleratorScaled = Vector3.Scale(dataAccelerator, new Vector3(_xScale, _yScale, _zScale));

            cube.position += datadataAcceleratorScaled * Time.deltaTime;
        }

        if (useGyroscope && gyroscope != null)
        {
            dataGyroscope = gyroscope.attitude;

            datadataGyroscopeScaled = Vector3.Scale(dataGyroscope.eulerAngles, new Vector3(_xScale, _yScale, -_zScale));

            cube.rotation = Quaternion.Euler(datadataGyroscopeScaled);
        }
        
    }

    public void ResetPosition()
    {
        cube.position = Vector3.zero;
        cube.rotation = Quaternion.identity;
    }

    public void UpdateScaleX(bool isScaled)
    {
        _xScale = isScaled ? 1 : 0;
    }

    public void UpdateScaleY(bool isScaled)
    {
        _yScale = isScaled ? 1 : 0;
    }

    public void UpdateScaleZ(bool isScaled)
    {
        _zScale = isScaled ? 1 : 0;
    }
}
