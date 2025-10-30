using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadSceneAsync("Win");
    }
    //public void Trigger(){
    //    SceneManager.LoadSceneAsync("Win");
    //}
}
