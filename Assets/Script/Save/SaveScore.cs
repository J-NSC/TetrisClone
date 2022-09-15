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

    public static DataScore OpenData(){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savioGay.data";
        if(File.Exists(path)){
            FileStream stream = new FileStream(path ,FileMode.Open);

            DataScore paraRetornar =  formatter.Deserialize(stream) as DataScore;
            stream.Close();
            return paraRetornar;
        }else {
             return null;
        }

    }
}


