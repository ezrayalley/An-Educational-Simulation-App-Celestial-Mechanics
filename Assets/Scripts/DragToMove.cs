using UnityEngine;

public class DragToMove : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;
    private bool isDragging = false;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Mouse input (Editor or PC)
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOver())
            {
                isDragging = true;
                offset = transform.position - GetMouseWorldPos();
            }
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Touch input (Mobile)
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && IsTouchOver(touch))
            {
                isDragging = true;
                offset = transform.position - GetTouchWorldPos(touch);
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                transform.position = GetTouchWorldPos(touch) + offset;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }

    // Check if mouse is over the object
    bool IsMouseOver()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit) && hit.transform == transform;
    }

    // Get world position of mouse click
    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.WorldToScreenPoint(transform.position).z;
        return cam.ScreenToWorldPoint(mousePos);
    }

    // Check if the touch is over the object
    bool IsTouchOver(Touch touch)
    {
        Ray ray = cam.ScreenPointToRay(touch.position);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit) && hit.transform == transform;
    }

    // Get world position of the touch
    Vector3 GetTouchWorldPos(Touch touch)
    {
        Vector3 touchPos = touch.position;
        touchPos.z = cam.WorldToScreenPoint(transform.position).z;
        return cam.ScreenToWorldPoint(touchPos);
    }
}
