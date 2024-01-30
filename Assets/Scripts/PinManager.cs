using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinManager : MonoBehaviour
{
    private GameObject[] allPins;
    private int pinsAmount;
    List<GameObject> pinsToRemove;
    private SceneLoader sceneLoader;
    private float delayInSeconds = 8f;
    private bool isDestroying = false;
    private ShootByArrowDirection shootByArrowDirection;
    private int fallenPinsFirstShot = 0;
    private int fallenPinsSecondShot = 0;

    void Start()
    {
        // initialize variables
        allPins = GameObject.FindGameObjectsWithTag("Pin");
        pinsAmount = allPins.Length;
        pinsToRemove = new List<GameObject>();
        sceneLoader = GameObject.FindGameObjectWithTag("Ball").GetComponent<SceneLoader>();
        shootByArrowDirection = GameObject.FindGameObjectWithTag("Ball").GetComponent<ShootByArrowDirection>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDestroying) // if the space button is pressed and the destroying process has not started yet
        {
            StartCoroutine(DestroyFallenPins()); // Destroy fallen pins
        }
    }

    private IEnumerator DestroyFallenPins()
    {
        isDestroying = true;
        yield return new WaitForSeconds(delayInSeconds); // Wait a few seconds for the falling animation
        pinsToRemove.Clear();
        foreach (var pin in allPins)
        {
            if (pin != null)
            {
                Pin pinScript = pin.GetComponent<Pin>();
                //check whether the pin has fallen
                if (pinScript != null && pinScript.IsFall()) // if the pin is mark as fall
                {
                    pinsToRemove.Add(pin);
                }
            }
        }
        if (shootByArrowDirection.GetShotsCount() < 2) // first shot indicator
        {
            fallenPinsFirstShot = pinsToRemove.Count;
        }
        else
        {
            fallenPinsSecondShot = pinsToRemove.Count; 
        }
        foreach (var pinToremove in pinsToRemove) // Destroy the fallen pins
        {
            Destroy(pinToremove);
        }
        isDestroying = false;
        if (shootByArrowDirection.GetShotsCount() == 2 || fallenPinsFirstShot == pinsAmount) // checking how much pins are falling after 2 shots
        {
            if (fallenPinsFirstShot + fallenPinsSecondShot == pinsAmount) // if all the pins are fell, load the next level.
            {
                sceneLoader.LoadNewScene();
            }
            else
            {
                ResetGame(); // else reset the currnt level
            }
        }
    }

    public GameObject[] GetPins()
    {
        return allPins;
    }

    public List<GameObject> GetPinsToRemove()
    {
        return pinsToRemove;
    }

    private static void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
