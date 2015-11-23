using UnityEngine;
using System.Collections;

public class VidaNormal : MonoBehaviour, IEstadoVida{
	
	public void estadoVida()
	{
		print ("normal");
		GameObject.Find("cube").AddComponent<Renderer>().material.color = Color.green;
	}
}
