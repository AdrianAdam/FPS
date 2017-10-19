function Update () {
	if (Input.GetKeyDown("f"))
	{
		if (GetComponent.<Light>().enabled == true)
			GetComponent.<Light>().enabled = false;
		else GetComponent.<Light>().enabled = true;
	}
}
