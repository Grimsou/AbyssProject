using UnityEngine;

public class MainMusicTheme : MonoBehaviour
{
    [SerializeField] private AudioSource _mainMusic;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _isPlaying = false;

        DestroyAudiosource();
    }

    private void Update()
    {
        if (!_isPlaying)
        {
            PlayMusic();
        }
    }

    private void PlayMusic()
    {
        _mainMusic.Play();
        _isPlaying = true;
    }

    private void DestroyAudiosource()
    {
        if(FindObjectsOfType<AudioSource>().Length > 2)
        {
            Destroy(FindObjectsOfType<AudioSource>()[1]);
        }
    }

    private bool _isPlaying;
}


