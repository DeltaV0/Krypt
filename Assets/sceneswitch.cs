using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class sceneswitch : MonoBehaviour
{
    public bool go;

    public GameObject[] gobj;

    IEnumerator Move(){
        yield return new WaitForSeconds(0.1f);
        gobj[0].SetActive(true);
        yield return new WaitForSeconds(1.75f);
        gobj[0].SetActive(false);
        gobj[1].SetActive(true);
        yield return new WaitForSeconds(2.9f);
        gobj[1].SetActive(false);
        gobj[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        gobj[2].SetActive(false);
        yield return new WaitForSeconds(2f);
        next();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(go){
            StartCoroutine(Move());
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Main()
    {
        SceneManager.LoadSceneAsync("Intro");
    }

    public void next()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
}
