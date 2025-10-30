using UnityEngine;
using Unity.Cinemachine;

public class CheckForCollected : MonoBehaviour
{
    //public Animator anim;

    public GameObject Reg;

    public GameObject New;

    public CinemachineImpulseSource impulseSource;

    public GameObject parts;

    public AudioSource aud;

    public void Trigger(){
        Reg.SetActive(false);
        New.SetActive(true);
        //anim.SetBool("angy", true);
        parts.SetActive(true);
        impulseSource.GenerateImpulse(new Vector3(0.1f, 0.1f, 0.1f));
        aud.pitch = 0.8f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
