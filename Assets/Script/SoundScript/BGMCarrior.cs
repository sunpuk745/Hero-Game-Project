using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCarrior : MonoBehaviour
{
    // Put this on BGM to carry it to the other scene.
    public static BGMCarrior BGMInstance;
    private void Awake()
    {
        if(BGMInstance != null && BGMInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BGMInstance = this;
        DontDestroyOnLoad(this);
    }
}
