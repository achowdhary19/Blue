using Unity.VisualScripting;
using UnityEngine;

namespace Scripts
{
    public class MovableBox : MonoBehaviour, IMovable
    {
        [SerializeField] private float step = 0.1f;
        public void Move(Vector3 move)
        {
            Vector3 target = transform.position + move;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
}