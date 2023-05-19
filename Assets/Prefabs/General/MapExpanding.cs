using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapExpanding : MonoBehaviour
{
    public float levelsUnlocked = 0;
    public float howManyLevelsForOneExpansion = 5;

    [SerializeField] int unitsDown = 6;
    [SerializeField] Transform spawner;
    [SerializeField] GameObject path;
    [SerializeField] Transform parentObject;

    [SerializeField] public GameObject info;

    private void Start()
    {
        //placePaths();
        //moveSpawnerDown();
    }

    public void Expand(float round)
    {
        if(round % howManyLevelsForOneExpansion == 0)
        {
            levelsUnlocked++;
            placePaths();
            moveSpawnerDown();
            info.SetActive(true);
        }
    }

    public void moveSpawnerDown()
    {
        spawner.Translate(new Vector3(0, 4 * -unitsDown, 0));
    }

    public void placePaths()
    {
        for (int i = 0; i < unitsDown; i++)
        {
            Instantiate(path, new Vector3(
                spawner.position.x, spawner.position.y - (4 * i) ,spawner.position.z), Quaternion.identity, parentObject);
        }
    }
}
