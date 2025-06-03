using UnityEngine;
using UnityEngine.SceneManagement;

public class microscopLInteraction : MonoBehaviour
{
    public int sceneIndex = 2;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("You have clicked the button!");
            SceneManager.LoadScene(sceneIndex);
        }
    }
    
    

}
