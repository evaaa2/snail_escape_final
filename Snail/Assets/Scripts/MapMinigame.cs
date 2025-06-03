using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MapMinigame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidBody;
    public float movementSpeed = 10f;
    private Vector2 movementDirection;
    public TextMeshProUGUI currentCountry;
    public string currentCountryName;
    public GameObject[] countries;

    void Start()
    {
        PickNewCountry();
    }
    public void PickNewCountry()
    {
        int index = Random.Range(0, countries.Length);
        currentCountryName = countries[index].name;
        currentCountry.text = currentCountryName;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = UnityEngine.Input.GetAxisRaw("Horizontal");
        float inputY = UnityEngine.Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
        if (movementDirection.y > 0) //otaceni sneka kdyz leze do leva/do prava
        {
            transform.localScale = new Vector3(1, 1, 1); //nasobim tim direction multiplier aby se otacel spravne i kdyz je na strope

        }
        else if (movementDirection.y < 0)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        if (movementDirection.x > 0) //otaceni sneka kdyz leze do leva/doprava
        {
            transform.localScale = new Vector3(1, 1, 1); //nasobim tim direction multiplier aby se otacel spravne i kdyz je na strope

        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Country"))
        {
            string touchedCountry = other.gameObject.name;

            if (touchedCountry == currentCountryName)
            {
                Debug.Log("✅ Correct! You found " + touchedCountry);
                PickNewCountry();
            }
            else
            {
                Debug.Log("❌ Wrong. That was " + touchedCountry);
            }
        }
    }
    private void FixedUpdate()
    {
        myRigidBody.linearVelocity = movementDirection * movementSpeed;
    }




}
