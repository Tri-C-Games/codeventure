using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.IO;

public class Interpreter:MonoBehaviour
{
	[SerializeField]
	private Dictionary<string, float> variables=new Dictionary<string, float>();
	private string code;
	private string[] lines;
	string fileName = @"Assets\Scripts\Lang\main.owo";

	void Start()
	{
			code = File.ReadAllText(fileName);
			lines = SeparateLines(code);
			foreach (var line in lines)
			{
				ParseLine(line);
			}
			Debug.Log(variables);
		}


		string[] SeparateLines(string _code)
		{
			string[] _lines = Regex.Split(_code, ";");
			Debug.Log(_lines[0]);
			for (int i = 0; i < _lines.Length; i++)
			{
				_lines[i] = Regex.Replace(_lines[i], ";| |\n\r|\n|\r", string.Empty);
				Debug.Log(_lines[i]);
			}
			return _lines;
		}

		void ParseLine(string _line)
		{
			if (_line.ToLower().IndexOf('=') != -1)
			{
				string _key;
				string _value;
				string[] _split = Regex.Split(_line,"=");
				_key = _split[0];
				_value = _split[1];
				Debug.Log(_key);
				if (variables.ContainsKey(_key))
				{
					variables[_key] = float.Parse(_value);
				}
				else
				{
					variables.Add(_key, float.Parse(_value));
				}
				Debug.Log("Var: " + _key + "" + variables[_key]);
			}
		}
}
