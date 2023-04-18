using UnityEngine;
using UnityEngine.UI;

public class RaceTrack : MonoBehaviour
{
    public delegate void OnRaceOver(int winner);

    [SerializeField] Racer _racer;
    [SerializeField] Slider _slider;
    private float _trackDistance;

    public void ResetTrack(float trackDistance)
    {
        _slider.value = 0;
        _trackDistance = trackDistance;
        _racer.Init();
    }

    public bool CheckFinnish()
    {
        float racerProgress = _racer.Proceed();
        _slider.value = (racerProgress/_trackDistance) * _slider.maxValue;
        return _trackDistance < _racer.Proceed();
    }
}