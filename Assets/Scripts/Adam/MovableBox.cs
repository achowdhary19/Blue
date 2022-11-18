using System;
using Scripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts
{
    public class MovableBox : MonoBehaviour, IMovable
    {
        [SerializeField] private float step = 0.1f;
        private Rigidbody rb;
        private void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }

        public void Move(Vector3 move, bool locked)
        {
            if (locked) return;
            Vector3 target = transform.position + move;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
}