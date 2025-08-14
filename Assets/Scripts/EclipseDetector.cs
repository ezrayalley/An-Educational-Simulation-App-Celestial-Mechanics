using UnityEngine;

public class EclipseDetector : MonoBehaviour
{
    public Transform sun;
    public Transform earth;
    public Transform moon;

    public GameObject solarEclipseText;
    public GameObject lunarEclipseText;
    public GameObject annularEclipseText;

    public float alignmentThreshold = 0.995f;
    public float annularDistanceThreshold = 2.5f; // Adjust based on your scene scale

    void Update()
    {
        // Vectors for alignment
        Vector3 sunToMoon = (moon.position - sun.position).normalized;
        Vector3 moonToEarth = (earth.position - moon.position).normalized;

        Vector3 sunToEarth = (earth.position - sun.position).normalized;
        Vector3 earthToMoon = (moon.position - earth.position).normalized;

        float dotSolar = Vector3.Dot(sunToMoon, moonToEarth);  // Solar alignment
        float dotLunar = Vector3.Dot(sunToEarth, earthToMoon); // Lunar alignment

        float moonEarthDistance = Vector3.Distance(moon.position, earth.position);

        // Reset all
        solarEclipseText.SetActive(false);
        lunarEclipseText.SetActive(false);
        annularEclipseText.SetActive(false);

        // Check Solar Eclipse
        if (dotSolar > alignmentThreshold)
        {
            if (moonEarthDistance > annularDistanceThreshold)
            {
                annularEclipseText.SetActive(true); // Annular eclipse
            }
            else
            {
                solarEclipseText.SetActive(true); // Normal solar eclipse
            }
        }
        else if (dotLunar > alignmentThreshold)
        {
            lunarEclipseText.SetActive(true); // Lunar eclipse
        }
    }
}
