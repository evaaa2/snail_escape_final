using UnityEngine;
using UnityEngine.SceneManagement;

public class microscopLInteraction : MonoBehaviour
{
    public int sceneIndex = 2;
    public GameObject interactionPrompt;
    private bool playerInRange = false;
    void Start()
    {
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("You have clicked the button!");
            SceneManager.LoadScene(sceneIndex);
        }
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
    
    


