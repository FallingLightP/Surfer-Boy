using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLoose : MonoBehaviour
{
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
        yield return null;
        SceneManager.LoadScene(0);
    }
}
