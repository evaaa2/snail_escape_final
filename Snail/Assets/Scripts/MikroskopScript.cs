using TMPro;
using Unity.VisualScripting;
using UnityEditor;
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
    public bool lightIsOk = false;
    public bool sharp = false;
    public Slider sharpnessSlider;
    public Slider lightnessSlider;
    public TextMeshProUGUI lightText;
    public TextMeshProUGUI sharpnessText;

    public RectTransform leftBorder;
    public RectTransform rightBorder;
    public RectTransform topBorder;
    public RectTransform bottomBorder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRect = GetComponent<RectTransform>();
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
        if (lightText != null)
        {
            lightText.gameObject.SetActive(false);
        }
        if (sharpnessText != null)
        {
            sharpnessText.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        ClampToBorders();
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
            lightIsOk = true;
        }
        if (position) 
        {
            if (lightText != null)
            {
                lightText.gameObject.SetActive(true);
            }
        }
        if (lightIsOk)
        {
            if (sharpnessText != null)
            {
                sharpnessText.gameObject.SetActive(true);
            }
        }
        if (lightIsOk && sharp && position)
        {
            gameEnded = true;
            if (winText != null)
            {
                winText.gameObject.SetActive(true);
            }
        }
    }

    void ClampToBorders()
    {
        Vector2 pos = playerRect.anchoredPosition;

        float halfWidth = playerRect.rect.width / 2;
        float halfHeight = playerRect.rect.height / 2;

        float minX = leftBorder.anchoredPosition.x + halfWidth;
        float maxX = rightBorder.anchoredPosition.x - halfWidth;
        float minY = bottomBorder.anchoredPosition.y + halfHeight;
        float maxY = topBorder.anchoredPosition.y - halfHeight;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        playerRect.anchoredPosition = pos;
    }

}
