using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAwake : MonoBehaviour
{
    public static CanvasAwake instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
