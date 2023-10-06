using System;
using System.Configuration;

public class DataAccesHelper
{

    public static string CNNString(string name)
    {
        return ConfigurationManager.ConnectionStrings[name].ConnectionString;
    }
}
