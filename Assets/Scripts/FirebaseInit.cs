using UnityEngine;

using Firebase;

public class FirebaseInit : MonoBehaviour
{
    FirebaseApp app;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Init Firebase");
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependentyStatus = task.Result;
            if (dependentyStatus == Firebase.DependencyStatus.Available)
            {
                Debug.Log(string.Format("Dependency status: {0}", dependentyStatus));
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            } 
            else
            {
                Debug.Log(string.Format("Could not resolve all Firebase dependencies : {0}", dependentyStatus));
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
