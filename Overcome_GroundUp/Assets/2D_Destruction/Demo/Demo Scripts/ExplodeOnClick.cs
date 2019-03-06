using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour {

	private Explodable _explodable;

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
            _explodable.explode();
            ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
            ef.doExplosion(transform.position);
            StartCoroutine(WaitDissapear());
        }
    }
    IEnumerator WaitDissapear()
    {
        yield return new WaitForSeconds(1);
    }
}
