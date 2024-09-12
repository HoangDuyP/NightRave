using DG.Tweening;
using UISystem;
using UnityEngine;

public class ScaleTransition : UITransition
{
    [SerializeField] float scaleOnEnter = 1.2f;

    protected override void OnEnter()
    {
        base.OnEnter();
        transform.DOKill();
        transform.DOScale(scaleOnEnter, transitionDuration);
    }

    protected override void OnExit()
    {
        base.OnExit();
        transform.DOKill();
        transform.DOScale(1, transitionDuration);
    }
}
