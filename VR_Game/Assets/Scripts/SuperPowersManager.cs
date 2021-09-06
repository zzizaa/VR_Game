using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPowersManager : MonoBehaviour
{
    public GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void EnableEarthPower()
    { 
        //player.GetComponent<WallSpawner>().isEarth = true;
       // player.GetComponent<FireBall>().isFire = false;

       //GameObject g = GameObject.FindGameObjectWithTag(Player);
    }
    
    public void EnableFirePower()
    {
        //player.GetComponent<FireBall>().isFire = true;
        //player.GetComponent<WallSpawner>().isEarth = false;
    }
}
