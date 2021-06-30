using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Touch touch;
    
    [SerializeField]Transform capsule;

    [Header("Movement")]
    private float speedModifier;
    bool startRunning = false;
    [SerializeField]float runSpeed = 5f;

    [Header("Effects")]
    [SerializeField]float moveRotationCap = 45f;

    private void Start()
    {
        speedModifier = 0.01f;
    }

    private void Update()
    {
        TouchMovement();

        if(startRunning)
            GoForward();
    }

    void TouchMovement()
    {
        if(Input.touchCount > 0)
        {
            touch  = Input.GetTouch(0);

            if(touch.phase > 0)
            {
                touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Moved)
                {

                    Vector3 newPos = new Vector3
                    (
                        capsule.localPosition.x + touch.deltaPosition.x * speedModifier,
                        capsule.localPosition.y,
                        capsule.localPosition.z
                    );

                    newPos.x = Mathf.Clamp(newPos.x, -5, 5);

                    if(newPos.x > capsule.position.x)
                        RotateEffect(moveRotationCap);
                    else if(newPos.x < capsule.position.x)
                        RotateEffect(-moveRotationCap);

                    capsule.localPosition = newPos;
                }

                else if(touch.phase == TouchPhase.Ended)
                    RotateEffect(0);
            }

            if(!startRunning)
                startRunning = true;
        }
    }
    
    void GoForward()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    void RotateEffect(float targetRotation)
    {
        capsule.rotation = Quaternion.Euler(capsule.rotation.eulerAngles.x,capsule.rotation.eulerAngles.y, Mathf.Lerp(0, targetRotation, Time.deltaTime * 4f));
    }

    public void StartCurve()
    {
        StartCoroutine(CURVEDMOVEMENT());
    }

    IEnumerator CURVEDMOVEMENT()
    {
        float elapsedTime = 0;
        float maxTime = 4f;
        float lerpQuantity = 0;
        Quaternion newRotation;
        yield return null;
        yield return new WaitForSeconds(2.75f);
        newRotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y + 90, transform.rotation.z);
        while(elapsedTime < maxTime)
        {
            elapsedTime += Time.deltaTime;
            lerpQuantity = elapsedTime/maxTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, lerpQuantity);
            yield return null;
        }
    }

}
