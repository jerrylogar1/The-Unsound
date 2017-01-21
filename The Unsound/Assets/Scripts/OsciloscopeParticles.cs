using UnityEngine;

public class OsciloscopeParticles : MonoBehaviour {

	private ParticleSystem.Particle[] points;
	private ParticleSystem p;

	public float amplitude;
	public float frequency;

	private int nBolitas = 1000;// ulises 
	private float increment;
	private float deltaMovement = 0;

	private Vector2 borderSize;

	void Start(){
		p = gameObject.GetComponent<ParticleSystem> ();	//Agarra el ParticleSystem del objeto
		amplitude = 0.1f;	//Amplitud Default
		frequency = 2f;		//Frecuencia default
		borderSize = gameObject.GetComponentInParent<BoxCollider2D> ().size;	//Consigue el tamaño del collider paa usar como guia
		increment = borderSize.x / nBolitas; //Delta x porque son 500 bolitas entre el tamaño del rectangulo
		points = new ParticleSystem.Particle[nBolitas];	//Arreglo de particulas para el ParticleSystem
		CreatePoints();	//Crea los puntos
	}

	private void CreatePoints () {
		
		for (int i = 0; i < nBolitas; i++) {	//Recorre todas las bolitas
			points [i].position = new Vector3 (increment*i - borderSize.x/2, 0f, funcionFeliz(increment*i));	//Les asigna su pos en x y z because reasons
			points [i].startColor = new Color(i,i,0f);	//Color de las particulas
			points [i].startSize = 0.1f;	//Tamaño de las particulas
		}
	}

	private float funcionFeliz(float x){

		x = (x + (borderSize.x / 2)) / (borderSize.x); //Normalizacion

		x += deltaMovement;	//Para que se mueva la funcion

		x *= Mathf.PI * 2; //x*2pi

		x = amplitude * Mathf.Sin(frequency * x); //Regresa el valor de la funciom en "y"

		return x;
	}

	void Update () {

		deltaMovement += 0.01f;	//Aumenta para que se mueva la linea

		if (deltaMovement >= 1 ){	//La resetea cuando llegua a 1
			deltaMovement = 0;
		}
		
		CreatePoints ();	//Manda a reposicionar los puntos

		p.SetParticles(points, points.Length);	//Crea el sistema de particulas con el arreglo

		//Input de para cambiar la frecuencia y amplitud
		if(Input.GetKey(KeyCode.UpArrow) && amplitude < borderSize.y/2){
			amplitude += 0.01f;
		}
		if(Input.GetKey(KeyCode.DownArrow) && amplitude > 0){
			amplitude -= 0.01f;
		}
		if(Input.GetKey(KeyCode.LeftArrow) && frequency > 0){
			frequency -= 0.1f;
		} 
		if(Input.GetKey(KeyCode.RightArrow) && frequency < 20){
			frequency += 0.1f;
		}
	}
}





