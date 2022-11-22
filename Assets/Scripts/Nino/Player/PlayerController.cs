using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field:SerializeField]InputHandeler inputHandeler;
    [field: SerializeField] GroundChecker groundChecker;
    CharacterController cc;

    float VelocityY;
    [field: SerializeField] float moveSpeed;
    [field: SerializeField] float gravityForce;
    public bool isMoving;

    [field: SerializeField] float rotationLerpSpeed;
    
    void Start()
    {
        TryGetComponent<CharacterController>(out cc);
        VelocityY = 0;
        isMoving = false;
    }
    private void OnEnable()
    {
        inputHandeler.onMove.AddListener(MovePlayer);
    }
    private void OnDisable()
    {
        inputHandeler.onMove.RemoveListener(MovePlayer);
    }
    public void MovePlayer()
    {
        cc.Move(inputHandeler.moveDirection * moveSpeed * Time.fixedDeltaTime);
        lookForward();
    }
    private void FixedUpdate()
    {
        if (!groundChecker.onGround) VelocityY -= gravityForce * Time.fixedDeltaTime;
        else VelocityY = -gravityForce;

        cc.Move(new Vector3(0, VelocityY, 0));

        if (inputHandeler.moveDirection != Vector3.zero) isMoving = true;
        else isMoving = false;
    }
    private void lookForward()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(inputHandeler.moveDirection), rotationLerpSpeed * Time.fixedDeltaTime);
    }
}
