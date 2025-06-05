/*using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int sceneBuildIndex; //poradi scen

    public AudioClip soundEffect;

    public bool isInRange = false; //jsem v dost blizke vzdalenosti klici?
    public KeyCode interactWithKey; //mackam E
    public UnityEvent interactAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange) //pokud jsem blizko klice
        {
            if (Input.GetKeyDown(interactWithKey)) //pokud mackam tlacitko interagovat
            {
                AudioSource.PlayClipAtPoint(soundEffect, transform.position); //plays audio

                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single); //jde do next scene
                //interactAction.Invoke(); //zacne mi event, tohle tam nechavame, pokud bude nejaka animace...
            }
        }
    }

    //zjistuju, jestli mi snek colliduje
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}*/

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int sceneBuildIndex;
    public AudioClip soundEffect;
    public bool isInRange = false;
    public KeyCode interactWithKey;
    public UnityEvent interactAction;

    private bool isLoading = false; //zabrání dvojitému spuštìní

    void Update()
    {
        if (isInRange && !isLoading)
        {
            if (Input.GetKeyDown(interactWithKey))
            {
                StartCoroutine(PlaySoundAndLoadScene());
            }
        }
    }

    private System.Collections.IEnumerator PlaySoundAndLoadScene()
    {
        isLoading = true;

        // vytvoøení doèasného AudioSource pro pøehrání zvuku
        GameObject audioObject = new GameObject("TempAudio");
        AudioSource source = audioObject.AddComponent<AudioSource>();
        source.clip = soundEffect;
        source.Play();

        // poèkej, až zvuk dohraje
        yield return new WaitForSeconds(soundEffect.length);

        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}

