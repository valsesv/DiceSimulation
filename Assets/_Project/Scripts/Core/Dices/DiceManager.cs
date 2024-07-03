using UnityEngine;

namespace valsesv._Project.Scripts.Core.Dices
{
    public class DiceManager : MonoBehaviour
    {
        [SerializeField] private Dice dice1;
        [SerializeField] private Dice dice2;
        public bool IsThrowingEnabled { get; private set; }

        private void Start()
        {
            InitDices();
        }

        public void ThrowDices(int value1, int value2)
        {
            dice1.Throw(value1);
            dice2.Throw(value2);
        }

        private void InitDices()
        {
            IsThrowingEnabled = true;
        }
    }
}