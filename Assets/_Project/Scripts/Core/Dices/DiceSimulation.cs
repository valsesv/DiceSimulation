using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace valsesv._Project.Scripts.Core.Dices
{
    [System.Serializable]
    public class DiceSimulation
    {
        [SerializeField] private Transform obstaclesParent;
        [SerializeField] private float simulationDuration = 5f;

        private List<Dice> _simulationDices = new();

        private Scene _simulationScene;
        private PhysicsScene _physicsScene;

        public void Init()
        {
            CreatePhysicsScene();
        }

        public int[] GetSimulationValues(Dice[] dices)
        {
            var result = new int[dices.Length];
            for (var i = 0; i < _simulationDices.Count; i++)
            {
                Object.Destroy(_simulationDices[i].gameObject);
            }
            _simulationDices.Clear();

            foreach (var dice in dices)
            {
                var simulationDice = CreateDiceInSimulation(dice);
                simulationDice.Throw();
                _simulationDices.Add(simulationDice);
            }

            RunSimulation();

            for (var i = 0; i < _simulationDices.Count; i++)
            {
                result[i] = _simulationDices[i].GetFaceValue();
            }

            return result;
        }

        private void RunSimulation()
        {
            var stepCount = simulationDuration / Time.fixedDeltaTime;
            for (var i = 0; i < stepCount; i++)
            {
                _physicsScene.Simulate(Time.fixedDeltaTime);
            }
            _physicsScene.Simulate(simulationDuration);
        }

        private void CreatePhysicsScene() {
            _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
            _physicsScene = _simulationScene.GetPhysicsScene();

            foreach (Transform obj in obstaclesParent) {
                var ghostObj = Object.Instantiate(obj.gameObject, obj.position, obj.rotation);
                ghostObj.GetComponent<Renderer>().enabled = false;
                SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);
            }
        }

        private Dice CreateDiceInSimulation(Dice targetDice)
        {
            var ghostObj = Object.Instantiate(targetDice, targetDice.transform.position, targetDice.transform.rotation);
            ghostObj.GetComponent<Renderer>().enabled = false;
            ghostObj.TargetForce = targetDice.TargetForce;
            ghostObj.TargetTorque = targetDice.TargetTorque;
            SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _simulationScene);
            return ghostObj;
        }
    }
}