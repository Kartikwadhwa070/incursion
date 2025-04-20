using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ImageTargetInventory : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour trackableBehaviour;
    [Header("Assign in Inspector")]
    public GameObject modelToShow;
    public GameObject toggleButton;
    private bool modelVisible = false;
    void Start()
    {
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        if (trackableBehaviour)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }

        modelToShow.SetActive(false);
        toggleButton.SetActive(false);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            toggleButton.SetActive(true);
        }
        else
        {
            toggleButton.SetActive(false);
            modelToShow.SetActive(false);
            modelVisible = false;
        }
    }

    public void ToggleModel()
    {
        modelVisible = !modelVisible;
        modelToShow.SetActive(modelVisible);
    }
    private void Update()
    {
        if (modelVisible && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == modelToShow.transform)
                {
                    modelToShow.SetActive(false);
                    modelVisible = false;
                }
            }
        }
    }
}
