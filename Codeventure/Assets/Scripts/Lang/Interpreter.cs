using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.IO;
using System.Globalization;
using System.Linq;

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
            string[] _split = Regex.Split(_line, "=");
            _key = _split[0];
            _value = _split[1];
            //TODO: Parse expressions
            Var(_key, _value);
        }
        else if (_line.ToLower().IndexOf('(') != -1 && _line.ToLower().IndexOf(')') != -1)
        {
            string _func;
            string _args;
            string[] _split = Regex.Split(_line, "(");
            _func = _split[0];
            _args = _split[1];
            _args = Regex.Replace(_args, ")", string.Empty);
            Debug.Log(float.Parse(_args));
        }
    }

    void Var(string _key, string _value)
    {
        dynamic parsedValue;
        double _result;
        /*if (_value.Count(c => c == '"') > 1) // I replaced TakeWhile with Count (TakeWhile skips the rest so will not have a count greater than one).
        {
            _value = _value.Trim('"');
            parsedValue = _value;
        }*/ // Remove this comment block after you've read it. This does not work for strings such as """, "b"" and ""l" as Trim removes the leading and trailing characters (I feel like it will also break for some other variables but I haven't tested them yet e.g. hello""hi).
        if (_value[0] == '"' && _value[_value.Length - 1] == '"')
        {
            _value = _value.Substring(1, _value.Length - 2);
            parsedValue = _value;
        }
        else if (double.TryParse(_value, out _result))
        {
            parsedValue = _result;
        }
        else
        {
            return; //TODO: Error handling
        }

        if (variables.ContainsKey(_key))
        {
            variables[_key] = parsedValue;
        }
        else
        {
            variables.Add(_key, parsedValue);
        }
        return;
    }
}