using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPop : MonoBehaviour
{
    RectTransform myRectTransform;

    Vector3 targetScale;

    bool started;

    [SerializeField]float delay;

    private void Awake() {
        myRectTransform = GetComponent<RectTransform>();
        targetScale = myRectTransform.localScale;
    }

    private void Start() {
        myRectTransform = GetComponent<RectTransform>();
        targetScale = myRectTransform.localScale;
        myRectTransform.localScale = Vector3.zero;
        myRectTransform.LeanScale(targetScale, 0.5f).setEase(LeanTweenType.easeOutBounce).setDelay(delay);
        myRectTransform.LeanRotateAroundLocal(Vector3.forward, 360f, 0.25f).setEase(LeanTweenType.easeInOutCirc).setDelay(delay);
        started = true;
    }

    private void OnEnable() {
        if(started){
            myRectTransform.localScale = Vector3.zero;
            myRectTransform.LeanScale(targetScale, 0.5f).setEase(LeanTweenType.easeOutBounce).setDelay(delay);
            myRectTransform.LeanRotateAroundLocal(Vector3.forward, 360f, 0.25f).setEase(LeanTweenType.easeInOutCirc).setDelay(delay);
        }
    }
}
