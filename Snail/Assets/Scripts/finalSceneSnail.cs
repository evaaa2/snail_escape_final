
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class finalSceneSnail : MonoBehaviour
{
    public Transform sprite;
    public Vector3 exitPosition;
    public float speed = 5f;
    private bool exiting = false;
    public Image bubble;
    public TextMeshProUGUI thanksText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if (thanksText != null)
        {
            thanksText.gameObject.SetActive(true);
        }
        if (bubble != null)
        {
            //bubble.enabled = true;
        }
        float offScreenX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + 2f;
        exitPosition = new Vector3(offScreenX, sprite.position.y, sprite.position.z);
        Invoke("StartExit", 30f);

    }

    

    // Update is called once per frame
    void Update()
    {
        if (exiting)
        {
            sprite.position = Vector3.MoveTowards(sprite.position, exitPosition, speed * Time.deltaTime);
        }
    }

    public void StartExit()
    {
        Debug.Log("30 seconds passed with Invoke!");
        if (thanksText != null)
        {
            thanksText.gameObject.SetActive(false);
        }
        if (bubble != null)
        {
            //bubble.enabled = false;
        }
        exiting = true;
    }
}
