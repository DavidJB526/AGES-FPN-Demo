using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class EndScene : MonoBehaviour
{
    [SerializeField]
    private Image blackScreenPanel;
    [SerializeField]
    private string sceneToLoad;
    [SerializeField]
    private float timeToFade;

    private void Awake()
    {
        blackScreenPanel.CrossFadeAlpha(0, 0, true);
    }

    private void Start()
    {
        this.gameObject.SetActive(false);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            blackScreenPanel.CrossFadeAlpha(1, timeToFade, true);
            StartCoroutine(TriggerEnd());
        }
    }

    IEnumerator TriggerEnd()
    {
        yield return new WaitForSeconds(timeToFade + .5f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
