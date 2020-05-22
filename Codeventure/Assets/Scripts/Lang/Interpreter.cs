using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

public class Interpreter : MonoBehaviour
{
    CultureInfo ci = CultureInfo.InvariantCulture;
    public Dictionary<string, dynamic> variables;
    private string code;
    private string[] lines;
    readonly string fileName = @"Assets\Scripts\Lang\main.owo";

    void Start()
    {
        variables = new Dictionary<string, dynamic>();
        code = File.ReadAllText(fileName);
        lines = SeparateLines(code);
        foreach (var line in lines)
        {
            ParseLine(line);
        }

        // Output each key and value in the variables dictionary
        foreach (var item in variables)
        {
            Debug.Log(item);
        }
    }

    void PRINT(string text)
    {
        Debug.Log(text);
    }

    string[] SeparateLines(string _code)
    {
        string[] _lines = Regex.Split(_code,";");
        for (int i = 0; i < _lines.Length; i++)
        {
            // Remove all line breaks
            _lines[i] = Regex.Replace(lines[i],"\n\r|\n|\r", string.Empty);
        }
        return _lines;
    }

    void ParseLine(string _line)
    {
        // Variable assignment
        if (_line.Contains("="))
        {
            string _key;
            string _value;
            string[] _split = Regex.Split(_line,"=");
            _key = _split[0].Trim(' ', '\t');
            _value = _split[1].Trim(' ', '\t');
			if (ParseExpressions(_value,out string _output))
			{
				AddVariable(_key, _output);
			}
			else
			{
				AddVariable(_key, _value);
			}
        }
        // Statements (If/Methods/Loops)
        else if (_line.Contains("(") && _line.Contains(")"))
        {
            string _func;
            string _args;
            string[] _split = _line.Split('(');
            _func = _split[0];
            _args = _split[1];
            _args = _args.Replace(")", string.Empty);
            Debug.Log(float.Parse(_args));
        }
    }
	//this parses mathematical operations and variable value uses 
	bool ParseExpressions(string _expression, out string results)
	{
        if (variables.TryGetValue(_expression, out dynamic _value))
		{
			//it tries to parse, if this operation succeeds, it returns the value
			results = _value;
			return true;
		}
		else
		{
			//or else it returns the previous value
			results = _expression;
			return true;
		} 
	}

    void AddVariable(string _key, string _value)
    {
        // TODO: Fix this bug - `pleasefix = "this""should""not""work";` - As the variable's value suggests, this should not work.

        // Throw an error if the variable name has spaces in it
        if (_key.Contains(" "))
        {
            ThrowError();
            return;
        }

        dynamic parsedValue;

        // Strings
        if (_value[0] == '"' && _value[_value.Length - 1] == '"')
        {
            _value = _value.Substring(1, _value.Length - 2);
            parsedValue = _value;
        }
        // Numbers
        else if (double.TryParse(_value, out double _resultString))
        {
            parsedValue = _resultString;
        }
        // Booleans (True/False)
        else if (bool.TryParse(_value, out bool _resultBool))
        {
            parsedValue = _resultBool;
        }
        else if (_value.ToLower() == "none")
        {
            parsedValue = null;
        }
        // TODO: Assigning methods to variables (now relocated to ParseExpression)
        // Otherwise - Handle errors
        else
        {
            ThrowError();
            return;
        }

        // Add the variable to the variables dictionary. If the variable does not already exist it will add it automatically.
        variables[_key] = parsedValue;
    }

    void ThrowError()
    {
        // TODO: Error handling
    }
}