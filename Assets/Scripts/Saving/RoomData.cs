
[System.Serializable]
public class LevelData
{
    public bool[] levels = new bool[15] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    public int[] stars = new int[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
}

[System.Serializable]
public class RoomData
{
    public LevelData[] levelDatas;
    //For Multiple Rooms
    public int[] prices = { 0, 40000, 40000, 50000, 50000, 50000 } ;
    public bool[] room = new bool[] { true, false, false, false, false, false } ;
}
