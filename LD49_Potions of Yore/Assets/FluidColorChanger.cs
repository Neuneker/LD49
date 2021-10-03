using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FluidColorChanger : MonoBehaviour
{
    [SerializeField] float multiplier;
    public Color newColor { get; private set; }
    [SerializeField] LayerMask detectionMask;
    private List<SpriteRenderer> renderers;
    private float counter;
    [SerializeField] int requiredCount;
    [SerializeField] float VertOffset;
    [SerializeField] Vector3 boundingBox;

    public Color targetColor { get; private set; }

    [SerializeField] SpriteRenderer TargetIcon;

    bool startCount;
    public float unstableCounter = 30;
    int level = -1;

    public GameObject particles, winParts;

    private void Awake()
    {
        ResetLevel();
    }

    // Start is called before the first frame update
    void ResetLevel()
    {
        targetColor = new Color(Random.value, Random.value, Random.value);
        float H, S, V;
        Color.RGBToHSV(targetColor, out H, out S, out V);
        targetColor = Color.HSVToRGB(H, S, 1);

        TargetIcon.color = targetColor;
        newColor = Color.black;
        Mix();        
        startCount = false;
        unstableCounter = 31 - PlayerPrefs.GetInt("Level");
        unstableCounter = Mathf.Clamp(unstableCounter, 20, 30);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Mix();
        }

        if (startCount) unstableCounter -= Time.deltaTime;

        if (unstableCounter < 0)
        {
            LevelFailed();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    public string GetCounter()
    {
        if (unstableCounter < 0) return "0";
        return ((int)unstableCounter).ToString();
    }

    public void Mix()
    {
        print("looking for Colors");

        //find all objects inside the bottle

        Collider2D[] Colors = Physics2D.OverlapBoxAll(transform.position + Vector3.down * VertOffset, boundingBox, 0, detectionMask);
        
        print("Count found: " + Colors.Length.ToString());

        if (Colors.Length > 0)
        {
            startCount = true;
        }

        float r = 0, b = 0, g = 0;

        renderers = new List<SpriteRenderer>();

        foreach (Collider2D collider2D in Colors)
        {
            SpriteRenderer temp = collider2D.GetComponent<SpriteRenderer>();
            renderers.Add(temp);
            r += temp.color.r;
            b += temp.color.b;
            g += temp.color.g;
        }

        newColor = new Color(r / Colors.Length, g / Colors.Length, b / Colors.Length);

        float H, S, V;
        Color.RGBToHSV(newColor, out H, out S, out V);
        newColor = Color.HSVToRGB(H, S, 1);
        StartCoroutine(ColorChange());

    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.down *VertOffset , boundingBox);
    }

    private IEnumerator ColorChange()
    {
        counter = 0;
        while (counter < 1)
        {
            counter += Time.deltaTime / 1;
            foreach (SpriteRenderer r in renderers)
            {
                r.color = Color.Lerp(r.color, newColor, counter);
            }
            yield return null;
        }

        EvaluateCompletion();
        Mix();
    }

    public float rDelta;
    public float bDelta;
    public float gDelta;

    private void EvaluateCompletion()
    {
        rDelta = Mathf.Abs((newColor.r - targetColor.r));
        bDelta = Mathf.Abs((newColor.b - targetColor.b));
        gDelta = Mathf.Abs((newColor.g - targetColor.g));

        if ((rDelta + bDelta + gDelta) < .25f && renderers.Count >= requiredCount)
        {
            LevelComplete();
        }
        else
        {
            //LevelFailed();
        }
    }
    bool complete;

    private void LevelComplete()
    {
        if (complete) return;
        complete = true;
        print("You Won");
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        winParts.SetActive(true);
        StartCoroutine(GoToLevel());
    }

    private void LevelFailed()
    {
        print("Boom");
        particles.SetActive(true);

        //StopAllCoroutines();
        StartCoroutine(GoToMenu());
    }

    private IEnumerator GoToLevel()
    {
        yield return new WaitForSeconds(2f);
        StopAllCoroutines();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


    public GameObject GameOverPanel;
    public TextMeshProUGUI potionsBrewed;
    private IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(2f);
        potionsBrewed.text = "Ye brewed " + PlayerPrefs.GetInt("Level").ToString() + " potions.";
        GameOverPanel.SetActive(true);
        StopAllCoroutines();
        
    }
}
