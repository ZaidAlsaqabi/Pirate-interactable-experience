using UnityEngine;
using TMPro;

public class Drinking : MonoBehaviour
{
    public GameObject water;
    public GameObject drink;
    public AudioClip drinkSound;
    public AudioClip waterSound;
    public TextMeshPro interactionText;

    private bool isNearWater = false;
    private bool isNearDrink = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            InteractWithObjects();
        }

        if (water != null)
        {
            isNearWater = Vector3.Distance(transform.position, water.transform.position) < 2f;
        }
        if (drink != null)
        {
            isNearDrink = Vector3.Distance(transform.position, drink.transform.position) < 2f;
        }

        if (interactionText != null)
        {
            if (isNearWater || isNearDrink)
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Press F to interact";
            }
            else
            {
                interactionText.gameObject.SetActive(false);
            }
        }
    }

    void InteractWithObjects()
    {
        if (water != null && isNearWater)
        {
            water.SetActive(false);
            if (waterSound != null)
            {
                AudioSource.PlayClipAtPoint(waterSound, transform.position);
            }
            if (interactionText != null)
            {
                Destroy(interactionText.gameObject);
            }
        }


        if (drink != null && isNearDrink)
        {
            drink.SetActive(false);
            if (drinkSound != null)
            {
                AudioSource.PlayClipAtPoint(drinkSound, transform.position);
            }
            if (interactionText != null)
            {
                Destroy(interactionText.gameObject);
            }
        }
    }
}