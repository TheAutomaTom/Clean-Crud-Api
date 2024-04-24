namespace ZZ.XXX.Tests.EndToEnd.Config
{
  internal class AppSettingsWriter
  {
    readonly string _testProjectPath;
    public AppSettingsWriter(string testProjectPath)
    {
      _testProjectPath = testProjectPath;
    }

    internal void AddOrUpdateAppSetting(string env, string key, string value)
    {
      try
      {
        var filePath = Path.Combine(_testProjectPath, $"appsettings.{env}.json");

        string text = File.ReadAllText(filePath);

        var csStart = text.IndexOf(key) + key.Length + 4;
        var csEnd = text.IndexOf('\"', csStart + 3);

        var resultStart = text.Substring(0, text.IndexOf(key) + key.Length + 4);
        var resultEnd = text.Substring(csEnd, text.Length - csEnd);

        var result = $"{resultStart}{value}{resultEnd}";

        File.WriteAllText(filePath, result);

      }
      catch (Exception ex)
      {
        Console.WriteLine("Error writing app settings | {0}", ex.Message);
      }
    }

    //static void _setValueRecursively<T>(string sectionPathKey, dynamic jsonObj, T value)
    //{
    //  // split the string at the first ':' character
    //  var remainingSections = sectionPathKey.Split(":", 2);

    //  var currentSection = remainingSections[0];
    //  if (remainingSections.Length > 1)
    //  {
    //    // continue with the process, moving down the tree
    //    var nextSection = remainingSections[1];
    //    _setValueRecursively(nextSection, jsonObj[currentSection], value);
    //  }
    //  else
    //  {
    //    // we've got to the end of the tree, set the value
    //    jsonObj[currentSection] = value;
    //  }
    //}

    //static void _setServerIpAddress(dynamic json, string key, string value, int iteration = 0)
    //{
    //  // `key` Example: "ConnectionStrings:GeneralDb"
    //  // split the key string at the first ':' character
    //  var keyPaths = key.Split(":", 2);


    //  var current = keyPath[0];
    //  if (keyPath.Length > 1)
    //  {
    //    // continue with the process, moving down the tree
    //    var next = keyPath[1];
    //    _setServerIpAddress(next, json[current], value);
    //  }
    //  else
    //  {
    //    // we've got to the end of the tree, set the value
    //    json[current] = value;
    //  }
    //}


  }
}
