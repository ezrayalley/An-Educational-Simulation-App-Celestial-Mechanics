using UnityEngine;
using UnityEngine.UI;

public class SimulationManager2 : MonoBehaviour
{
    public GameObject earth;
    public GameObject dragEarth;
    public MonoBehaviour earthSpinScript;

    public GameObject dayText;
    public GameObject nightText;

    public Light sunlight; // Point light on the sun
    public Slider lightIntensitySlider; // UI Slider to control light intensity
    public GameObject adjustLightText; // "Adjust Light" label Text
    public GameObject autoModeButton; // Reappears in manual mode

    public void SwitchToManual()
    {
        earthSpinScript.enabled = false;

        earth.transform.SetParent(dragEarth.transform);
        dragEarth.SetActive(true);

        if (dayText != null) dayText.SetActive(false);
        if (nightText != null) nightText.SetActive(false);

        if (sunlight != null) sunlight.enabled = false;

        if (lightIntensitySlider != null)
        {
            lightIntensitySlider.gameObject.SetActive(true);
            lightIntensitySlider.onValueChanged.AddListener(UpdateLightIntensity);
        }

        if (adjustLightText != null) adjustLightText.SetActive(true);

        if (autoModeButton != null) autoModeButton.SetActive(true);
    }

    public void SwitchToAuto()
    {
        dragEarth.SetActive(false);
        earth.transform.SetParent(null);

        earthSpinScript.enabled = true;

        if (dayText != null) dayText.SetActive(true);
        if (nightText != null) nightText.SetActive(true);

        if (sunlight != null)
        {
            sunlight.enabled = true;
            sunlight.intensity = 1f; // Reset to default
        }

        if (lightIntensitySlider != null)
        {
            lightIntensitySlider.onValueChanged.RemoveAllListeners();
            lightIntensitySlider.gameObject.SetActive(false);
        }

        if (adjustLightText != null) adjustLightText.SetActive(false);

        if (autoModeButton != null) autoModeButton.SetActive(false);
    }

    public void UpdateLightIntensity(float value)
    {
        if (sunlight != null)
        {
            sunlight.enabled = true; // Make sure light is active
            sunlight.intensity = value;
        }
    }

    private void Start()
    {
        // Optional: Hide elements at start
        if (autoModeButton != null) autoModeButton.SetActive(false);
        if (lightIntensitySlider != null) lightIntensitySlider.gameObject.SetActive(false);
        if (adjustLightText != null) adjustLightText.SetActive(false);
    }
}
