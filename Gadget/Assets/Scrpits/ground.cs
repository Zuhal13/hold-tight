using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ground : MonoBehaviour
{
    public GameObject fallingClimber, mainClimber; 
    public camFallow camfallow;
    public ParticleSystem lightning, respawn;
    public chargeBar bar;

    bool again=true;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && again)
        {
            camfallow.target = fallingClimber;
            lightning.Play();
            respawn.Play();
            fallingClimber.SetActive(true);
            counter = mainClimber.GetComponentInParent<climbing>().totaCoilSpringCount;
            fallingClimber.transform.DOMoveY((bar.lastHeight*counter)/10, 3);
            mainClimber.GetComponentInParent<climbing>().enabled = false;

            Destroy(mainClimber);

            again = false;
        }
    }
}
