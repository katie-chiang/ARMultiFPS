using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ParticleBulletSystem
{
public class playerHealthScript : NetworkBehaviour {

	[SyncVar]
	public int health = 5;

	// Use this for initialization
	void Start () {
		CmdInitHealth();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[Command]
	void CmdInitHealth(){
		health = 5;
	}
}
}
