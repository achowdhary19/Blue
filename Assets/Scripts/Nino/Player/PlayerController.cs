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
    
    void Start()
    {
        TryGetComponent<CharacterController>(out cc);
        VelocityY = 0;
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
    }
    private void FixedUpdate()
    {
        if (!groundChecker.onGround) VelocityY -= gravityForce * Time.fixedDeltaTime;
        else VelocityY = -gravityForce;

        cc.Move(new Vector3(0, VelocityY, 0));
    }
}
