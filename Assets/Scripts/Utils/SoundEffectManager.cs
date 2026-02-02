using UnityEngine;
using System.Collections.Generic;

public class SoundEffectManager : MonoBehaviour
{

    public static SoundEffectManager Instance;

    [Header("-----------Audio Sources---------- -")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----------Audiozinhos---------- -")]
    public AudioClip background;
    public AudioClip grr1;
    public AudioClip grr2;
    public AudioClip grr3;
    public AudioClip grr4;
    public AudioClip passo1;
    public AudioClip passo2;
    public AudioClip passo3;
    public AudioClip passo4;
    public AudioClip soco1molhado;
    public AudioClip soco2seco;
    public AudioClip throwknife;
    public AudioClip ventosoco;
    
    public AudioClip glubglub;
    public AudioClip morto1;
    public AudioClip morto2;
    public AudioClip morto3;
    public AudioClip morto4;
    public AudioClip pop;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
