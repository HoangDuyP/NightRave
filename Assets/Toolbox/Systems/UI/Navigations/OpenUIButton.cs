using UnityEngine;

namespace UISystem
{
    [RequireComponent(typeof(UIInteraction))]
    public class OpenUIButton : MonoBehaviour
    {
        [SerializeField] BaseUI target;
        private void Awake()
        {
            GetComponent<UIInteraction>().onSelect += OnClick;
        }

        private void OnClick()
        {
            UIController.Instance.Open(target);
        }
    }
}
