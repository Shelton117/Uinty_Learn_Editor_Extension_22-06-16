namespace EditorFramework.Example.XMLGUI.Editor.XMLUtility
{
    public class BooleanStringConverter : StringConverter<bool>
    {
        public override bool TryConvert(string self, out bool result)
        {
            if (bool.TryParse(self,out result))
            {
                return true;
            }

            return false;
        }
    }
}