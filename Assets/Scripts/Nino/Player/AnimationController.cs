using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [field: SerializeField] Animator animator;
    [field: SerializeField] PlayerController playerController;
    [field: SerializeField] InputHandeler input;
    void Start()
    {
        TryGetComponent<Animator>(out animator);
        TryGetComponent<PlayerController>(out playerController);
    }

    private void FixedUpdate()
    {
        if (playerController.isMoving && animator.GetInteger("State") != 1) animator.SetInteger("State", 1);
        if (!playerController.isMoving&& animator.GetInteger("State") != 0) animator.SetInteger("State", 0);
    }
}
