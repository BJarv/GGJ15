function Update () { 
	GetComponent.<Renderer>().material.SetFloat("_Cutoff", transform.parent.transform.parent.GetComponent("sketchCat").timer / transform.parent.transform.parent.GetComponent("sketchCat").dealTime);
	GetComponent.<Renderer>().sortingLayerName = "Player";
}