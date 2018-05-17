using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReceiveDamage : MonoBehaviour {

	public int Health_Points = 5;
	public LoseMessage lose;
	public Transform player;
	private float last_damage = 0.0f; 
	public TransparencyScript transparency;
	public float damage_time_interval=0.5f;
	public float healing_time_interval=3.0f;
    private bool hasDiedBefore = false;

	public void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag.Equals("Cutable") && last_damage<=UnityEngine.Time.time-damage_time_interval) {
			Health_Points--;
			NavMeshAgent nav = collision.gameObject.GetComponent<NavMeshAgent> ();
			nav.SetDestination (new Vector3(-player.position.x,player.position.y,-player.position.z));
			last_damage = UnityEngine.Time.time;
			transparency.Invoke ("DecreaseTransparency", 0.1f);
		}
	}

	public void FixedUpdate(){
        float time = UnityEngine.Time.time;

        if (Health_Points <= 0 && !hasDiedBefore)
        {
            lose.Invoke("Player_lose", 1);
            hasDiedBefore = true;
        }

        if (last_damage <= time-healing_time_interval && Health_Points < 5){
            last_damage = time;
			transparency.Invoke ("IncreaseTransparency", 0.1f);
            Health_Points++;
        }
    }
}
