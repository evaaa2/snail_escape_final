using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BinInteraction : MonoBehaviour
{
    public Sprite openBinSprite;
    public GameObject interactionPrompt;
    public Image canvasCounterpart; // Obrazek si nechame v canvasu, protoze se pres to lepe zarovnava. Veskerou funcionalitu ale delame tady, kde jsme na objektu mimo canvas.

    private Sprite closedBinSprite;
    private bool isOpen = false;
    private bool playerInRange = false;

    void Start()
    {
        closedBinSprite = canvasCounterpart.sprite;
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
        canvasCounterpart.sprite = isOpen ? openBinSprite : closedBinSprite;
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

