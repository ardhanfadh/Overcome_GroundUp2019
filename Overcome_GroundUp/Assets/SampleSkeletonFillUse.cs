using UnityEngine;
using System.Collections;
using Spine;
using Spine.Unity;

public class SampleSkeletonFillUse : MonoBehaviour {

	MeshRenderer meshRenderer;
	MaterialPropertyBlock block;
    public int Flashes;

	void Start () { // Start as a coroutine.
        if (Flashes == 0)
        {
            Flashes = 4;
        }
		meshRenderer = GetComponent<MeshRenderer>();

		block = new MaterialPropertyBlock();
		meshRenderer.SetPropertyBlock(block);
	}

	public IEnumerator FlashRoutine () {

		// You can use these instead of strings.
		int fillAlpha = Shader.PropertyToID("_FillAlpha");
		int fillColor = Shader.PropertyToID("_FillColor");

		for (int i = 0; i < Flashes; i++) {
			block.SetFloat(fillAlpha, 1f); // Make the fill opaque.

			block.SetColor(fillColor, Color.white); // Fill with white.
			meshRenderer.SetPropertyBlock(block);
			yield return null;

			block.SetColor(fillColor, new Color(0.8f, 0, 0)); // Fill with red.
			meshRenderer.SetPropertyBlock(block);
			yield return null;

			block.SetFloat(fillAlpha, 0f); // Remove the fill.
			meshRenderer.SetPropertyBlock(block);
			yield return null;
		}			
	}

    

}
