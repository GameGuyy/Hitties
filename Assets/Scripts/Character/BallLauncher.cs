using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] float power = 10f;
    [SerializeField] float maxDrag = 5f;
    Rigidbody2D rb;
    LineRenderer lr;
    LevelController levelController;
    Vector3 dragStartPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    private void Update()
    {
        if(levelController)
        {
            if (levelController.shots > 0 && levelController.canShoot)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    DragStart();
                }

                if (Input.GetMouseButton(0))
                {
                    Dragging();
                }

                if (Input.GetMouseButtonUp(0))
                {
                    DragRelease();
                }
            }
        }
        
       

    }

    void DragStart()
    {
        dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragStartPosition.z = 0.0f;
        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);

    }

    void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        draggingPos.z = 0.0f;
        Vector3 diff = draggingPos - dragStartPosition;
        lr.positionCount = 2;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + diff);
    }

    void DragRelease()
    {
        lr.positionCount = 0;
        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragReleasePos.z = 0.0f;
        Vector3 force = dragReleasePos - dragStartPosition;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
        rb.AddForce(clampedForce, ForceMode2D.Impulse);

        if((clampedForce.x >=1.0f || clampedForce.x<=-1.0f) && (clampedForce.y >= 1.0f || clampedForce.y <= -1.0f))
        {
            levelController.DecreamentShot();
        }
        

    }
}
