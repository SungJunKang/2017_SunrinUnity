using System;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable] // 클래스를 파일로 저장할 수 있게 자를 수 있는 객체로 만들래요
public class dataClass {
    public string playerName;
    public float time;
    public float boxCount;

    public dataClass(string _name, float _time, float _count){
        playerName = _name;
        time = _time;
        boxCount = _count;
    }
}
