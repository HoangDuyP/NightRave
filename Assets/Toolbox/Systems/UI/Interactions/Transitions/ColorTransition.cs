using DG.Tweening;
using UnityEngine;

namespace UISystem
{
    public class ColorTransition : GraphicTransition
    {
        [SerializeField] Color activeColor = Color.white;
        [SerializeField] Color disabledColor = Color.gray;

        private Color inactiveColor;

        private new void Awake()
        {
            base.Awake();
            inactiveColor = graphic.color;
        }

        protected override void OnExit()
        {
            base.OnExit();
            graphic.DOKill();
            graphic.DOColor(inactiveColor, transitionDuration);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            graphic.DOKill();
            graphic.DOColor(activeColor, transitionDuration);
        }

        protected override void OnStatusChanged()
        {
            var color = interaction.Interactable ? interaction.Highlighted ? activeColor : inactiveColor : disabledColor;
            graphic.DOKill();
            graphic.DOColor(color, transitionDuration);
        }
    }
}
