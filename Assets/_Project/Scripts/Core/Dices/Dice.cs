using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
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
        [Space(10)]
        [SerializeField] private Transform[] sides;

        [NonSerialized] public Vector3 TargetTorque;
        [NonSerialized] public Vector3 TargetForce;

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

        public int GetFaceValue()
        {
            var faceValue = 1;
            var topHeight = -1e9f;
            for (var i = 0; i < sides.Length; i++)
            {
                var sideHeight = sides[i].position.y;
                if (sideHeight < topHeight)
                {
                    continue;
                }
                faceValue = i + 1;
                topHeight = sideHeight;
            }

            return faceValue;
        }

        public void RotateValueFromTo(int valueFrom, int valueTo)
        {
            var targetUp = sides[valueFrom - 1].position - transform.position;
            var currentUp = sides[valueTo - 1].position - transform.position;
            var rotation = Quaternion.FromToRotation(currentUp, targetUp);
            transform.rotation = rotation * transform.rotation;
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