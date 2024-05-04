using UnityEngine;

public class VoiceLineChestTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject chestObject; 

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (!audioSource.isPlaying)
        {
           
            audioSource.Play();
        }

        
        if (chestObject.GetComponent<BoxCollider>() != null && chestObject.GetComponent<BoxCollider>().enabled)
        {
            
            audioSource.Stop();
        }
    }
}