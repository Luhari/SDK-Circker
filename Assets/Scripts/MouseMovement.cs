using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private Vector3 originalPos;
    private float amplitude = 0.05f;
    private float speed = 10f;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.position;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        gameObject.transform.position = originalPos + new Vector3(0, amplitude * Mathf.Sin(speed * counter), 0);
        if (counter > 2 * Mathf.PI) counter = 0;
    }
}
