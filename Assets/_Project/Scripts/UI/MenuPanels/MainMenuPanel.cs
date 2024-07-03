using UnityEngine;
using UnityEngine.UI;

namespace valsesv._Project.Scripts.UI.MenuPanels
{
    public class MainMenuPanel : UiPanel
    {
        [SerializeField] private Button playButton;

        protected override void Start()
        {
            base.Start();
            playButton.onClick.AddListener(() =>
            {
            });
        }
    }
}