using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AcoesDosBotoes : MonoBehaviour {

	static List<GameObject> ListaCubos = new List<GameObject> ();

	public void InstanciarCuboUnico(){
		GameObject CuboUnico = Instantiate (Resources.Load ("Cubo(singleton)", typeof(GameObject))) as GameObject;
		Singleton.ObterInstancia (CuboUnico);
		ListaCubos.Add (CuboUnico);
	}

	public void InstanciarCuboComum(){
		GameObject CuboComum = Instantiate (Resources.Load ("Cubo(singleton)", typeof(GameObject))) as GameObject;
		ListaCubos.Add (CuboComum);
	}

	public void DestruirTodos(){
		foreach(GameObject cubo in ListaCubos){//Para cada cubo presente na lista de cubos
			Destroy(cubo);//Destroi um cubo
		}
		ListaCubos.Clear();//Remove todos os elementos da lista.
	}

	public void MudarDeCena(){
		switch (Application.loadedLevelName) {
			case "CenaSingleton1":
				Application.LoadLevel("CenaSingleton2");
			break;
			case "CenaSingleton2":
				Application.LoadLevel("CenaSingleton1");
			break;

		}
	}
}
