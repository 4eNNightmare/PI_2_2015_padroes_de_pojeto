using UnityEngine;
using System.Collections;

public class AtribuindoDano : MonoBehaviour {

	public IEstadoVida estado;
	public int vida;
    void Start()
    {
        
        vida = 100;
		estado = GetComponent<VidaNormal>();
		                                   }

    void Update()
    {
        if ((vida < 50) && (vida > 25))
        {
				estado = GetComponent<VidaCritica>();
		}
        if (vida <= 25)
        {
				estado = GetComponent<VidaSuperCritica>();
		}
    } 
}
