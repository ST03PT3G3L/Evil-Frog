using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void DamageTaken();
    public static event DamageTaken OnDamageTaken;

    public delegate void Buy();
    public static event Buy OnBuy;

    public static void DamageTakenEvent()
    {
        if(OnDamageTaken != null)
        {
            OnDamageTaken();
        }
    }

    public static void BuyEvent()
    {
        if (OnDamageTaken != null)
        {
            OnBuy();
        }
    }
}
