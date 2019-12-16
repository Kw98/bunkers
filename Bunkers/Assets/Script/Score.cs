using System.Collections.Generic;

[System.Serializable]
public class Score {

    public Score(string pname, int points, int day, float hour, float min) {
        this.playerName = pname;
        this.points = points;
        this.day = day;
        this.hour = hour;
        this.min = min;
    }

    public string playerName;
    public int points;
    public int day;
    public float hour;
    public float min;
}

[System.Serializable]
public class HScore {
    public Score[]  scoreList;
}

public class ScoreEQC : IEqualityComparer<Score> {
    public bool Equals(Score s1, Score s2) {
        if (s1.playerName == s2.playerName && s1.points == s2.points && s1.day == s2.day && s1.hour == s2.hour && s1.min == s2.min)
            return true;
        return false;
    }

    public int GetHashCode(Score sc) {
        return 1;
    }
}

public class ScorePointsComparer : IComparer<Score> {
    public int Compare(Score x, Score y) {
        return x.points.CompareTo(y.points);
    }
}

public class ScoreTimeComparer : IComparer<Score> {
    public int Compare(Score x, Score y) {
        if (x.day < y.day)
            return 1;
        else if (x.day > y.day)
            return -1;
        else {
            if (x.hour < y.hour)
                return 1;
            else if (x.hour > y.hour)
                return -1;
            else
                return -x.min.CompareTo(y.min);
        }
    }
}