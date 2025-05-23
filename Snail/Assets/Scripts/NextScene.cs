using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int sceneBuildIndex;

    public bool hasKey = true;

    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D other)
    {
        while (hasKey == true)
        {
            print("Trigger Entered");

            // Could use other.GetComponent<Player>() to see if the game object has a Player component
            // Tags work too. Maybe some players have different script components?
            if (other.tag == "Player")
            {
                // Player entered, so move level
                print("Switching Scene to " + sceneBuildIndex);
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                hasKey = false;
            }
        }
    }

}
