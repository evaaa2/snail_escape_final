using UnityEngine;
using UnityEngine.UI;

public class SharpnessController : MonoBehaviour
{
    public Material sharpnessMaterial;
    public Slider sharpnessSlider;
    public Slider lightnessSlider;
    public RawImage targetImage;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        sharpnessSlider.onValueChanged.AddListener(SetSharpness);
        SetSharpness(sharpnessSlider.value); // Initialize
        lightnessSlider.onValueChanged.AddListener(SetLightness);
        SetLightness(lightnessSlider.value);

    }

    void SetSharpness(float value)
    {
        sharpnessMaterial.SetFloat("_Sharpness", value);
    }
    public void SetLightness(float value)
    {
        sharpnessMaterial.SetFloat("_Lightness", value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
