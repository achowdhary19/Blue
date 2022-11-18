using UnityEngine;

namespace Scripts
{
    public interface IMovable
    {
        void Move(Vector3 move, bool locked);
    }
}
