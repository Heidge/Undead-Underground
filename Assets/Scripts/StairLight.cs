using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairLight : MonoBehaviour
{
    public GameObject pointLight;

    public void Switch(bool on)
    {
        pointLight.SetActive(on);
        if (on)
            gameObject.GetComponent<AudioSource>().PlayDelayed(0.01f);
    }


}
