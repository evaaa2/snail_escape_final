using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MapMinigame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidBody;
    public float movementSpeed = 5f;
    private Vector2 movementDirection;

    public TextMeshProUGUI currentCountryText;
    public TextMeshProUGUI gameEndText;

    public string currentCountryName;
    public List<Transform> countryObjects;
    private Dictionary<string, Transform> countryMap = new Dictionary<string, Transform>();
    private List<string> remainingCountries = new List<string>();
    private Transform currentCountryObject;
    private Transform playerTouchingCountry;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        gameEndText.text = "";
        InitializeCountryMap();
        ShowNextCountry();
    }

    void ShowNextCountry() //vybere nahodne zemi, ktera jeste nebyla pouzita
    {
        if (remainingCountries.Count == 0) //pokud zadna zeme nezbyva -> konec hry
        {
            EndGame();
            return;
        }

        int index = Random.Range(0, remainingCountries.Count);
        currentCountryName = remainingCountries[index];
        currentCountryObject = countryMap[currentCountryName];

        currentCountryText.text = currentCountryName;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        float inputX = UnityEngine.Input.GetAxisRaw("Horizontal");
        float inputY = UnityEngine.Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
       
        //rotation to face the right direction
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Face right
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f); // Face left
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f); // Face left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 270f); // Face left
        }

        //testovani, jestli spravne nebo spatne
        if (playerTouchingCountry != null)
        {
            if (playerTouchingCountry == currentCountryObject)
            {
                Debug.Log("Correct!");
                remainingCountries.Remove(currentCountryName);
                ShowNextCountry();
            }
            else
            {
                Debug.Log("Wrong country.");
            }
        }

    }

    void InitializeCountryMap() //priradi do listu ke kazdemu nazvu zeme dany gameobject
    {
        foreach (Transform country in countryObjects)
        {
            string name = country.name; // Assumes the GameObject is named after the country
            countryMap[name] = country;
            remainingCountries.Add(name);
        }
    }

    void EndGame()
    {
        currentCountryText.text = "";
        gameEndText.text = "GREAT JOB!";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (countryObjects.Contains(other.transform))
        {
            playerTouchingCountry = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (playerTouchingCountry == other.transform)
        {
            playerTouchingCountry = null;
        }
    }

    private void FixedUpdate()
    {
        myRigidBody.linearVelocity = movementDirection * movementSpeed;
    }




}
