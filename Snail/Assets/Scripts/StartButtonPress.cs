using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButtonPress : MonoBehaviour
{
    public Button yourButton;
    public int sceneIndex = 1;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene(sceneIndex);
    }

}
