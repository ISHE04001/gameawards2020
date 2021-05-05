using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyes : MonoBehaviour
{

    public float distance;
    public LineRenderer LineOfSight;
    public Gradient redColor;
    public Gradient greenColor;
    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            LineOfSight.SetPosition(1, hitInfo.point);
            LineOfSight.colorGradient = redColor;
            if (hitInfo.collider.CompareTag("Player"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
                LineOfSight.SetPosition(1, transform.position + transform.right * distance);
                LineOfSight.colorGradient = greenColor;
            }
            LineOfSight.SetPosition(0, transform.position);
        }
    }
}

