using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class MikroskopScript : MonoBehaviour
{
   
    public RectTransform targetRect;
    public float stepSize = 50f;
    public TMP_Text winText;
    private RectTransform playerRect;
    public bool isHold = false;
    private bool gameEnded = false;
    public bool position = false;
    public bool light = false;
    public bool sharp = false;
    public Slider sharpnessSlider;
    public Slider lightnessSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRect = GetComponent<RectTransform>();
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded) return;

        Vector2 move = Vector2.zero;
        if (UnityEngine.Input.GetKey(KeyCode.UpArrow))
        {
            move += Vector2.up * stepSize * Time.deltaTime;
            isHold = true;
        }

        if (UnityEngine.Input.GetKey(KeyCode.DownArrow))
        {
            move += Vector2.down * stepSize * Time.deltaTime;
            isHold = true;
        }
        if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            move += Vector2.left * stepSize * Time.deltaTime;
            isHold = true;
        }
        if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            move += Vector2.right * stepSize * Time.deltaTime;
            isHold = true;
        }

        move = move.normalized;

        if (UnityEngine.Input.GetKeyUp(KeyCode.UpArrow))
        {
            isHold = false;
        }
        if (UnityEngine.Input.GetKeyUp(KeyCode.DownArrow))
        {
            isHold = false;
        }
        if (UnityEngine.Input.GetKeyUp(KeyCode.RightArrow))
        {
            isHold = false;
        }
        if (UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isHold = false;
        }

        playerRect.anchoredPosition += move;

        if (Vector2.Distance(playerRect.anchoredPosition, targetRect.anchoredPosition) < 5f)
        {
            position = true;
        }
        if (sharpnessSlider.value == 1) 
        {
            sharp = true;
        }
        if (lightnessSlider.value < 0.55 && lightnessSlider.value > 0.4)
        {
            light = true;
        }
        if (light && sharp && position)
        {
            gameEnded = true;
            if (winText != null)
            {
                winText.gameObject.SetActive(true);
            }
        }
    }

}
