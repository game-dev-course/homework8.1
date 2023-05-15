using System.Collections;
using UnityEngine;
using TMPro;

public class DisplayHello : MonoBehaviour
{
    public TextMeshProUGUI helloText; // Assign your TextMeshPro in the Inspector

    private bool isPlayerInside = false;

    private void Start()
    {
        helloText.gameObject.SetActive(false); // Hide text at the start
    }

    private void Update()
    {
        // If player is inside the trigger and presses the E key
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            helloText.gameObject.SetActive(true); // Show text
            StartCoroutine(ChangeText()); // Start changing text
        }
    }

    private IEnumerator ChangeText()
    {
        helloText.text = "Hello";
        yield return new WaitForSeconds(2);
        helloText.text = "Welcome to my world";
        yield return new WaitForSeconds(2);
        helloText.text = "Enjoy :)";
        yield return new WaitForSeconds(2);
        helloText.gameObject.SetActive(false); // Hide text after displaying
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered the event is player
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object that left the trigger is player
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
            helloText.gameObject.SetActive(false); // Hide text
        }
    }
}