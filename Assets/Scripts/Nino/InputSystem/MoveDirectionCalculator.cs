using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class MoveDirectionCalculator : MonoBehaviour
{
    InputHandeler inputHandeler;
    [field: SerializeField] public GameObject cam;

    void Start()
    {
        TryGetComponent<InputHandeler>(out inputHandeler);
        if(inputHandeler == null) throw new System.Exception("Can't find InputHandeler");
    }
    public void UpdateCam( GameObject obj)
    {
        cam = obj;
    }

    public void TrySetMove()
    {
        inputHandeler.moveDirection = ScreenToMove();
    }
    public Vector3 ScreenToMove()
    {
        if (cam == null) return Vector3.zero;
        Vector3 CameraF = cam.transform.forward;
        Vector3 CameraR = cam.transform.right;
        Vector3 move = CameraF * inputHandeler.moveInput.y + CameraR * inputHandeler.moveInput.x;
        move.y = 0;
        move.Normalize();
        return move;
    }
}
