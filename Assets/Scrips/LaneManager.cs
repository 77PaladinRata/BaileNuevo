using UnityEngine;

public class LaneManager : MonoBehaviour
{
    ///* Agregando Cosas
    [SerializeField]
    private string showAnimationName = "Show";
    [SerializeField]
     private string hideAnimationName = "Hide";
    ///* el anterior;
    [SerializeField]
    private Lane[] lanes;
    [SerializeField]
    private Animator animator;
    private bool isHidden = true;
    public Lane GetLane(int index)
    {
        if (index < 0 || index >= lanes.Length)
        {
            Debug. LogWarning("Lane index out of range: " + index);
            return lanes [0];
        }
        return lanes[index];
    } ///*     GetLane"s"Count
    public int GetLaneCount() ///* Quitar letra s
    {
        return lanes. Length;
    }
    ///* la nueva que pusimos
    public void ShowLanes()
    {
        animator.Play(showAnimationName);
        isHidden = false;
    }
    public void HideLanes()
    {
        if (isHidden) return;
        animator.Play(hideAnimationName);
        isHidden = true;
    }
}
