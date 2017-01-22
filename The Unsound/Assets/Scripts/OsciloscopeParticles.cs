using UnityEngine;
using System.Collections;

public class OsciloscopeParticles : MonoBehaviour {

	private ParticleSystem.Particle[] points;
	private ParticleSystem p;

	private ParticleSystem.Particle[] enemyPoints;
	public ParticleSystem enemyP;

	public GameObject sliderHP;

	private float amplitude;
	private float frequency;

	private float enemyAmplitude;
	private float enemyFrequency;

	private int nBolitas = 500;// ulises 
	private float increment;
	private float deltaMovement = 0;

	private int bolitasEnemigos = 0;

	private float hp = 1;

	private float matches;

	private Vector2 borderSize;

	private bool enemyActive = false;

	void Start(){
		p = gameObject.GetComponent<ParticleSystem> ();	//Agarra el ParticleSystem del objeto
		amplitude = 0.1f;	//Amplitud Default
		frequency = 2f;		//Frecuencia default
		borderSize = gameObject.GetComponentInParent<BoxCollider2D> ().size;	//Consigue el tamaño del collider paa usar como guia
		increment = borderSize.x / nBolitas; //Delta x porque son 500 bolitas entre el tamaño del rectangulo
		points = new ParticleSystem.Particle[nBolitas];	//Arreglo de particulas para el ParticleSystem
		CreatePoints();	//Crea los puntos

		//Enemy

		enemyPoints = new ParticleSystem.Particle[nBolitas];
	}

	private void CreatePoints () {
		
		for (int i = 0; i < nBolitas; i++) {	//Recorre todas las bolitas
			points [i].position = new Vector3 (increment*i - borderSize.x/2, 0f, funcionFeliz(increment*i));	//Les asigna su pos en x y z because reasons
			points [i].startColor = new Color(0,0,0);	//Color de las particulas
			points [i].startSize = 0.05f;	//Tamaño de las particulas
		}

	}

	private void EnemyCreatePoints() {
		for (int i = 0; i < nBolitas; i++) {	//Recorre todas las bolitas
			enemyPoints [i].position = new Vector3 (increment*i - borderSize.x/2, 0f, funcionTriste(increment*i));	//Les asigna su pos en x y z because reasons
			enemyPoints [i].startColor = new Color(0.36f,0.53f,0.77f);	//Color de las particulas
			enemyPoints [i].startSize = 0.05f;	//Tamaño de las particulas
		}
	}

	private float funcionFeliz(float x){

		x = (x + (borderSize.x / 2)) / (borderSize.x); //Normalizacion

		x += deltaMovement;	//Para que se mueva la funcion

		x *= Mathf.PI * 2; //x*2pi

		x = amplitude * Mathf.Sin(frequency * x); //Regresa el valor de la funciom en "y"

		return x;
	}

	private float funcionTriste(float x){

		x = (x + (borderSize.x / 2)) / (borderSize.x); //Normalizacion

		x += deltaMovement;	//Para que se mueva la funcion

		x *= Mathf.PI * 2; //x*2pi

		x = enemyAmplitude * Mathf.Sin(enemyFrequency * x); //Regresa el valor de la funciom en "y"

		return x;
	}

	void Update () {

		deltaMovement += 0.01f;	//Aumenta para que se mueva la linea
		
		CreatePoints ();	//Manda a reposicionar los puntos

		p.SetParticles(points, points.Length);	//Crea el sistema de particulas con el arreglo

		if (enemyActive) {
			EnemyCreatePoints ();
		}

		enemyP.SetParticles (enemyPoints, bolitasEnemigos);

		//Input de para cambiar la frecuencia y amplitud
		if(Input.GetKey(KeyCode.UpArrow) && amplitude <= borderSize.y/2){
			amplitude += 0.01f;
		}
		if(Input.GetKey(KeyCode.DownArrow) && amplitude > 0){
			amplitude -= 0.01f;
		}
		if(Input.GetKey(KeyCode.LeftArrow) && frequency > 1){
			frequency -= 0.05f;
		} 
		if(Input.GetKey(KeyCode.RightArrow) && frequency < 20){
			frequency += 0.05f;
		}

		if(frequency + 0.005 > enemyFrequency && frequency - 0.005 < enemyFrequency){
			if(amplitude + 0.05 > enemyAmplitude && amplitude - 0.05 < enemyAmplitude){
				if (enemyActive) {
					matches++;
				}

			}
		}

		if(matches >= 30 && enemyActive){
			delEnemy ();
			GameManager.Instance.enemyDead ();
		}

		//print (matches);

		//print ("Frecuencia: " + frequency + " frecuencia enemiga: " + enemyFrequency);
		//print ("Amplitud: " + amplitude + " amplitud enemiga: " + enemyAmplitude);
			
	}

	public void newEnemy(){
		StopCoroutine ("FadeWave");
		StopCoroutine ("ResetTimer");
		StartCoroutine ("NewWave");
		StartCoroutine ("StartTimer");
		enemyActive = true;
		enemyAmplitude = Random.Range (0.05f, borderSize.y/2);
		enemyFrequency = Random.Range (1, 10);

	}

	public void delEnemy(){
		enemyActive = false;
		StopCoroutine ("NewWave");
		StopCoroutine ("StartTimer");
		StartCoroutine("FadeWave");
		StartCoroutine ("ResetTimer");
		matches = 0;
	}
		
	IEnumerator FadeWave() {
		for (int i = 0; i <= 50; i++) {
			yield return new WaitForSeconds (0.01f);
			bolitasEnemigos-=10;
		}
		bolitasEnemigos = 0;
	}

	IEnumerator NewWave() {
		for (int i = 0; i <= 50; i++) {
			yield return new WaitForSeconds (0.01f);
			bolitasEnemigos+=10;
		}
		bolitasEnemigos = 500;
	}

	IEnumerator StartTimer(){
		for (float i = hp; i >= 0; i-=0.01f) {
			yield return new WaitForSeconds (0.5f);
			hp = i;
			sliderHP.transform.localScale = new Vector3(hp, 1, 1);
		}
	}

	IEnumerator ResetTimer(){
		for (float i = hp; i <= 1; i+=0.05f) {
			yield return new WaitForSeconds (0.5f);
			hp = i;
			sliderHP.transform.localScale = new Vector3(hp, 1, 1);
		}
		hp = 1;
		sliderHP.transform.localScale = new Vector3(hp, 1, 1);
	}


}

