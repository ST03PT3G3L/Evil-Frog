using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] MapExpanding map;
    [SerializeField] float screenSize;
    [SerializeField] float speed = 1;
    [SerializeField] KeyCode upKey = KeyCode.W;
    [SerializeField] KeyCode downKey = KeyCode.S;
    [SerializeField] KeyCode upKey2 = KeyCode.UpArrow;
    [SerializeField] KeyCode downKey2 = KeyCode.DownArrow;

    [SerializeField] bool devMode = true;
    [SerializeField] KeyCode leftKey = KeyCode.A; //Dev
    [SerializeField] KeyCode rightKey = KeyCode.D; //Dev


    void Update()
    {
        if (map != null && !devMode)
        {
            if ((transform.position.y < map.levelsUnlocked * -screenSize && Input.GetKey(downKey)) ||
                (transform.position.y > -0.1 && Input.GetKey(upKey)))
            {
                return;
            }

            if (map.levelsUnlocked == 0)
            {
                return;
            }
        }
        moveCam();
    }

    public void moveCam()
    {
        if (Input.GetKey(rightKey) && devMode)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(leftKey) && devMode)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(downKey) || Input.GetKey(downKey2))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(upKey) || Input.GetKey(upKey2))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }
}