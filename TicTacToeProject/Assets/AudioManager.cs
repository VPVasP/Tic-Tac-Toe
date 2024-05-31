using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource aud;
    [SerializeField] private AudioClip playerSoundEffect;
    [SerializeField] private AudioClip aiSoundEffect;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
        aud.playOnAwake = false;
        aud.loop = false;
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayPlayerSoundEffect()
    {
        aud.clip = playerSoundEffect;
        aud.Play();
    }
    public void PlayAISoundEffect()
    {
        aud.clip = aiSoundEffect;
        aud.Play();
    }
}
