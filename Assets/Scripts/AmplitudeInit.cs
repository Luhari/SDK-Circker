using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplitudeInit : MonoBehaviour
{
    [SerializeField]
    private string amplitudeKey = "445661d23950e9ef64e2fceda8860104";
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        Debug.Log("Init Amplitude");
        Amplitude amplitude = Amplitude.Instance;
        amplitude.logging = true;
        amplitude.init(amplitudeKey);
        Amplitude.Instance.logEvent("EVENT_NAME_HERE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
