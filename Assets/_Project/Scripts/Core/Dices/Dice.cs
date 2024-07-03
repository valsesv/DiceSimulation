using UnityEngine;
using valsesv._Project.Scripts.Helpers;

namespace valsesv._Project.Scripts.Core.Dices
{
    public class Dice : MonoBehaviour
    {
        [SerializeField] private Transform startPosition;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private Vector3 forceFrom;
        [SerializeField] private Vector3 forceTo;
        [Space(10)]
        [SerializeField] private Vector3 rotationFrom;
        [SerializeField] private Vector3 rotationTo;

        public void Throw(int targetValue)
        {
            SetForce();
            SetRotation();
        }

        private void SetRotation()
        {
            transform.rotation = startPosition.rotation;
            rigidbody.angularVelocity = Vector3.zero;
            var targetTorque = MathUtilities.RandomVector(rotationFrom, rotationTo);
            rigidbody.AddTorque(targetTorque, ForceMode.Impulse);
        }

        private void SetForce()
        {
            transform.position = startPosition.position;
            rigidbody.velocity = Vector3.zero;
            var targetForce = MathUtilities.RandomVector(forceFrom, forceTo);
            rigidbody.AddForce(targetForce, ForceMode.Impulse);
        }
    }
}