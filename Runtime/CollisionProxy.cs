using System;
using UnityEngine;

namespace UnityToolkit
{
    public class CollisionProxy : MonoBehaviour
    {
        public event Action<Collision> onCollisionEnter;
        public event Action<Collision> onCollisionStay;
        public event Action<Collision> onCollisionExit;

        public event Action<Collider> onTriggerEnter;
        public event Action<Collider> onTriggerStay;
        public event Action<Collider> onTriggerExit;

        private void OnCollisionEnter(Collision p_collision)
        {
            onCollisionEnter?.Invoke(p_collision);
        }

        private void OnCollisionStay(Collision p_collision)
        {
            onCollisionStay?.Invoke(p_collision);
        }

        private void OnCollisionExit(Collision p_collision)
        {
            onCollisionExit?.Invoke(p_collision);
        }

        private void OnTriggerEnter(Collider p_collider)
        {
            onTriggerEnter?.Invoke(p_collider);
        }

        private void OnTriggerStay(Collider p_collider)
        {
            onTriggerStay?.Invoke(p_collider);
        }

        private void OnTriggerExit(Collider p_collider)
        {
            onTriggerExit?.Invoke(p_collider);
        }
    }
}