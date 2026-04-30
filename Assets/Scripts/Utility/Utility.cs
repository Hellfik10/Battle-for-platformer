public static class Utility
{
    public static float NormalizedValue(float absoluteValue, float maxValue)
    {
        return maxValue > 0 ? absoluteValue / maxValue : 0f;
    }
}
