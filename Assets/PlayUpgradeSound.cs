using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUpgradeSound : MonoBehaviour
{
    [SerializeField] AudioSource upgradeSource;

    public void upgradeSound()
    {
        upgradeSource.Play();
    }
}
