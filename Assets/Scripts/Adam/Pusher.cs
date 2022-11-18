using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    private Vector3 move;
    private bool locked;

    private void OnTriggerStay(Collider other)
    {
        IMovable imovable = other.gameObject.GetComponent<IMovable>();
        if (imovable != null)
        {
            move = ClosestCardinalDirection(other.gameObject.transform.position - transform.position);
            imovable.Move(move, locked);
        }
    }

    public Vector3 ClosestCardinalDirection(Vector3 inDirection)
    {
        Vector3 outDirection = new Vector3(0,0,0);
        inDirection = inDirection.normalized;

        float closestDistance = -Mathf.Infinity;
        float dotProduct = 0;

        dotProduct = Vector3.Dot(inDirection, Vector3.forward);
        if (dotProduct > closestDistance)
        {
            closestDistance = dotProduct;
            outDirection = Vector3.forward;
        }
        
        dotProduct = Vector3.Dot(inDirection, Vector3.back);
        if (dotProduct > closestDistance)
        {
            closestDistance = dotProduct;
            outDirection = Vector3.back;
        }
        
        dotProduct = Vector3.Dot(inDirection, Vector3.left);
        if (dotProduct > closestDistance)
        {
            closestDistance = dotProduct;
            outDirection = Vector3.left;
        }
        
        dotProduct = Vector3.Dot(inDirection, Vector3.right);
        if (dotProduct > closestDistance)
        {
            closestDistance = dotProduct;
            outDirection = Vector3.right;
        }

        return outDirection;
    }
}
