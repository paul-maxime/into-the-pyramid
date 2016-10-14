using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    
    public static GameManager GetInstance()
    {
        return _instance;
    }

    public bool IsDead { get; private set; }
    public List<AudioClip> Musics;
    public AudioClip DeathSound;
    public AudioClip UpgradeSound;

    private AudioSource _music;
    private AudioSource _sounds;

    private int _playingMusic = -1;

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (_instance != this)
        {
            _instance.PlayMusic(0);
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        var audioSources = GetComponents<AudioSource>();
        _music = audioSources[0];
        _sounds = audioSources[1];
        PlayMusic(0);
    }

    public void Die()
    {
        if (IsDead) return;

        IsDead = true;
        _sounds.PlayOneShot(DeathSound);

        RenderSettings.ambientIntensity = 0.2f;
        RenderSettings.ambientLight = Color.red;

        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            player.GetComponent<FirstPersonController>().CanMove = false;
            player.GetComponent<CharacterController>().height = 0.5f;
            player.GetComponent<MovingSpell>().enabled = false;
            player.GetComponent<DestructionSpell>().enabled = false;
            player.GetComponent<FlyingSpell>().enabled = false;
        }

        GameObject spotlight = GameObject.Find("Spotlight");
        if (spotlight != null)
        {
            Light light = spotlight.GetComponent<Light>();
            if (light != null)
            {
                light.enabled = false;
            }
        }

        StopMusic();
    }

    public void PlayUpgrade()
    {
        _sounds.PlayOneShot(UpgradeSound);
    }

    public void Update()
    {
        if (IsDead && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            IsDead = false;
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void PlayMusic(int index)
    {
        if (_playingMusic == index)
        {
            return;
        }
        _playingMusic = index;
        _music.Stop();
        _music.clip = Musics[index];
        _music.Play();
    }

    public void StopMusic()
    {
        _music.Stop();
        _playingMusic = -1;
    }
}
