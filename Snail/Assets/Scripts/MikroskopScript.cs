using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class MikroskopScript : MonoBehaviour
{
   
    public RectTransform targetRect;
    public float stepSize = 1f;
    public TMP_Text winText;
    private RectTransform playerRect;
    private bool gameEnded = false;

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
        if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow)) move = Vector2.up * stepSize;
        if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow)) move = Vector2.down * stepSize;
        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow)) move = Vector2.left * stepSize;
        if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow)) move = Vector2.right * stepSize;

        playerRect.anchoredPosition += move;

        if (Vector2.Distance(playerRect.anchoredPosition, targetRect.anchoredPosition) < 0.1f)
        {
            gameEnded = true;
            if (winText != null)
            {
                winText.gameObject.SetActive(true);
            }
        }
    }

}
