using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public TextMeshProUGUI textPro; // Asigna el TextMeshPro desde el Inspector
    public float speed = 1f; // Velocidad del cambio de color

    void Update()
    {
        if (textPro != null)
        {
            float r = Mathf.Sin(Time.time * speed) * 0.5f + 0.5f;
            float g = Mathf.Sin(Time.time * speed + 2f) * 0.5f + 0.5f;
            float b = Mathf.Sin(Time.time * speed + 4f) * 0.5f + 0.5f;

            textPro.color = new Color(r, g, b, 1f);
        }
    }
}
