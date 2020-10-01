using UnityEngine;

public static class ColorExtender
{
    public static Color ChangeAInColor(this Color color, int a)
    {
        color.a = a/255f;
        return color;
    }
}
