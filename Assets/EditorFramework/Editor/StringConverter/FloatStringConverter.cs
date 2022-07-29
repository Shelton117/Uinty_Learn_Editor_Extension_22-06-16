namespace EditorFramework.Editor.StringConverter
{
    public class FloatStringConverter : StringConverter<float>
    {
        public override bool TryConvert(string self, out float result)
        {
            if (float.TryParse(self, out result))
            {
                return true;
            }

            return false;
        }
    }

}
