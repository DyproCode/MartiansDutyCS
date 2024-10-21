namespace MartiansDutyCS.scripts.Items;

public interface IItem
{
    void BuildItem();
    void BuildName();
    void BuildDescription();
    void BuildTexture();
    void BuildTriggers();
    Item GetItem();
}