using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Animator animator;
    private bool isShowing = false;
    public void ShowWinScreen(string score)
    {
        titleText. text = "You Win!";
        ShowScreen(score);
    }
    public void ShowLoseScreen(string score)
    {
        titleText.text = "You Lose!";
        ShowScreen(score);
    }
    private void ShowScreen(string score)
    {
        scoreText.text = score;
        animator.Play("Show");
        isShowing = true;
    }
    public void HideScreen()
    {
        if (isShowing)
        {
            animator.Play("Hide");
            isShowing = false;
        }
    }
}
