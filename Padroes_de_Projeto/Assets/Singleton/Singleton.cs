using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour{
	private static GameObject instancia;

	public static GameObject ObterInstancia(GameObject g){
		if (instancia == null) {
			instancia = g;
			DontDestroyOnLoad (g);
		} else if(instancia != g){
			GameObject.Destroy(g);
		}
		return instancia;
	}
}
