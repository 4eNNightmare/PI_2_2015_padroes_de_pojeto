using UnityEngine;
using System.Collections;

// IObjectObservable.cs

public interface IObjetoObservado{
	
	void Subscribe (IObjetoObservador obs);
	void AtualizaObservador(string OqueMudou);
	
}
