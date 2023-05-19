using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoolInstantiate : MonoBehaviour
{
    [SerializeField] List<GameObject> itemPool_;
    void Start()
    {
        ItemPool.itemPool = itemPool_;
    }
}
