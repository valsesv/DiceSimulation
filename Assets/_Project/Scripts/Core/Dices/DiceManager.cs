using UnityEngine;

namespace valsesv._Project.Scripts.Core.Dices
{
    public class DiceManager : MonoBehaviour
    {
        [SerializeField] private DiceSimulation simulation;
        [Space(10)]
        [SerializeField] private Dice dice1;
        [SerializeField] private Dice dice2;
        public bool IsThrowingEnabled { get; private set; }

        private void Start()
        {
            simulation.Init();
            IsThrowingEnabled = true;
        }

        public void ThrowDices(int value1, int value2)
        {
            dice1.SetForces();
            dice2.SetForces();
            SimulateThrows();
            dice1.Throw();
            dice2.Throw();
        }

        private void SimulateThrows()
        {
            var angles = simulation.GetSimulationAngles(new[]{dice1, dice2});
            foreach (var angle in angles)
            {
                Debug.Log($"Dice angle {angle}");
            }
        }
    }
}