using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToMouse : MonoBehaviour
{
    public KeyCode moveButton = KeyCode.Mouse1;
    public KeyCode moveButton2 = KeyCode.Mouse0;
    public Camera cam;

    [HideInInspector] public bool ableToMove = false;
    
    private Vector3 target;
    private PlayerAI player;






    void Start()
    {
        player = GetComponent<PlayerAI>();
        target = transform.position;
    }



    void Update()
    {
        if (ableToMove)
        {
            if (Input.GetKey(moveButton) || Input.GetKey(moveButton2) )
            {
                TowerUI myUI = GetComponent<TowerUI>();
                if(myUI != null) { myUI.ResetUI(); }

                ableToMove = false;

                target = cam.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;

                player.state = PlayerAI.State.Walking;
                player.originPos = target;

                if (target.x < transform.position.x && player.facingRight)
                {
                    player.Flip();
                }
                if (target.x > transform.position.x && !player.facingRight)
                {
                    player.Flip();
                }

            }
        }

        //Only walk to destination when commanded to
        if (player.state == PlayerAI.State.Walking)
        {
            Walk();
        }
    }




    public void Walk()
    {
        //Move to target
        player.MoveTo(target);

        //If the player reached the destination its state should not be "Walking"
        if (transform.position == target)
        {
            player.state = PlayerAI.State.Idle;
        }
    }



    public void EnableMovement()
    {
        ableToMove = !ableToMove;
    }
}
