using UnityEngine;
using System.Collections;

public class VidaSuperCritica : MonoBehaviour, IEstadoVida{

	public void estadoVida()
	{
		print ("supercritica");
		GameObject.Find("cube").AddComponent<Renderer>().material.color = Color.red;
	}
}