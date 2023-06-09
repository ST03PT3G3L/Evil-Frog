using UnityEngine;
using System.Collections;

public class Range : MonoBehaviour
{
    public int segments;
    public float xradius;
    public float yradius;
    LineRenderer line;
    Tower data;

    void OnEnable()
    {
        data = gameObject.GetComponent<Tower>();
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        CreatePoints();
    }


    void CreatePoints()
    {
        float x;
        float y;
        float z = 10f;

        xradius = data.range / 2;
        yradius = data.range / 2;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }
}