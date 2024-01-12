using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedLine : MonoBehaviour
{
    public Transform StartObject;
    public Transform EndObject;
    public int CurveSegments;
    public float CurveHeight;
    public bool InvertDirection;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = CurveSegments + 1;
    }

    void Update()
    {
        DrawCurvedLine();
    }

    void DrawCurvedLine()
    {
        Vector3[] points = new Vector3[CurveSegments + 1];

        for (int i = 0; i <= CurveSegments; i++)
        {
            float t = i / (float)CurveSegments;

            Vector3 point = Vector3.Lerp(StartObject.position, EndObject.position, t);

            if (InvertDirection){
                point.y -= Mathf.Sin(t * Mathf.PI) * CurveHeight;
            }
            else{
                point.y += Mathf.Sin(t * Mathf.PI) * CurveHeight;
            }

            points[i] = point;
        }

        lineRenderer.SetPositions(points);
    }
}
