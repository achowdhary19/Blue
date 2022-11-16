using System;
using UnityEngine;

namespace Scripts
{
    public class PlayerLifeController : MonoBehaviour
    {
        public bool inLight = true;
        private void FixedUpdate()
        {
            if (inLight)
            {
                Debug.Log("Player in light");
            }
            else
            {
                Debug.Log("Player dead");
            }

            inLight = false;
        }
    }
}