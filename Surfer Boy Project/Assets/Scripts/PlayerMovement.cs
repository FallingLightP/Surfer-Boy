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
    public bool movementOverhaul = false;

    [Header("Effects")]
    [SerializeField]float moveRotationCap = 45f;
    [SerializeField]float moveRotationLerpSpeed = 4f;
    [SerializeField]ParticleSystem driftLeft;
    [SerializeField]ParticleSystem driftRight;

    private void Start()
    {
        speedModifier = 0.01f;
    }

    private void Update()
    {
        if(!movementOverhaul)
        {
            TouchMovement();

            if(startRunning)
                GoForward();
        }
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

                    //Player Effects

                    float effectFactor = Mathf.Abs(capsule.localPosition.x - newPos.x);

                    if(newPos.x > capsule.position.x && effectFactor > 0.1f){
                        RotateEffect(moveRotationCap);
                    }
                    else if(newPos.x < capsule.position.x && effectFactor > 0.1f){
                        RotateEffect(-moveRotationCap);
                    }
                    else
                        RotateEffect(0);

                    if(newPos.x < capsule.position.x && effectFactor >= 0.75f)
                        driftLeft.Play();
                    else if(newPos.x > capsule.position.x && effectFactor >= 0.75f)
                        driftRight.Play();

                    print(effectFactor);


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
        capsule.localRotation = Quaternion.Euler(capsule.rotation.eulerAngles.x,capsule.rotation.eulerAngles.y, Mathf.Lerp(capsule.rotation.z, targetRotation, Time.deltaTime * moveRotationLerpSpeed));
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
        yield return new WaitForSeconds(2.8f);
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
