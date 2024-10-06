using UnityEngine;

public class StarClickHandler : MonoBehaviour
{
    public GameObject infoPanel;
    public TMPro.TextMeshProUGUI infoText;

    // Update is called once per frame
    void Update()
    {
        // If the user clicked
        if(Input.GetMouseButtonDown(0))
        {
            // Use raycast from camera to where the mouse click happened
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //If a star object was hit, display star info
                if (hit.collider.gameObject.CompareTag("Star"))
                {
                    // get starinfo component from clicked star
                    StarInfo starInfo = hit.collider.gameObject.GetComponent<StarInfo>();

                    if (starInfo != null) {
                        infoPanel.SetActive(true);
                        infoText.text = $"Star ID: {starInfo.sourceID}\n" +
                                        $"RA: {starInfo.ra}\n" +
                                        $"Dec: {starInfo.dec}\n" +
                                        $"Distance: {starInfo.distance} parsecs\n" +
                                        $"Magnitude: {starInfo.magnitude}";
                    }
                }
            }
        }
    }
}
