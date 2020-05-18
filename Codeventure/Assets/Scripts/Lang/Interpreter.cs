using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using UnityEngine;

public class Interpreter:MonoBehaviour
	{
		public Dictionary<string, float> variables;
		public string code;
		public string[] lines;
		void Start()
		{
			code = "life = 42.0;";
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
			Debug.Log(lines[0]);
			for (int i = 0; i < _lines.Length; i++)
			{
				lines[i] = Regex.Replace(_lines[i], ";| |\n\r|\n|\r", string.Empty);
				Debug.Log(lines[i]);
			}
			return _lines;
		}

		void ParseLine(string _line)
		{
			if (_line.ToLower().IndexOf('=') != -1)
			{
				string _key;
				string _value;
				string[] _split = _line.Split('=');
				_key = _split[0];
				_value = _split[1];
				if (variables.TryGetValue(_key, out float _current))
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
