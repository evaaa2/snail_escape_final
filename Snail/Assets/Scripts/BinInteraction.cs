using UnityEngine;
using TMPro;

public class BinInteraction : MonoBehaviour
{
    public Sprite openBinSprite;
    public GameObject interactionPrompt;

    private Sprite closedBinSprite;
    private SpriteRenderer sr;
    private bool isOpen = false;
    private bool playerInRange = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        closedBinSprite = sr.sprite;
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
        sr.sprite = isOpen ? openBinSprite : closedBinSprite;
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

