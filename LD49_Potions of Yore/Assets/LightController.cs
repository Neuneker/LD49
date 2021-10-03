using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    [SerializeField] LightComp[] lights;
    [SerializeField] SpriteRenderer BlackCover;
    private float counter;
    [SerializeField] Color Overlay;

    // Start is called before the first frame update
    void Start()
    {
        foreach (LightComp l in lights)
        {
            l.light.intensity = 0;
        }
        StartCoroutine(TurnOnLights());
    }

    private IEnumerator TurnOnLights()
    {
        while (Time.timeSinceLevelLoad < 5)
        {
            BlackCover.color = Color.Lerp(Color.black, Overlay, Time.timeSinceLevelLoad / 3f);
            foreach (LightComp l in lights)
            {
                l.light.intensity = Mathf.Lerp(0, l.targetIntesity, Time.timeSinceLevelLoad / 3f);
            }
            yield return null;
        }

        foreach (LightComp l in lights)
        {
            if (l.light.GetComponent<LightFlicker>()) l.light.GetComponent<LightFlicker>().enabled = true;
        }
    }

    [System.Serializable]
    public struct LightComp
    {
        public Light2D light;
        public float targetIntesity;
    }
}
