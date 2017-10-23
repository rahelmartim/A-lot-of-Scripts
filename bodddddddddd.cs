using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodddddddddd : MonoBehaviour {
    public int life;
    public enum actions { Walk, lauch, Punch, noa };
    public actions atual;
    private bool damaged;
    public float time_damaged, time_damaged_elapsed;
    public GameObject player;
    public float total_time_ac, time_elapsed_ac;
    public bool canAC;

    public Transform point1, point2;
    public GameObject coxa, coxa2, coxadonw;

    private bool rain;
    private float totaltimerain, rainelapsed, timecoxa, coxaelapsed;
    // Use this for initialization
    void Start () {
        atual = actions.Punch;
        player = GameObject.FindGameObjectWithTag("Player");
        canAC = false;
        rain = false;
        totaltimerain = 10f;
        timecoxa = 1f;

    }
	
	// Update is called once per frame
	void Update () {

        if(life <= 0)
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        if (player_position()) GetComponentInChildren<SpriteRenderer>().flipX = true;
        else GetComponentInChildren<SpriteRenderer>().flipX = false;
        if (rain)
        {
            rainelapsed += Time.deltaTime;
            if(rainelapsed >= totaltimerain)
            {
                rain = false;            
            }
            coxaelapsed += Time.deltaTime;
            if(coxaelapsed >= timecoxa)
            {
                Instantiate(coxadonw, player.transform.position + new Vector3(0, 20, 0), player.transform.rotation);
                coxaelapsed = 0;
            }
        }

        color_damaged();
        if (!canAC)
        {
            time_elapsed_ac += Time.deltaTime;
            if (time_elapsed_ac >= total_time_ac)
            {
                canAC = true;
            }
        }
        search_action();
        if (atual == actions.lauch)
        {
            GetComponentInChildren<Animator>().SetTrigger("lauch");
            if (GetComponentInChildren<SpriteRenderer>().flipX)
            {
                Instantiate(coxa2, point2.position, point2.rotation);

                time_elapsed_ac = 0;
                canAC = false;
                atual = actions.noa;
            }
            else
            {
                Instantiate(coxa, point1.position, point1.rotation);
                time_elapsed_ac = 0;
                canAC = false;
                atual = actions.noa;

            }
        }else if(atual == actions.Punch)
        {
            GetComponentInChildren<Animator>().SetTrigger("punch");
            rain = true;
            time_elapsed_ac = 0;
            canAC = false;
            atual = actions.noa;
        }
   

    }
    bool player_position()
    {
        if (player.transform.position.x - transform.position.x <= 0) return true;
        else return false;
    }
    void search_action()
    {
        
        if (canAC)
        {
            float index = Random.Range(0, 9);


            if (index <= 3)
            {
                atual = actions.lauch;


            }
            else if (index <= 6)
            {
                atual = actions.Punch;
    

             }
         
            time_elapsed_ac = 0;
            canAC = false;
        }
       
    }

    void color_damaged()
    {
        if (this.damaged) GetComponentInChildren<SpriteRenderer>().color = Color.red;
        else GetComponentInChildren<SpriteRenderer>().color = Color.white;

        if ((this.time_damaged_elapsed >= this.time_damaged) && this.damaged)
        {
            damaged = false;
            this.time_damaged_elapsed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player_su" || collision.gameObject.tag == "player_su_put" || collision.gameObject.tag == "player_su_mat"
           || collision.gameObject.tag == "player_su_life" || collision.gameObject.tag == "Player")
        {
            life -= 50;
            damaged = true;
            time_damaged_elapsed = 0;
            if (collision.gameObject.tag != "Player")
            {
                Destroy(collision.gameObject);

            
             }
    }
    }


}
