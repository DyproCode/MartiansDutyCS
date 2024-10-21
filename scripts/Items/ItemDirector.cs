namespace MartiansDutyCS.scripts.Items;

public class ItemDirector
{
    public Item BuildItem(IItem builder)
    {
        builder.BuildItem();
        builder.BuildDescription();
        builder.BuildName();
        builder.BuildTexture();
        builder.BuildTriggers();
        
        return builder.GetItem();
    }
}