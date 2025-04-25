using UnityEngine;
using UnityEngine.UI;

public class ClockPuzzleController : MonoBehaviour
{
    [Header("Clock Hands")]
    public Transform hourHand;
    public Transform minuteHand;

    [Header("UI Buttons")]
    public Button rotateHourButton;
    public Button rotateMinuteButton;

    [Header("Rotation Settings")]
    public float hourRotationStep = 30f;
    public float minuteRotationStep = 6f;

    private void Start()
    {
        if (rotateHourButton != null)
            rotateHourButton.onClick.AddListener(RotateHourHand);

        if (rotateMinuteButton != null)
            rotateMinuteButton.onClick.AddListener(RotateMinuteHand);
    }

    void RotateHourHand()
    {
        hourHand.Rotate(0f, hourRotationStep, 0f);
        CheckPuzzleComplete();
    }

    void RotateMinuteHand()
    {
        minuteHand.Rotate(0f, minuteRotationStep, 0f);
        CheckPuzzleComplete();
    }

    void CheckPuzzleComplete()
    {
        float hourY = NormalizeSignedAngle(hourHand.eulerAngles.y);
        float minuteY = NormalizeSignedAngle(minuteHand.eulerAngles.y);

        bool isHourInRange = hourY <= -118f && hourY >= -122f;
        bool isMinuteInRange = minuteY >= 118f && minuteY <= 122f;

        if (isHourInRange && isMinuteInRange)
        {
            Debug.Log("Puzzle Completed!");
        }
    }

    float NormalizeSignedAngle(float angle)
    {
        angle %= 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
