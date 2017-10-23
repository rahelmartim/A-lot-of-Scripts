using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour {
    private bool imdead;
    public int current_life;
    private const int initial_hp = 14;
    public Animator anim_control;
    public float time_inv;
    private float time_elapsed;
    private bool invunerable;
    public Animator anim_Ysa;
	// Use this for initialization
	void Start ()
    {
        this.current_life = initial_hp;
        this.imdead = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        time_elapsed += Time.deltaTime;
        if (time_elapsed >= time_inv) invunerable = false;
        dead();
    }
    void dead()
    {
        if (this.current_life == 0 && !this.imdead)
        {
            anim_Ysa.SetTrigger("dead");
            this.imdead = true;
            GetComponentInParent<Isayah>().die();
        }
    }
    public void lose_life()
    {
        if (!invunerable)
        {
            anim_control.SetInteger("life_a", current_life);
            anim_control.SetInteger("life_n", current_life - 1);
            anim_control.SetTrigger("active");
            this.current_life -= 1;
            invunerable = true;
            time_elapsed = 0;
        }
    }
    public void gain_life()
    {
        if(this.current_life < 14)
        {
            anim_control.SetTrigger("heal");
            this.current_life += 1;
        }
    }
    public void lava()
    {
        this.current_life = 0;
    }
}
