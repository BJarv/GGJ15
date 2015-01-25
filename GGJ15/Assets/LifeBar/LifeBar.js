function Update () { 
	renderer.material.SetFloat("_Cutoff", transform.parent.transform.parent.GetComponent("sketchCat").timer / transform.parent.transform.parent.GetComponent("sketchCat").dealTime); 
}