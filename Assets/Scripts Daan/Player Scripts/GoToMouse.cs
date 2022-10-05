using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMouse : MonoBehaviour
{
    public KeyCode moveButton = KeyCode.Mouse1;
    private Vector3 target;
    private PlayerAI player;

    void Start()
    {
        player = GetComponent<PlayerAI>();
        target = transform.position;
    }

    void Update()
    {
        //Check for input
        if (Input.GetKeyDown(moveButton))
        {
            //Set the move target
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            player.state = PlayerAI.State.Walking;
            player.originPos = target;
        }

        //Only walk to destination when commanded to
        if (player.state == PlayerAI.State.Walking)
        {
            //Move to target
            player.MoveTo(target);

            //If the player reached the destination its state should not be "Walking"
            if(transform.position == target)
            {
                player.state = PlayerAI.State.Idle;
            }
        }

    }
}
