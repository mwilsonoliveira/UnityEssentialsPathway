using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day Settings")]
    [Tooltip("How many real-world seconds a full 24-hour day takes.")]
    [Min(0.1f)]
    public float dayDurationInSeconds = 120f;

    [Tooltip("Starting time of day in hours (0 = midnight, 6 = sunrise, 12 = noon, 18 = sunset).")]
    [Range(0f, 24f)]
    public float startTimeOfDay = 8f;

    [Header("Sun Orientation")]
    [Tooltip("Tilt of the sun's path (like latitude). 0 = passes directly overhead.")]
    [Range(-90f, 90f)]
    public float sunPathTilt = 30f;

    private float currentTimeOfDay;

    void Start()
    {
        currentTimeOfDay = startTimeOfDay;
        UpdateSunRotation();
    }

    void Update()
    {
        // Advance time: 24 in-game hours spread over dayDurationInSeconds
        currentTimeOfDay += (24f / dayDurationInSeconds) * Time.deltaTime;

        if (currentTimeOfDay >= 24f)
            currentTimeOfDay -= 24f;

        UpdateSunRotation();
    }

    void UpdateSunRotation()
    {
        // Map 0-24h to 0-360 degrees, offset by -90 so that 6h = sunrise (horizon), 12h = noon (overhead)
        float sunAngle = (currentTimeOfDay / 24f) * 360f - 90f;
        transform.rotation = Quaternion.Euler(sunAngle, sunPathTilt, 0f);
    }
}