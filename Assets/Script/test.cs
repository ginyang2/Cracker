using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
	void Awake()
	{

		List<Dictionary<string, object>> data = CSVReader.Read("ItemData");

		for (var i = 0; i < data.Count; i++)
		{
			print("name " + data[i]["name"] + " " +
				   "age " + data[i]["age"] + " " +
				   "speed " + data[i]["speed"] + " " +
				   "desc " + data[i]["description"]);
		}

	}
}
