using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CorridorLights : MonoBehaviour
{
    private List<Transform> leftLights;
    private List<Transform> rightLights;
    public void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "left")
            {
                foreach (Tranform light in child)
                {
                    leftLights.Add(light.GetComponent<StairLight>());
                }
            }
            if (child.name == "right")
            {
                foreach (Tranform light in child)
                {
                    rightLights.Add(light);
                }
            }
        }
        leftLights.OrderBy(x => Vector3.Distance(Vector3.Zero, x.position);
        rightLights.OrderBy(x => Vector3.Distance(Vector3.Zero, x.position);
    }

    IEnumerator SwitchCorridor(float delay)
    {
        foreach ()
    }
    public void SwitchLight(transform object, bool on)
    {
        object.GetComponent<StairLight>*().SwitchLight(on);
    }

}
