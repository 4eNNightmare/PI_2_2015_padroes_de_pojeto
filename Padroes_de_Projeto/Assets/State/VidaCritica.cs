using UnityEngine;
using System.Collections;

public class VidaCritica : MonoBehaviour, IEstadoVida{

	public void estadoVida()
	{
		print ("critica");
		GameObject.Find("cube").AddComponent<Renderer>().material.color = Color.yellow;
	}
}