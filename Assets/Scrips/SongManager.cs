using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SongManager : MonoBehaviour
{
    [SerializeField]
    private Animator characterAnimator;
    [SerializeField]
    private UnityEvent onSongStart;
    ///* nuevoa
    [SerializeField]
    private UnityEvent onSongSelected;
    [SerializeField]
    private UnityEvent onSongEnd;
    [SerializeField]
    private NotesManager notesManager; ///*nuevo
    [SerializeField]
    private string failAnimationName = "Hit"; ///*Nuevo
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
        ///*Nuevo
        notesManager.StartNoteChart(currentSongData.noteChart, currentSongData. speed);
        onSongStart ?. Invoke();
    }
    ///*Notas de Caer
    public void Fail()
    {
        StopAllCoroutines(); ///*Para la Nota
        StartCoroutine(FailCoroutine());
    }
    private IEnumerator FailCoroutine()
    {
        characterAnimator.Play(failAnimationName, 0, 0f);
        yield return null;
        yield return new WaitForSeconds(characterAnimator.GetCurrentAnimatorStateInfo(0).length);
        characterAnimator.Play(currentSongData.animationName, 0, 0f);
    }
    public void WinSong()
    {
        StopAllCoroutines();
        characterAnimator.Play("Win", 0, 0f);
    }
    public void LoseSong()
    {
        StopAllCoroutines();
        characterAnimator.Play("Lose", 0, 0f);
    }
}