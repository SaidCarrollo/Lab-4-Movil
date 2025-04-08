using UnityEngine;

[CreateAssetMenu(fileName = "ShipData", menuName = "UI/ShipData")]
public class ShipDataSO : ScriptableObject
{
    public string shipName;
    public Sprite shipSprite;
    public Sprite uiIcon;
    public int maxHealth;
    public float handling;
    public float scoreSpeed;
    public float fireRate;
    public Color shipColor;
}
