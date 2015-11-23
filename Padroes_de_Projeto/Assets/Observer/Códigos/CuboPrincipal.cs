using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CuboPrincipal : MonoBehaviour, IObjetoObservado{

	private Rigidbody rb;
	private Animator animar;
	private float velocidadePulo;
	private bool estaNoChao;
	private RaycastHit rayChao;
	private bool mudou;

	void Awake () {
		estaNoChao = false;
		velocidadePulo = 10;
		rb = GetComponent<Rigidbody> ();
		animar = GetComponent<Animator> ();
	}

	void Update () {

		//detecta se esta no chao
		if (Physics.Raycast(transform.position, -transform.up, out rayChao,1.1f)) {
			if(rayChao.collider.gameObject.tag == "Chao")
			{
				estaNoChao = true;
			}
		}
		else{
			estaNoChao = false;
		}

		//comando para pular (animaçao e movimento)
		if (Input.GetKeyDown (KeyCode.Space) && estaNoChao) {
			rb.velocity += velocidadePulo * Vector3.up;
			animar.SetTrigger("puloSubir");
		}

		//comando para cair (animaçao e movimento)
		if(!estaNoChao && rb.velocity.y < 0) {
			rb.velocity -= velocidadePulo * Vector3.up;
			if(rb.velocity.y <= -40){
				rb.velocity = new Vector3(0,-30,0);
			}
			if (Physics.Raycast(transform.position, -transform.up, 1.7f)){
				animar.SetTrigger("puloCair");

				AtualizaObservador("pulou");
			}
		}

		//comando para andar (animaçao e movimento)
		if (Input.GetKey (KeyCode.W)) {
			rb.transform.Translate (-10 * Time.deltaTime, 0, 0);
			animar.SetBool ("andar", true);
			AtualizaObservador("andou");

		} else {
			animar.SetBool("andar",false);
		}
		//comando para rotacionar
		if (Input.GetKey (KeyCode.A)) {
			rb.transform.Rotate (0, -110 * Time.deltaTime, 0);
		}
		if (Input.GetKey(KeyCode.D)) {
			rb.transform.Rotate(0,110* Time.deltaTime,0);
		}
		AtualizaObservador("nada");

	}

	//Lista de Objetos Obervadores
	List<IObjetoObservador> observadores = new List<IObjetoObservador>();
	
	//adiciona Objetos
	public void Subscribe(IObjetoObservador obs){
		
		observadores.Add(obs);
		
	}

	//Atualizaçao de Objetos
	public void AtualizaObservador(string OqueMudou){
		foreach (IObjetoObservador o in observadores){
			
			o.MudancaObservador(OqueMudou);
		}
	}
}
