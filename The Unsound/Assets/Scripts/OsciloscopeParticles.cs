using UnityEngine;

public class OsciloscopeParticles : MonoBehaviour {

	public int resolution = 50;

	private int currentResolution;
	private ParticleSystem.Particle[] points;
	private ParticleSystem p;

	public float amplitude;
	public float frequency;

	private Vector2 borderSize;

	void Start(){
		p = gameObject.GetComponent<ParticleSystem> ();
		amplitude = 1;
		frequency = 2;
		borderSize = gameObject.GetComponentInParent<BoxCollider2D> ().size;
	}

	private void CreatePoints () {
		currentResolution = resolution * (int)amplitude;
		points = new ParticleSystem.Particle[resolution];
		float increment = (borderSize.x) / (resolution - 1);
		//resolution = (int)(borderSize.x/0.1f) - 1;
		//float increment = resolution;
		for(int i = 0; i < resolution; i++){
			float x = i * increment;
			points[i].position = new Vector3(x - (borderSize.x/2), 0f, 0f);
			points[i].color = new Color(x, 0f, 0f);
			points[i].size = 0.1f;
		}
	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.UpArrow)){
			amplitude+=0.5f;
			CreatePoints();
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			amplitude-=0.5f;
			CreatePoints();
		}
		if(Input.GetKeyDown(KeyCode.A)){
			frequency-=0.5f;
			CreatePoints();
		}
		if(Input.GetKeyDown(KeyCode.D)){
			frequency+=0.5f;
			CreatePoints();
		}

		if (currentResolution != resolution || points == null) {
			CreatePoints();
		}

		for (int i = 0; i < resolution; i++) {
			Vector3 p = points[i].position;
			//p.z = Sine(p.x);
			p.z = 0;
			points[i].position = p;
			Color c = points[i].color;
			c.g = p.z;
			points[i].color = c;
		}
		p.SetParticles(points, points.Length);
	}

	private float Sine (float x){
		return amplitude * Mathf.Sin(2 * Mathf.PI * x);
	}
}





