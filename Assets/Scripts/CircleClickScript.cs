using System.Collections;
using UnityEngine;

public class CircleClickScript : MonoBehaviour
{
    private Vector3 originalScale;
    private float duration = 0.1f;
    private int numberClicks = 0;

    private TMPro.TMP_Text numberClicksText;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = gameObject.transform.localScale;

        numberClicksText = gameObject.GetComponentInChildren<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        StartCoroutine(ClickRescaleCoroutine());
    }

    IEnumerator ClickRescaleCoroutine()
    {
        float counter = 0f;
        Vector3 endRescale = new Vector3(3, 3, 1);
        while (counter < duration)
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, endRescale, counter / duration);
            yield return null;
            counter += Time.deltaTime;
        }
        counter = 0;
        while (counter < duration)
        {
            gameObject.transform.localScale = Vector3.Lerp(endRescale, originalScale, counter / duration);
            yield return null;
            counter += Time.deltaTime;
        }
        numberClicksText.text = (++numberClicks).ToString();

        switch (numberClicks)
        {
            case 10: callFirebaseEvent(); break;
        }
    }

    void callFirebaseEvent()
    {

    }
}
