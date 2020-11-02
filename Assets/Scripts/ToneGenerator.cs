using System.Collections;
using UnityEngine;

public class ToneGenerator : MonoBehaviour
{
    public double frequency = 440.0;
    private double _increment;
    private double _phase;
    private const double SamplingFrequency = 48000.0;
    public float gain = 0f;


    public void PreviewTone()
    {
        StartCoroutine(PlayToneForDuration(0.2F));
    }

    public void PlayTone(float freq)
    {
        frequency = freq;
        PlayTone();
    }

    public void StopTone()
    {
        gain = 0F;
    }

    private IEnumerator PlayToneForDuration(float duration)
    {
        gain = 0.2F;
        yield return new WaitForSeconds(duration);
        gain = 0F;
    }

    private void PlayTone()
    {
        gain = 0.2F;
    }
    
    private void OnAudioFilterRead(float[] data, int channels)
    {
        _increment = frequency * 2.0 * Mathf.PI / SamplingFrequency;

        for (var i = 0; i < data.Length; i += channels)
        {
            _phase += _increment;
            data[i] = gain * Mathf.Sin((float) _phase);

            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

            if (_phase > (Mathf.PI * 2))
            {
                _phase = 0.0;
            }
        }
        
    }
}
