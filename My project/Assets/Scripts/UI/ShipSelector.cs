using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class ShipSelector : MonoBehaviour
{
    [Header("Ship Data")]
    public ShipDataSO ship1;
    public ShipDataSO ship2;
    public ShipDataSO ship3;
    [Header("Pallet Data")]
    public PaletteSO palette;

    [Header("Selected Ship Holder")]
    public SelectedShipDataSO selectedShipData;

    [Header("GUI Elements to Recolor")]
    public List<GameObject> guiElementsToRecolor;

    [Header("Sliders por Nave")]
    public List<Slider> healthSliders;     
    public List<Slider> handlingSliders;    
    public List<Slider> scoreSpeedSliders;
    public List<Slider> fireRateSliders;
    private void Awake()
    {
        SetStatsToSliders();
    }

    private void SetStatsToSliders()
    {
        ShipDataSO[] ships = new ShipDataSO[3] { ship1, ship2, ship3 };

        for (int i = 0; i < ships.Length; i++)
        {
            if (i < healthSliders.Count)
                healthSliders[i].value = ships[i].maxHealth;

            if (i < handlingSliders.Count)
                handlingSliders[i].value = ships[i].handling;

            if (i < scoreSpeedSliders.Count)
                scoreSpeedSliders[i].value = ships[i].scoreSpeed;

            if (i < fireRateSliders.Count)
                fireRateSliders[i].value = ships[i].fireRate;
        }
    }
    public void SelectShip1()
    {
        SelectShip(ship1);
        palette.color = ship1.shipColor;
    }

    public void SelectShip2()
    {
        SelectShip(ship2);
        palette.color = ship2.shipColor;
    }

    public void SelectShip3()
    {
        SelectShip(ship3);
        palette.color = ship3.shipColor;
    }

    private void SelectShip(ShipDataSO ship)
    {
        selectedShipData.selectedShip = ship;

        Color selectedColor = ship.shipColor;

        for (int i = 0; i < guiElementsToRecolor.Count; i++)
        {
            GameObject obj = guiElementsToRecolor[i];

            if (obj.TryGetComponent<Image>(out var image))
            {
                image.color = selectedColor;
            }
            else if (obj.TryGetComponent<Text>(out var text))
            {
                text.color = selectedColor;
            }
            else if (obj.TryGetComponent<TMPro.TMP_Text>(out var tmpText))
            {
                tmpText.color = selectedColor;
            }
            else if (obj.TryGetComponent<RawImage>(out var rawImage))
            {
                rawImage.color = selectedColor;
            }
            // Agrega más componentes si necesitas
        }

        Debug.Log($"Nave seleccionada: {ship.shipName}");
    }
}
