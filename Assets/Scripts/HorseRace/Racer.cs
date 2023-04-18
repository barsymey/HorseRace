using UnityEngine;
using UnityEngine.UI;

public class Racer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Image visual;
    private float _baseSpeed = 5;
    private float _accelerationValue = 30;
    private float _currentProgress;

    public void Init()
    {
        _currentProgress = 0;
        visual.color = new Color(Random.Range(0,1f), Random.Range(0,1f), Random.Range(0,1f), 1);
        animator.Play("Galloping");
    }

    public float Proceed()
    {
        _currentProgress += (_baseSpeed + Random.Range(0, _accelerationValue)) * Time.deltaTime;
        return _currentProgress;
    }
}