using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowBehaviour : MonoBehaviour {

		void OnCollisionEnter (Collision col)
		{
				if(col.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
				{
						this.gameObject.GetComponent<Animator> ().SetBool ("ColidedPlayer", true);
				}
		}
}
