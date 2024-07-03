using UnityEngine;
using UnityEngine.UI;
using valsesv._Project.Scripts.UI.ProjectPanels;
using Zenject;

namespace valsesv._Project.Scripts.UI.Buttons
{
    public class ProjectPanelButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ProjectPanelType projectPanelType;
        [Space(10)]
        [SerializeField] private CanvasGroup uiToHide;

        [Inject] private ProjectPanelsManager _projectPanelsManager;

        private void Start()
        {
            button.onClick.AddListener(OpenPanel);
        }

        private void OpenPanel()
        {
            ShowCurrentUi(false);

            _projectPanelsManager.OpenPanel(projectPanelType).OnClosed += () =>
            {
                ShowCurrentUi(true);
            };
        }

        private void ShowCurrentUi(bool isShown)
        {
            if (uiToHide == null)
            {
                return;
            }

            CanvasSwapper.CanvasGroupSwap(uiToHide, isShown);
        }
    }
}