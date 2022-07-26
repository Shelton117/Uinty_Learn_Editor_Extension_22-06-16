using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace EditorExtension.AdvancedDropdownExample.Editor
{
    public class AdvancedDropdownExample : EditorWindow
    {
        [MenuItem("EditorExtension/10.AdvancedDropdown/Open")]
        private static void Open()
        {
            GetWindow<AdvancedDropdownExample>().Show();
        }

        private void OnGUI()
        {
            var rect = GUILayoutUtility.GetRect(new GUIContent("Show"), EditorStyles.toolbarButton);

            if (GUI.Button(rect,new GUIContent("Show"), EditorStyles.toolbarButton))
            {
                var dropdown = new WeekdaysDropdown(new AdvancedDropdownState());

                dropdown.Show(rect);
            }
        }

        public class WeekdaysDropdown : AdvancedDropdown
        {
            public WeekdaysDropdown(AdvancedDropdownState sate) : base(sate)
            {
                
            }

            protected override AdvancedDropdownItem BuildRoot()
            {
                var root = new AdvancedDropdownItem("Weekdays");
                
                var firstHalf = new AdvancedDropdownItem("First Half");
                var secondHalf = new AdvancedDropdownItem("Second Half");
                var weekendHalf = new AdvancedDropdownItem("Weekend Half");

                firstHalf.AddChild(new AdvancedDropdownItem("Mon"));
                firstHalf.AddChild(new AdvancedDropdownItem("Tue"));
                secondHalf.AddChild(new AdvancedDropdownItem("Wed"));
                secondHalf.AddChild(new AdvancedDropdownItem("Thu"));
                weekendHalf.AddChild(new AdvancedDropdownItem("Fri"));
                weekendHalf.AddChild(new AdvancedDropdownItem("Sat"));
                weekendHalf.AddChild(new AdvancedDropdownItem("Sun"));

                root.AddChild(firstHalf);
                root.AddChild(secondHalf);
                root.AddChild(weekendHalf);

                return root;
            }

            protected override void ItemSelected(AdvancedDropdownItem item)
            {
                Debug.Log(item.name);
            }
        }
    }
}