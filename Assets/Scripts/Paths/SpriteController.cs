using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    GameObject sprite;

    private void Start()
    {
    }
    public void ChangeSprite(GameObject newSprite)
    {
        foreach (Transform transform in gameObject.transform)
        {
            if (transform.tag == "Sprite")
            {
                sprite = transform.gameObject;
                //break;
            }
        }

        Debug.Log(newSprite);
        float posx = sprite.transform.position.x;
        float posy = sprite.transform.position.y;

        Instantiate(newSprite, new Vector3(posx, posy), sprite.transform.rotation, gameObject.transform);
        Destroy(sprite);
    }
}
