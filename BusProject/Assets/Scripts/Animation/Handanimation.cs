using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class Handanimation : MonoBehaviour
{
    public Animator handAnimator;
    public XRInputValueReader<float> thumbDown;
    public XRInputValueReader<float> gripDown;
    public XRInputValueReader<float> triggerDown;

    public void hoverObject()
    {
        handAnimator.SetBool("BigHold", true);
    }

    public void unhoverObject()
    {
        handAnimator.SetBool("BigHold", false);
    }

    private void Update()
    {
        float thumbValue = thumbDown.ReadValue();
        float gripValue = gripDown.ReadValue();
        float triggerValue = triggerDown.ReadValue();

        handAnimator.SetBool("ThumbDown", thumbValue > 0);
        handAnimator.SetBool("GripDown", gripValue > 0);
        handAnimator.SetBool("PointDown", triggerValue > 0);

        if (thumbValue == 0 && gripValue == 0 && triggerValue == 0)
        {
            handAnimator.SetTrigger("Reset");
        }
        else
            handAnimator.ResetTrigger("Reset");
    }
}
