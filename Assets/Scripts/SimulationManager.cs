using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public GameObject earth;
    public GameObject moon;
    public GameObject moonOrbit;

    public GameObject dragEarth;
    public GameObject dragMoon;

    public MonoBehaviour earthSpinScript;
    public MonoBehaviour moonOrbitScript;

    public GameObject autoModeButton; // Auto button GameObject (assign in inspector)

    void Start()
    {
        // Hide AutoMode button when scene loads
        if (autoModeButton != null)
            autoModeButton.SetActive(false);

        // Start in Auto mode
        SwitchToAuto();
    }

    public void SwitchToManual()
    {
        // Disable automatic scripts
        earthSpinScript.enabled = false;
        moonOrbitScript.enabled = false;

        // Detach Earth and Moon for manual drag
        earth.transform.SetParent(dragEarth.transform);
        moon.transform.SetParent(dragMoon.transform);

        dragEarth.SetActive(true);
        dragMoon.SetActive(true);

        // Show Auto button to allow switching back
        if (autoModeButton != null)
            autoModeButton.SetActive(true);
    }

    public void SwitchToAuto()
    {
        // Hide drag objects
        dragEarth.SetActive(false);
        dragMoon.SetActive(false);

        // Reattach Earth and Moon for automatic orbit
        earth.transform.SetParent(null); // Optional: Set to specific original parent if needed
        moon.transform.SetParent(moonOrbit.transform);

        // Enable automatic scripts
        earthSpinScript.enabled = true;
        moonOrbitScript.enabled = true;

        // Hide Auto button again
        if (autoModeButton != null)
            autoModeButton.SetActive(false);
    }
}
