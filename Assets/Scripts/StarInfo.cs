using UnityEngine;

public class StarInfo : MonoBehaviour
{

    // public so the other scripts can access the variables
    public string sourceID;
    public float ra;
    public float dec;
    public float distance;
    public float magnitude;

    // function to display info when hovered

    public string GetInfo()
    {
        return $"Star ID: {sourceID}\n Ra: {ra}\n Dec: {dec}\n" +
            $"distance: {distance} parsecs\n Magnitude: {magnitude}";
    }
}
