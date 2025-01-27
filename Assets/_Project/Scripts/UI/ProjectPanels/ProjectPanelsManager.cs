using UnityEngine;
using valsesv._Project.Scripts.Interfaces;

namespace valsesv._Project.Scripts.UI.ProjectPanels
{
    public class ProjectPanelsManager : MonoBehaviour, IManager
    {
        [SerializeField] private ProjectPanelType projectPanelType;
        [SerializeField] private UiPanel[] panels;
        [SerializeField] private ConfirmPanel confirmPanel;

        public ConfirmPanel ConfirmPanel => confirmPanel;

        public void Init(){}

        public UiPanel OpenPanel(ProjectPanelType targetPanel)
        {
            var uiPanel = panels[(int)targetPanel];
            uiPanel.OpenPanel();
            return uiPanel;
        }
    }
}