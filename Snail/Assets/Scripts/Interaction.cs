using UnityEngine;
using UnityEngine.UI;

public class BinInteraction : MonoBehaviour
{
    public Sprite openBinSprite;                     // Sprite to display when bin is open
    public GameObject interactionPrompt;             // UI prompt shown when player is in range
    public Image canvasCounterpart;                  // UI Image from canvas that visually represents the bin

    private Sprite closedBinSprite;                  // Original (closed) sprite
    private bool isOpen = false;
    private bool playerInRange = false;

    void Start()
    {
        // Store the default closed sprite from the canvas image
        closedBinSprite = canvasCounterpart.sprite;

        // Hide interaction prompt at start
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.I))
        {
            ToggleBin();
        }
    }

    void ToggleBin()
    {
        isOpen = !isOpen;
        Debug.Log("Toggling bin. IsOpen: " + isOpen);


        canvasCounterpart.sprite = isOpen ? openBinSprite : closedBinSprite;
        canvasCounterpart.preserveAspect = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactionPrompt != null)
                interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactionPrompt != null)
                interactionPrompt.SetActive(false);
        }
    }
}
