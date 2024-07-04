using System.Collections.Generic;
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

        public void ThrowDices(IReadOnlyList<int> values)
        {
            dice1.SetForces();
            dice2.SetForces();
            RotateToCorrectAngle(values);
            dice1.Throw();
            dice2.Throw();
        }

        private void RotateToCorrectAngle(IReadOnlyList<int> values)
        {
            var simulationValues = simulation.GetSimulationValues(new[]{dice1, dice2});
            // foreach (var simulationValue in simulationValues)
            // {
            //     Debug.Log($"Dice value {simulationValue}");
            // }
            dice1.RotateValueFromTo(simulationValues[0], values[0]);
            dice2.RotateValueFromTo(simulationValues[1], values[1]);
        }
    }
}