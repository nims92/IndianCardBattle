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

    public static bool IsTabletDevice()
    {
        var aspectRatio = GetDeviceAspectRatio();
        return aspectRatio < 1.4f || aspectRatio < 1.65f;
    }
    
}
