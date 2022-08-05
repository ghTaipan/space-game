using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevel(int level){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/levelData";
        FileStream stream = new FileStream(path,FileMode.Create);
        formatter.Serialize(stream,level);
        stream.Close();
    }
    public static int LoadLevel(){
        string path = Application.persistentDataPath + "/levelData";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            int level = (int) formatter.Deserialize(stream);
            stream.Close();
            return level;
        }
        else{
            SaveLevel(0);
            return -1;
        }
    }
    public static void SaveAudio(VolumeSettings AudioSettings){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+ "/AudioData";
        FileStream stream = new FileStream(path,FileMode.Create);
        AudioData data = new AudioData(AudioSettings);
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static AudioData LoadAudio(){
        string path = Application.persistentDataPath + "/AudioData";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            AudioData audioData = formatter.Deserialize(stream) as AudioData;
            stream.Close();
            return audioData;
        }
        else{
            return null;
        }
    }
}
