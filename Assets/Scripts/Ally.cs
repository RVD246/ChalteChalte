using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ally : MonoBehaviour
{
    PlayerMovement player;

    Animator playeranim;

    Animator anim;

    enum States {walk, run, idle};

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        playeranim = player.GetComponent<Animator>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
