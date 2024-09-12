using UnityEngine;

namespace UISystem
{
    public abstract class UITransition : MonoBehaviour
    {
        [SerializeField] protected UIInteraction interaction;
        [SerializeField] protected float transitionDuration = .2f;

        protected void Reset() => interaction = GetComponentInParent<UIInteraction>();

        protected void Awake()
        {
            var s = GetComponent<INavigatable>();
            interaction.onEnter += OnEnter;
            interaction.onExit += OnExit;
            interaction.onStatusChanged += OnStatusChanged;
        }

        protected virtual void OnExit() { }

        protected virtual void OnEnter() { }

        protected virtual void OnStatusChanged() { }
    }
}
