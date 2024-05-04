using UnityEngine;
using TMPro;

public class chest : MonoBehaviour
{
    public Animator Openchest;
    public AudioClip openSound;
    public GameObject closed;
    public BoxCollider chestCollider; 
    public TextMeshPro chestText; 
    public float interactionRange = 3f; 
    private bool soundPlayed = false;
    private AudioSource audioSource;
    private bool audioPlaying = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
  
        if (audioPlaying)
        {
            chestText.gameObject.SetActive(false);
            return; 
        }

    
        if (PlayerIsNearby() && chestCollider.enabled)
        {
            chestText.gameObject.SetActive(true);
            chestText.text = "Press 'F' to open chest";
        }
      
        else if (PlayerIsNearby() && !chestCollider.enabled)
        {
            chestText.gameObject.SetActive(true);
            chestText.text = "Chest is locked";
        }
        else
        {
            chestText.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
    
        if (Input.GetKey(KeyCode.F) && PlayerIsNearby())
        {
     
            if (chestCollider.enabled)
            {
                Openchest.Play("Openchest");

             
                if (openSound != null && !soundPlayed)
                {
              
                    audioSource.clip = openSound;
                    audioSource.Play();

                    
                    soundPlayed = true;
                    audioPlaying = true; 
                }
            }
            else
            {
                
            }
        }
    }

    bool PlayerIsNearby()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return Vector3.Distance(transform.position, player.transform.position) <= interactionRange;
        }
        return false;
    }
}