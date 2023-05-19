using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCollision : MonoBehaviour
{
    [SerializeField] bool right;
    [SerializeField] bool up;
    [SerializeField] bool left;
    [SerializeField] bool down;

    [Header("Sprites")]
    [SerializeField] GameObject Right;
    [SerializeField] GameObject RightUp;
    [SerializeField] GameObject Left;
    [SerializeField] GameObject LeftUp;
    [SerializeField] GameObject Up;
    [SerializeField] GameObject Side;

    [SerializeField] SpriteController spriteController;
    DragDrop dragdrop;
    [SerializeField] List<GameObject> collisions = new List<GameObject>();

    private void Start() {
        dragdrop = gameObject.GetComponent<DragDrop>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Path" || collision.gameObject.tag == "Lair")
            {
                if(collision.gameObject != gameObject.transform.parent)
                {
                    collisions.Add(collision.gameObject);
                    CheckCollisions();
                }
            }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision);
        collisions.Remove(collision.gameObject);
        CheckCollisions();
    }

    public void CheckCollisions()
    {
        CheckMyCollisions();
        CheckOtherCollisions();
    }

    private void CheckOtherCollisions()
    {
        foreach(GameObject col in collisions)
        {
            PathCollision pathCollision = col.GetComponent<PathCollision>();
            if(pathCollision != null)
            {
                pathCollision.CheckMyCollisions();
            }
        }
    }

    public void CheckMyCollisions()
    {
        left = false;
        right = false;
        up = false;
        down = false;
        foreach (GameObject col in collisions)
        {
            if (col.transform.position.x > transform.position.x)
            {
                right = true;
            }
            if (col.transform.position.x < transform.position.x)
            {
                left = true;
            }
            if (col.transform.position.y > transform.position.y)
            {
                up = true;
            }
            if (col.transform.position.y < transform.position.y)
            {
                down = true;
            }
        }
        ChangePath();
    }

    private void ChangePath()
    {
        PathScript pathScript = GetComponentInParent<PathScript>();

        if(right && down && !up && !left)
        {
            spriteController.ChangeSprite(Right);
            pathScript.direction = Directions.Right;
        }
        if(left && down && !up && !right)
        {
            spriteController.ChangeSprite(Left);
            pathScript.direction = Directions.Left;
        }
        if(left && up && !down && !right)
        {
            spriteController.ChangeSprite(LeftUp);
            pathScript.direction = Directions.Up;
        }
        if(right && up && !down && !left)
        {
            spriteController.ChangeSprite(RightUp);
            pathScript.direction = Directions.Up;
        }
        if (up && !left && !right)
        {
            spriteController.ChangeSprite(Up);
            pathScript.direction = Directions.Straight;
        }
        if (down && !left && !right)
        {
            spriteController.ChangeSprite(Up);
            pathScript.direction = Directions.Straight;
        }

        if(left && !down && !up && !right)
        {
            spriteController.ChangeSprite(Side);
            pathScript.direction = Directions.Straight;
        }
        if (right && !down && !up && !left)
        {
            spriteController.ChangeSprite(Side);
            pathScript.direction = Directions.Straight;
        }
    }
}
