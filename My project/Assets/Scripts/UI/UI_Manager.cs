using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Score_LifeDataSO Score_LifeSO;
    [SerializeField] private TextMeshProUGUI Scoretext;
    [SerializeField] private TextMeshProUGUI Lifetext;
    [SerializeField] private PaletteSO paletteColor;
    public List<GameObject> guiElementsToRecolor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ApplyPalette();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Score:" + Score_LifeSO.currentScore.ToString();
        Lifetext.text = "Life:" + Score_LifeSO.currentlife.ToString();
    }
    private void ApplyPalette()
    {
        for (int i = 0; i < guiElementsToRecolor.Count; i++)
        {
            GameObject obj = guiElementsToRecolor[i];

            if (obj.TryGetComponent<Image>(out var image))
            {
                image.color = paletteColor.color;
            }
            else if (obj.TryGetComponent<Text>(out var text))
            {
                text.color = paletteColor.color;
            }
            else if (obj.TryGetComponent<TMPro.TMP_Text>(out var tmpText))
            {
                tmpText.color = paletteColor.color;
            }
            else if (obj.TryGetComponent<RawImage>(out var rawImage))
            {
                rawImage.color = paletteColor.color;
            }
        }
    }
}
