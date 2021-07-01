using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameFuntion : MonoBehaviour
{

    PlayerMovement player;
    Rigidbody rig;

    [SerializeField]RectTransform looseMenu;
    [SerializeField]RectTransform winMenu;

    private void Start() {
        player = GetComponentInParent<PlayerMovement>();
        rig = GetComponent<Rigidbody>();
    }

    public void Win()
    {
        StartCoroutine(WIN());
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Wall")
        {
            StartCoroutine(LOOSE());
        }
    }

    IEnumerator LOOSE()
    {
        GameManager.initialized = false;
        player.movementOverhaul = true;
        rig.constraints = RigidbodyConstraints.None;
        rig.AddForce(new Vector3(0.2f,0.75f,-1) * 15f, ForceMode.Impulse);
        rig.AddTorque(new Vector3(1,0,5) * 500f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.75f);
        looseMenu.gameObject.SetActive(true);
        looseMenu.LeanScale(Vector3.one, 0.25f);
    }

    IEnumerator WIN()
    {
        yield return new WaitForSeconds(1.2f);

        winMenu.gameObject.SetActive(true);
        winMenu.LeanScale(Vector3.one, 0.25f);
    }
}
