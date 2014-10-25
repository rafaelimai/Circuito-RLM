using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManjubatorTools : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static bool Compare(List<string> list1, List<string> list2) {
		bool answer = true; // Beneficio da duvida
		for (int i = 0; i < list1.Capacity; i ++) {
			if (list1[i] != list2[i]) {
				answer = false;
			}
		}
		return(answer);
	}
}
