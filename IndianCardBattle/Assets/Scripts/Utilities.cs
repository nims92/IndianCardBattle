using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utilities
{
    private static float GetDeviceAspectRatio()
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
        return aspectRatio > 0.6f;
    }
    
    public static List<T> GetRandomElements<T>(IEnumerable<T> list, int elementsCount)
    {
        return list.OrderBy(x => Guid.NewGuid()).Take(elementsCount).ToList();
    }
    
    public static IList<T> Clone<T>(this IList<T> listToClone) where T: ICloneable
    {
        return listToClone.Select(item => (T)item.Clone()).ToList();
    }
       
}
