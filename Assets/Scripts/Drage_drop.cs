using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drage_drop : MonoBehaviour
{
    private bool isDragging = false;
    private GameObject draggedObject;
    private Vector3 offset;
    private float zCoord;
    private Rigidbody2D draggedRb;

    void Update()
    {
        // Check if the right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            // Check if the ray hits an object with a collider and the "Draggable" tag
            if (hit.collider != null && hit.collider.CompareTag("Draggable"))
            {
                isDragging = true;
                draggedObject = hit.collider.gameObject;
                draggedRb = draggedObject.GetComponent<Rigidbody2D>();
                if (draggedRb != null)
                {
                    draggedRb.gravityScale = 0; // Disable gravity
                    draggedRb.velocity = Vector2.zero; // Stop any existing velocity
                }
                zCoord = Camera.main.WorldToScreenPoint(draggedObject.transform.position).z;
                offset = draggedObject.transform.position - GetMouseWorldPos();
            }
        }

        // Check if the right mouse button is released
        if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
            if (draggedRb != null)
            {
                draggedRb.gravityScale = 2; // Re-enable gravity
                draggedRb = null;
            }
            draggedObject = null;
        }

        // Move the object if it is being dragged
        if (isDragging && draggedObject != null)
        {
            draggedObject.transform.position = GetMouseWorldPos() + offset;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
