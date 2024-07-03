using TMPro;
using UnityEngine;
using UnityEngine.UI;
using valsesv._Project.Scripts.Core.Dices;
using Zenject;

namespace valsesv._Project.Scripts.UI.MenuPanels
{
    public class MainGamePanel : UiPanel
    {
        [SerializeField] private Button throwButton;
        [SerializeField] private TMP_Dropdown dice1Dropdown;
        [SerializeField] private TMP_Dropdown dice2Dropdown;

        [Inject] private DiceManager _diceManager;

        protected override void Start()
        {
            base.Start();
            throwButton.onClick.AddListener(ThrowDices);
        }

        private void ThrowDices()
        {
            _diceManager.ThrowDices(dice1Dropdown.value, dice2Dropdown.value);
        }

        private void TryEnableThrowing() => throwButton.enabled = _diceManager.IsThrowingEnabled;
    }
}