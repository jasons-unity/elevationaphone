using UnityEngine;

public class ToneClicker : MonoBehaviour
{
    public ToneGenerator toneGenerator; 
    private void OnMouseDown()
    {
        var toneData = GetComponent<ToneData>();
        toneGenerator.PlayTone(toneData.ToneFreq);
    }
    
    private void OnMouseUp()
    {
        toneGenerator.StopTone();
    }
}
