using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashlyticsTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowException()
    {
        Amplitude.Instance.logEvent("APP_CRASHED");
        UnityEngine.Diagnostics.Utils.ForceCrash(UnityEngine.Diagnostics.ForcedCrashCategory.FatalError);
    }
}
