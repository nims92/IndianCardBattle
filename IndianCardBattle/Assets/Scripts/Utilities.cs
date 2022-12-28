using UnityEngine;

public static class Utilities
{
    public static float GetDeviceAspectRatio()
    {
        return (1f * Screen.width) / Screen.height;
    }

    public static float CalculateVerticalFOV(float horizontalFOV)
    {
        return Camera.HorizontalToVerticalFieldOfView(horizontalFOV, GetDeviceAspectRatio());
    }
}
