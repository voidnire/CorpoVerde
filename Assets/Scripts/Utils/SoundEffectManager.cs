using UnityEngine;
using System.Collections.Generic;

public class SoundEffectManager : MonoBehaviour
{
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

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }

}
