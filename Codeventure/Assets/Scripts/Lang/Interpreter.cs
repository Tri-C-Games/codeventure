using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.IO;
using System.Globalization;

public class Interpreter:MonoBehaviour
{
	CultureInfo ci = CultureInfo.InvariantCulture;
	public Dictionary<string, float> variables;
	private string code;
	private string[] lines;
	string fileName = @"Assets\Scripts\Lang\main.owo";

	void Start()
	{
		variables = new Dictionary<string, float>();
		code = File.ReadAllText(fileName);
			lines = SeparateLines(code);
			foreach (var line in lines)
			{
				ParseLine(line);
			}
		foreach( var item in variables){
			Debug.Log(item);
			}
		}


		string[] SeparateLines(string _code)
		{
			string[] _lines = Regex.Split(_code, ";");
			for (int i = 0; i < _lines.Length; i++)
			{
				_lines[i] = Regex.Replace(_lines[i], " |\n\r|\n|\r", string.Empty);
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
				Debug.Log(float.Parse(_value));
				
				if (variables.ContainsKey(_key))
				{
					variables[_key] = float.Parse(_value, ci);
				}
				else
				{
					variables.Add(_key, float.Parse(_value, ci));
				}
			}
		}
}
