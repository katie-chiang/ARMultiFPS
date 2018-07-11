using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



//script to keep track of the gameobjects hit by the particles
public class particleCollision : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}	//When OnParticleCollision is invoked from a script attached to a ParticleSystem, 
	//the GameObject parameter represents a GameObject with an attached Collider struck by the ParticleSystem.
	public void OnParticleCollision(GameObject other)
	{	
		//add isServer and spawn particle manager with client authority
		//tell server to decrement the health of the player
		//Debug.Log("HIT COLLISION ENTER!!!!!!!!!");
		Debug.Log("HIT COLLISION IN PARTICLE -> the object hit is: " + other.name);

		NetworkInstanceId id = other.GetComponent<NetworkIdentity>().netId;
		Debug.Log("hit network id: " + id.ToString());
		CmdPlayerHit(id);


	}

	[Command]
	public void CmdPlayerHit(NetworkInstanceId idhit){
		GameObject hitObject = NetworkServer.FindLocalObject(idhit);
		if(hitObject != null){
			Debug.Log("CmdPlayerHit object: " + hitObject.name);
			//decrement the health of the player that was hit
			hitObject.GetComponent<ParticleBulletSystem.playerHealthScript>().health--;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
