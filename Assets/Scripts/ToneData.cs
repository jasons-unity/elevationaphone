using UnityEngine;

public class ToneData : MonoBehaviour
{
    private float _toneFreq;
    public float ToneFreq {
        get => _toneFreq;
        set => _toneFreq = transform.position.y * 1000; // Convert meter into cm to get more diverse tones
    }
}
