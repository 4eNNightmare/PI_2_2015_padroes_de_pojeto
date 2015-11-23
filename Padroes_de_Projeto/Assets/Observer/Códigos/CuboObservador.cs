using UnityEngine;
using System.Collections;


public class CuboObservador: MonoBehaviour, IObjetoObservador{

	private Vector3 limiteMaiorEscala;
	private Vector3 limiteMenorEscala;
	
	void Awake(){
		limiteMaiorEscala = new Vector3 (7, 7, 7);
		limiteMenorEscala = new Vector3 (0.1f, 0.1f, 0.1f);

		GameObject.Find ("CuboPrincipal").GetComponent<CuboPrincipal> ().Subscribe (this);
	} 

	public void MudancaObservador(string atualizacao)
	{
		if (atualizacao == "pulou" && transform.lossyScale.y <= limiteMaiorEscala.y) {
			transform.localScale += new Vector3 (1, 1, 1);

		} else if (atualizacao == "andou" && transform.lossyScale.y >= limiteMenorEscala.y) {
			transform.localScale -= new Vector3 (0.6f*Time.deltaTime,0.6f*Time.deltaTime,0.6f*Time.deltaTime);
		}
	}
}