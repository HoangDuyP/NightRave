using UnityEngine;

namespace UISystem
{
    public class UIAudio : GeneralAudio
    {
        [SerializeField] AudioClip navigateSound, selectSound, exitSound;

        private void Start()
        {
            var ui = UIController.Instance;
            ui.OnNavigated += () => Play(navigateSound);
            ui.OnSelected += () => Play(selectSound);
            ui.OnExitted += () => Play(exitSound);
        }
    }
}
