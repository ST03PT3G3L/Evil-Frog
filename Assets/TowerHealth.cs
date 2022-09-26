using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] TextMeshProUGUI healthText;

    private void Start()
    {
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            health -= 1;
            healthText.text = health.ToString();
            Debug.Log("HIT!");
        }
    }
}
