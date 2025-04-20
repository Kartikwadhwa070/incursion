using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadlockController : MonoBehaviour
{
    [Header("Assign UI Buttons")]
    public Button leftButton;
    public Button rightButton;
    public Button upButton;
    public Button downButton;

    [Header("Assign Padlock Parts (5 total)")]
    public List<Transform> padlockParts;

    private int currentPartIndex = 0;

    private void Start()
    {
        // Assign button listeners
        leftButton.onClick.AddListener(SelectPreviousPart);
        rightButton.onClick.AddListener(SelectNextPart);
        upButton.onClick.AddListener(() => RotatePart(36f));
        downButton.onClick.AddListener(() => RotatePart(-36f));
    }

    void SelectPreviousPart()
    {
        currentPartIndex = Mathf.Max(currentPartIndex - 1, 0);
    }

    void SelectNextPart()
    {
        currentPartIndex = Mathf.Min(currentPartIndex + 1, padlockParts.Count - 1);
    }

    void RotatePart(float angle)
    {
        if (padlockParts.Count == 0 || padlockParts[currentPartIndex] == null)
            return;

        padlockParts[currentPartIndex].Rotate(Vector3.right, angle, Space.Self);
    }
}
