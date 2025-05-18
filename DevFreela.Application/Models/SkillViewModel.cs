public class SkillViewModel
{
    public SkillViewModel(int id, string skill)
    {
        Id = id;
        Skill = skill;
    }

    public int Id { get; set; }
    public string Skill { get; set; }

    public static List<SkillViewModel> ToListSkillViewModel(List<(int, string)> listTuple)
    {
        var skillsMapped = new List<SkillViewModel>();

        foreach (var (id, skill) in listTuple)
        {
            skillsMapped.Add(new SkillViewModel(id, skill));
        }

        return skillsMapped;
    }
}
