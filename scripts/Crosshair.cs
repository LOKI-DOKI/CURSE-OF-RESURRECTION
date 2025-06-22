using UnityEngine;
using UnityEngine.UI;

public class CrosshairSetup : MonoBehaviour
{
    public Image crosshairImage;
    public Sprite crosshairSprite; // Drag sprite here in Inspector

    void Start()
    {
        if (crosshairImage != null && crosshairSprite != null)
        {
            crosshairImage.sprite = crosshairSprite;
        }
    }
}

