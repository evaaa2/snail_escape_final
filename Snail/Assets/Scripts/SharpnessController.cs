using UnityEngine;
using UnityEngine.UI;

public class SharpnessController : MonoBehaviour
{
    public Material sharpnessMaterial;
    public Slider sharpnessSlider;
    public Slider lightnessSlider;
    public Image targetImage;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        sharpnessSlider.onValueChanged.AddListener(SetSharpness);
        SetSharpness(sharpnessSlider.value); // Initialize
        lightnessSlider.onValueChanged.AddListener(SetLightness);
        SetLightness(lightnessSlider.value);
        targetImage.material = new Material(targetImage.material);

    }

    void SetSharpness(float value)
    {
        targetImage.material.SetFloat("_Sharpness", value);
    }
    public void SetLightness(float value)
    {
        targetImage.material.SetFloat("_Lightness", value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
