using UnityEngine;
using System.Collections;

public class Lock : MonoBehaviour
{
    public Movement player;

    public Transform player2;

    public Transform keyhole;

    public GameObject GlowObj;

    public Door door;

    public bool moved;

    public AudioSource aud;

    IEnumerator Move(){
        aud.Play();
        for(int i = 0; i < 90; i++){
            keyhole.eulerAngles = new Vector3(keyhole.eulerAngles.x - 1, keyhole.eulerAngles.y, keyhole.eulerAngles.z);
            yield return new WaitForSeconds(0.005f);
        }
        aud.Stop();
        yield return new WaitForSeconds(0.25f);
        door.Open();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player2.position, transform.position) < 5 && !moved && player.keys > 0){
            if(Input.GetKey("e")){
                
                player.keys--;
                moved = true;
                StartCoroutine(Move());
            }
        }
        GlowObj.SetActive(Vector3.Distance(player2.position, transform.position) < 5 && !moved && player.keys > 0);
    }
}
