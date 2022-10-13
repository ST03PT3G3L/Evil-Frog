using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour
{
    private enum TargetOption
    {
        First,
        Last,
        Close
    }

    [SerializeField] TargetOption targetOption;

    public GameObject GetEnemy(float walkRange, Vector2 playerPos)
    {

        switch (targetOption)
        {
            case TargetOption.First: return GetFirstEnemy(walkRange, playerPos);
            case TargetOption.Last: return GetLastEnemy(walkRange, playerPos);
            case TargetOption.Close: return GetNearestEnemy();
            default: return GetFirstEnemy(walkRange, playerPos);
        }
    }
    public GameObject GetNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }

    public GameObject GetFirstEnemy(float walkRange, Vector2 playerPos)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float highestDistance = -1;
        GameObject firstEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = enemy.GetComponent<Enemy>().distanceToEnd;
            if (distance > highestDistance && enemyIsInRange(enemy, walkRange, playerPos))
            {
                highestDistance = distance;
                firstEnemy = enemy;
            }
        }
        return firstEnemy;
    }

    public GameObject GetLastEnemy(float walkRange, Vector2 playerPos)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject lastEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = enemy.GetComponent<Enemy>().distanceToEnd;

            if (distance < shortestDistance && enemyIsInRange(enemy, walkRange, playerPos))
            {
                shortestDistance = distance;
                lastEnemy = enemy;
            }
        }

        if(lastEnemy != null)
        {
            return lastEnemy;
        }
        return null;
    }


    public bool enemyIsInRange(GameObject target, float range, Vector2 playerPos)
    {

        if(Vector2.Distance(playerPos, target.transform.position) < range)
        {
            return true;
        }
        //Debug.Log(Vector2.Distance(playerPos, target.transform.position) + " " + range);
        return false;
    }


    public PlayerAI.State getState(GameObject target, float walkRange, float attackRange, Vector2 playerPos, Vector2 originPos)
    {
        if (target != null)
        {
            if (enemyIsInRange(target, walkRange, originPos))
            {
                if (enemyIsInRange(target, attackRange, playerPos))
                {
                    return PlayerAI.State.Attacking;
                }
                else
                {
                    return PlayerAI.State.WalkingToEnemy;
                }
            }
        }
        return PlayerAI.State.WalkingBack;
    }
}

