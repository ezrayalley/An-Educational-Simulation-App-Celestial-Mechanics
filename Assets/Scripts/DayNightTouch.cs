using UnityEngine;
using TMPro;

public class DayNightTouch : MonoBehaviour
{
    public Transform sun; // Assign the Sun object here
    public TextMeshProUGUI popupText; // Assign the Popup Text UI here
    public float popupDuration = 2f; // How long the popup stays visible

    private float popupTimer;

    void Start()
    {
        popupText.gameObject.SetActive(false);
    }

    void Update()
    {
        // For mobile touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            HandleRaycast(touchPosition);
        }

        // For mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            HandleRaycast(mousePosition);
        }

        // Countdown to hide the popup
        if (popupText.gameObject.activeSelf)
        {
            popupTimer -= Time.deltaTime;
            if (popupTimer <= 0)
            {
                popupText.gameObject.SetActive(false);
            }
        }
    }

    void HandleRaycast(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Earth"))
            {
                ShowPopupBasedOnLight(hit.point);
            }
        }
    }

    void ShowPopupBasedOnLight(Vector3 hitPoint)
    {
        Vector3 directionToSun = (sun.position - hitPoint).normalized;
        Vector3 surfaceNormal = (hitPoint - transform.position).normalized;

        float dot = Vector3.Dot(directionToSun, surfaceNormal);

        if (dot > 0)
        {
            popupText.text = "Day Side";
        }
        else
        {
            popupText.text = "Night Side";
        }

        popupText.gameObject.SetActive(true);
        popupTimer = popupDuration;
    }
}
