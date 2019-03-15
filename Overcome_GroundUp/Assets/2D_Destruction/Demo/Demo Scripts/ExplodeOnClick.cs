using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour {

	private Explodable _explodable;
    public parentExplode parentObject;

	void Start()
	{
		_explodable = GetComponent<Explodable>();
	}
	void OnMouseDown()
	{
	//	_explodable.explode();
		//ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
		//ef.doExplosion(transform.position);
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parentObject.isExplode = true;
            StartCoroutine(waitExplode());

        }
    }

    public IEnumerator waitExplode()
    {
        yield return new WaitForSeconds(0.01f);
        _explodable.explode();
        ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
        ef.doExplosion(transform.position);

    }
}
