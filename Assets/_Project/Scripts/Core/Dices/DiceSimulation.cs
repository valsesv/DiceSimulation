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

        private List<GameObject> _simulationDices = new();

        private Scene _simulationScene;
        private PhysicsScene _physicsScene;

        public void Init()
        {
            CreatePhysicsScene();
        }

        public Vector3[] GetSimulationAngles(Dice[] dices)
        {
            var result = new Vector3[dices.Length];
            _simulationDices.Clear();

            foreach (var dice in dices)
            {
                var simulationDice = CreateDiceInSimulation(dice);
                simulationDice.Throw();
                _simulationDices.Add(simulationDice.gameObject);
            }

            for (int i = 0; i < simulationDuration / Time.fixedDeltaTime / 2; i++)
            {
                _physicsScene.Simulate(Time.fixedDeltaTime);
            }

            for (var i = 0; i < _simulationDices.Count; i++)
            {
                result[i] = _simulationDices[i].transform.rotation.eulerAngles;
                Object.Destroy(_simulationDices[i]);
            }

            return result;
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