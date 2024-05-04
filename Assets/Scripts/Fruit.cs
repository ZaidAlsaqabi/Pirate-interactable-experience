using UnityEngine;
using TMPro;
using System.Collections;

public class Fruit : MonoBehaviour
{
    public GameObject lid;
    public TextMeshPro text;
    public AudioSource audioSource; // Reference to the AudioSource component on the empty GameObject

    private bool isOpen = false;
    private bool isTextRevealed = false;

    void Start()
    {
      
        text.alpha = 0f;

        
        audioSource = GameObject.FindWithTag("SoundTrigger").GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the empty GameObject.");
        }
    }

    void Update()
    {
        
        if (!isOpen && lid.transform.rotation.eulerAngles.y > 90f)
        {
            isOpen = true;
           
            StartCoroutine(RevealText());
        }

       
        if (isTextRevealed && Input.GetKeyDown(KeyCode.E))
        {
           
            if (audioSource != null && !audioSource.isPlaying)
            {
                Debug.Log("Playing eat sound");
                audioSource.Play();
            }
            else
            {
                Debug.LogError("audioSource is null, or sound is already playing!");
            }

            
            gameObject.SetActive(false);
          
            text.alpha = 0f;
        }
    }

    IEnumerator RevealText()
    {
    
        while (text.alpha < 1f)
        {
            text.alpha += Time.deltaTime;
            yield return null;
        }
        isTextRevealed = true;
    }
}
