using UnityEngine;
using UnityEngine.Events;

public class SongManager : MonoBehaviour
{
    [SerializeField]
    private Animator characterAnimator;
    [SerializeField]
    private UnityEvent onSongStart;
    ///* nuevo
    [SerializeField]
    private UnityEvent onSongSelected;
    [SerializeField]
    private UnityEvent onSongEnd;
    ///* Nuevo
    private SongData currentSongData;
            ///*PlaySing
    public void SelectSong(SongData songData)
    {   ///* Estas si
        currentSongData = songData;
        onSongSelected ?. Invoke();
        ///* Estas no
        ///* characterAnimator.Play(songData.animationName);
        ///* SoundManager.instance.PlayMusic(songData.songName);
        ///* onSongStart?.Invoke();
    }
    public void StopSong()
    {
        SoundManager.instance.StopMusic();
        onSongEnd?.Invoke();
    }
    ///* nuevo
    public void StartSong()
    {
        characterAnimator.Play(currentSongData.animationName);
        SoundManager.instance.PlayMusic(currentSongData.songName);
        onSongStart ?. Invoke();
    }
}