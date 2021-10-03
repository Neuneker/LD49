using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] float minIntensity;
    [SerializeField] float maxIntensity;

    [SerializeField] float targetIntensity;
    [SerializeField] Light2D target;

    [SerializeField] float flickerSpeed;

    [SerializeField] Transform tFlame;

    private void Awake()
    {
        SetNewTarget();
    }

    private void FixedUpdate()
    {
        if (myApproximation(targetIntensity,target.intensity,.01f))
        {
            SetNewTarget();
        }

        target.intensity = Mathf.Lerp(target.intensity, targetIntensity,Time.deltaTime * flickerSpeed);
        tFlame.localScale = new Vector3(target.intensity, target.intensity, 1);
    }

    private void SetNewTarget()
    {
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }

    private bool myApproximation(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }
}
