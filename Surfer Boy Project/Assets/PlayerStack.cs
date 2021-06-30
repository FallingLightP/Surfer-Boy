using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    Transform stack;
    List<GameObject> boxes;
    public static PlayerStack myStack;
    
    [SerializeField] float stackLerpSpeed = 15f;
    float heightOffset = 1.75f;

    private void Start() {
        myStack = this;
        stack = gameObject.transform.parent;
        print(stack.gameObject.name);
        boxes = new List<GameObject>();
    }

    private void Update() {
        MoveStack();
    }

    public void AddBox(GameObject box){
        box.transform.position = transform.position - Vector3.down * heightOffset;
        transform.position += Vector3.up * heightOffset;
        boxes.Add(box);
    }

    public void StackUpdate(GameObject box)
    {
        boxes.RemoveAt(boxes.IndexOf(box));
        StartCoroutine(DECREASEHEIGHT());
    }

    void MoveStack(){
        foreach(GameObject box in boxes)
        {
            Transform boxTransform = box.transform;
            int listPosition = boxes.IndexOf(box);
            //(Mathf.Abs(listPosition - boxes.Count)/boxes.Count)   Tower offset effect, not working ATM. This Value would be multiplied with the stackLerpSpeed variable to create a more unstable looking tower
            boxTransform.position = Vector3.Lerp(boxTransform.position, transform.position - (Vector3.up * heightOffset * (listPosition + 1)), Time.deltaTime * stackLerpSpeed);
        }
    }

    IEnumerator DECREASEHEIGHT()
    {
        yield return null;
        yield return new WaitForSeconds(0.3f);

        transform.position += Vector3.down * heightOffset;
    }

}
