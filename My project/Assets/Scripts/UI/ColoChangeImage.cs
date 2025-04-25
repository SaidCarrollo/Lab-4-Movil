using UnityEngine;
using UnityEngine.UI;

public class ColorChangeImagen : MonoBehaviour
{
    public Image imagen; // Asigna la imagen desde el Inspector
    public Color color1 = Color.red;
    public Color color2 = Color.green;
    public Color color3 = Color.blue;
    public float velocidad = 1f;

    private float tiempo;

    void Update()
    {
        tiempo += Time.deltaTime * velocidad;
        float t = Mathf.PingPong(tiempo, 2f);

        if (t < 1f)
        {
            imagen.color = Color.Lerp(color1, color2, t);
        }
        else
        {
            imagen.color = Color.Lerp(color2, color3, t - 1f);
        }
    }
}
