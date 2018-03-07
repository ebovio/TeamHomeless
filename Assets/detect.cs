using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect : MonoBehaviour {

    // Materials

    public Material notLooking;
    public Material looking;

    private int tiempostart;
	private int bandera;

    public Character player;

    public GameObject phone;
    public GameObject mailPapers;

	void Start(){
		tiempostart = 0;
		bandera = 0;
        GetComponent<Renderer>().material = notLooking;
    }

	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Vector3 distancia = transform.TransformDirection (Vector3.forward) * 10;

		if(Physics.Raycast(transform.position,(distancia),out hit)){
			Debug.DrawLine (transform.position,distancia,Color.red);

        }
        else{
			Debug.DrawLine (transform.position,distancia,Color.green);
			bandera = 0;
		}
	}

    public bool waitingTime(int wait)
    {
        if (bandera == 0)
        {
            tiempostart = (int)Time.realtimeSinceStartup;
            bandera = 1;
        }

        if ((tiempostart + wait) <= (int)Time.realtimeSinceStartup)
        {
            return true;
        }
        return false;
    }

    public void objectBeingWatched()
    {
        GetComponent<Renderer>().material = looking;
    }

    public void objectNotBeingWatched()
    {
        GetComponent<Renderer>().material = notLooking;
    }
}
