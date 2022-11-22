using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [field: SerializeField] Animator animator;
    [field: SerializeField] PlayerController playerController;
    [field: SerializeField] bool debug_Mode;
    void Start()
    {
        TryGetComponent<Animator>(out animator);
        TryGetComponent<PlayerController>(out playerController);
        debug_Mode = false;
    }

    private void FixedUpdate()
    {
        if (debug_Mode) return;
        if (playerController.isMoving && animator.GetInteger("State") != 1) animator.SetInteger("State", 1);
        if (!playerController.isMoving&& animator.GetInteger("State") != 0) animator.SetInteger("State", 0);
    }
}
