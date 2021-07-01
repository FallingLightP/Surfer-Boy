using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameFuntion : MonoBehaviour
{

    PlayerMovement player;
    Rigidbody rigidbody;

    [SerializeField]RectTransform looseMenu;
    [SerializeField]RectTransform winMenu;

    private void Start() {
        player = GetComponentInParent<PlayerMovement>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Win()
    {
        StartCoroutine(WIN());
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Wall")
        {
            StartCoroutine(LOOSE());
            print("hello");
        }
    }

    IEnumerator LOOSE()
    {
        GameManager.initialized = false;
        player.movementOverhaul = true;
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.AddForce(new Vector3(0.2f,0.75f,-1) * 15f, ForceMode.Impulse);
        rigidbody.AddTorque(new Vector3(1,0,5) * 500f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.75f);
        looseMenu.LeanScale(Vector3.one, 0.25f);
    }

    IEnumerator WIN()
    {
        yield return new WaitForSeconds(0.75f);

        winMenu.LeanScale(Vector3.one, 0.25f);
    }
}
