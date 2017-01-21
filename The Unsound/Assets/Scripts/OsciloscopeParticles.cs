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
		p = gameObject.GetComponent<ParticleSystem> ();
		amplitude = 0.1f;
		frequency = 2f;
		borderSize = gameObject.GetComponentInParent<BoxCollider2D> ().size;
		increment = borderSize.x / nBolitas; //Delta x porque son 500 bolitas entre el tamaño del rectangulo
		CreatePoints();
	}

	private void CreatePoints () {
		points = new ParticleSystem.Particle[nBolitas];
		for (int i = 0; i < nBolitas; i++) {
			points [i].position = new Vector3 (increment*i - borderSize.x/2, 0f,funcionFeliz(increment*i));

			points[i].color = new Color(i, 0f, 0f);
			points[i].size = 0.1f;
		}
	}

	private float funcionFeliz(float x){

		x = (x + (borderSize.x / 2)) / (borderSize.x);

		x += deltaMovement;

		x *= Mathf.PI * 2;

		x = amplitude * Mathf.Sin(frequency * x);

		return x;
	}

	void Update () {

		deltaMovement += 0.01f;

		if (deltaMovement >= 1 ){
			deltaMovement = 0;
		}
		
		CreatePoints ();

		p.SetParticles(points, points.Length);

		if(Input.GetKey(KeyCode.W) && amplitude < borderSize.y/2){
			amplitude+=0.01f;
			CreatePoints();
		}
		if(Input.GetKey(KeyCode.S) && amplitude > 0){
			amplitude-=0.01f;
			CreatePoints();
		}
		if(Input.GetKey(KeyCode.A)){
			frequency-=0.1f;
			CreatePoints();
		}
		if(Input.GetKey(KeyCode.D)){
			frequency+=0.1f;
			CreatePoints();
		}

	}

	private float Sine (float x){
		return amplitude * Mathf.Sin(2 * Mathf.PI * x);
	}
}





