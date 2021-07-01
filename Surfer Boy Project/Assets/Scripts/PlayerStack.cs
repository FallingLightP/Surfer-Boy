using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    Transform stack;
    List<GameObject> boxes;
    PlayerMovement player;
    public static PlayerStack myStack;
    
    [SerializeField] float stackLerpSpeed = 15f;
    float heightOffset = 1.75f;

    bool backFlip;

    private void Start() {
        myStack = this;
        player = GetComponentInParent<PlayerMovement>();
        stack = gameObject.transform.parent;
        boxes = new List<GameObject>();
    }

    private void Update() {
        MoveStack();
    }

    public void AddBox(GameObject box){
        box.transform.position = transform.position;
        transform.position += Vector3.up * heightOffset;
        boxes.Add(box);
        transform.LeanRotateAroundLocal(Vector3.right,180, 0.8f).setEase(LeanTweenType.easeOutExpo);
        backFlip = true;
    }

    public void StackUpdate(GameObject box)
    {
        boxes.RemoveAt(boxes.IndexOf(box));
        StartCoroutine(DECREASEHEIGHT());
        if(backFlip)
        {
            transform.LeanRotateAroundLocal(Vector3.right,-180, 0.8f).setEase(LeanTweenType.easeOutExpo);
            backFlip = false;
        }
    }

    void MoveStack(){
        foreach(GameObject box in boxes)
        {
            Transform boxTransform = box.transform;
            int listPosition = boxes.IndexOf(box);
            boxTransform.position = Vector3.Lerp(boxTransform.position, transform.position - (Vector3.up * heightOffset * (listPosition + 1)), Time.deltaTime * stackLerpSpeed * (Mathf.Abs((float)(listPosition) - (float)boxes.Count) / (float)boxes.Count)); //Fixed the Unstable Lerp Effect
        }
    }

    IEnumerator DECREASEHEIGHT()
    {
        yield return null;
        yield return new WaitForSeconds(0.35f);

        transform.position += Vector3.down * heightOffset;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Curve")
            player.StartCurve();
    }

}
