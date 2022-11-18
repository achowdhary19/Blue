using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool onGround;
    [field: SerializeField] LayerMask NotPlayer;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        onGround = Physics.CheckSphere(transform.position, 0.1f, NotPlayer);
    }
}
