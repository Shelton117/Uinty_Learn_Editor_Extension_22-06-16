namespace EditorFramework.Example.XMLGUI.Editor.XMLUtility
{
    public class StringStringConverter : StringConverter<string>
    {
        public override bool TryConvert(string self, out string result)
        {
            result = self;
            return true;
        }
    }
}