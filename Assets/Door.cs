using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public Transform player;

    public GameObject GlowObj;

    public bool moved;

    public bool openoncollect;

    public Collectable coll;

    public bool openwhenneeded;

    public AudioSource aud;
    //public Vector3 targetpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    IEnumerator Move(){
        aud.Play();
        for(int i = 0; i < 100; i++){
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }
        aud.Stop();
    }

    IEnumerator Move2(){
        aud.Play();
        for(int i = 0; i < 100; i++){
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        aud.Stop();
    }

    public void Open(){
        StartCoroutine(Move());
    }

    public void Close(){
        StartCoroutine(Move2());
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) < 10 && !moved && !openoncollect && !openwhenneeded){
            if(Input.GetKey("e")){
                moved = true;
                StartCoroutine(Move());
            }
        }
        if(openoncollect && coll.Collected && !openwhenneeded){
            moved = true;
            StartCoroutine(Move());
        }
        GlowObj.SetActive(Vector3.Distance(player.position, transform.position) < 10 && !moved && !openoncollect && !openwhenneeded);
    }
}
