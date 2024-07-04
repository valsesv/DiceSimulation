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

        public Vector3 TargetTorque { get;  set; }
        public Vector3 TargetForce { get;  set; }

        public void SetForces()
        {
            SetForce();
            SetRotation();
        }

        public void Throw()
        {
            rigidbody.AddTorque(TargetTorque, ForceMode.Impulse);
            rigidbody.AddForce(TargetForce, ForceMode.Impulse);
        }

        private void SetRotation()
        {
            transform.rotation = startPosition.rotation;
            rigidbody.angularVelocity = Vector3.zero;
            TargetTorque = MathUtilities.RandomVector(rotationFrom, rotationTo);
        }

        private void SetForce()
        {
            transform.position = startPosition.position;
            rigidbody.velocity = Vector3.zero;
            TargetForce = MathUtilities.RandomVector(forceFrom, forceTo);
        }
    }
}