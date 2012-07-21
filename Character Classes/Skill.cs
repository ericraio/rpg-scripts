public class Skill : ModifiedStat {
  private bool _known;

  public Skill() {
    _known = false;
    ExpToLevel = 25;
    LevelModifier = 1.1f;
  }

  public bool Known {
    get{ return _known; }
    set{ _known = value; }
  }
}

public enum SkillName {
  Melee_Offense,
  Melee_Defense,
  Ranged_Offense,
  Ranged_Defense,
  Magic_Offense,
  Magic_Defense
}
