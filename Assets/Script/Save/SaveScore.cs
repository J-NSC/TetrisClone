using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveScore 
{
    public static void saveData(DataScore data){
         BinaryFormatter formatter = new BinaryFormatter();
         string path = Application.persistentDataPath + "/savioGay.data";
         FileStream stream = new FileStream(path ,FileMode.Create);

         formatter.Serialize(stream, data);
    }
}
