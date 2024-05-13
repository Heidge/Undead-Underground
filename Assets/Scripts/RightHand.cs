using UnityEngine;
using UnityEngine.InputSystem;

public class RightHand : MonoBehaviour
{
    public Animator handAnimator;

    void Start()
    {
        handAnimator.SetFloat("Grip", 1);
    }
}
