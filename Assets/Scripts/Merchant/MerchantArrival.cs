using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantArrival : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private Canvas merchantUI;
    private ManageUI manager;
    private Animator animator;

    private void Start()
    {
        merchantUI = GameObject.Find("Merchant").GetComponentInChildren<Canvas>();
        manager = GameObject.Find("UI Manager").GetComponent<ManageUI>();
        animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        manager.ActivateUI(merchantUI);
    }

    private void Update()
    {
        if(transform.position != endPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("done", true);
        }
    }
}
