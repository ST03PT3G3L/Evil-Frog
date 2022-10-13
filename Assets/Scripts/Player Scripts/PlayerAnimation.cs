using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    private PlayerAI player;

    private void Start()
    {
        player = GetComponentInParent<PlayerAI>();
    }

    private void Update()
    {
        if(player.state == PlayerAI.State.Walking ||
            player.state == PlayerAI.State.WalkingToEnemy)
        {
            animator.SetBool("IsWalking", true);
            return;
        }
        animator.SetBool("IsWalking", false);
    }
}
