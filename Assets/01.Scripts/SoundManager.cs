using UnityEngine;


public enum SFXType
{
    ArrowAttack,
    BulletAttack,
    MonsterHit,

    GetItem,
    MonsterDie,
    PlayerHit 
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;


    [SerializeField] AudioSource bgmAudioSurce;
    [SerializeField] AudioSource sfxAudioSource;

    public AudioClip bgmClip; //배경음
    public AudioClip[] soundClip; //효과음

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        PlayBgm();
    }

    private void PlayBgm()
    {
        bgmAudioSurce.Play();
    }

    public void PlaySFX(SFXType type)
    {
        if ((int)type > soundClip.Length)
            return;


        sfxAudioSource.PlayOneShot(soundClip[(int)type]);
    }


    

    
}
