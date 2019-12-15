using System.Collections.Generic;

[System.Serializable]
public class Score {

    public Score(string pname, int points, float time) {
        this.playerName = pname;
        this.points = points;
        this.time = time;
    }

    public string playerName;
    public int points;
    public float time;
}

[System.Serializable]
public class HScore {
    public Score[]  scoreList;
}

public class ScoreEQC : IEqualityComparer<Score> {
    public bool Equals(Score s1, Score s2) {
        if (s1.playerName == s2.playerName && s1.points == s2.points && s1.time == s2.time)
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
        return x.time.CompareTo(y.time);
    }
}