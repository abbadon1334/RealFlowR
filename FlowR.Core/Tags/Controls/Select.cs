using System.Collections.Generic;
using System.Linq;

namespace FlowR.Core.Tags.Controls
{
    /// <summary>
    ///     Defines a selection list within a form.
    /// </summary>
    public class Select : NodeControl
    {
        /// <inherited />
        protected override string TagName => "select";

        /// <summary>
        ///     Add an option to the select
        /// </summary>
        /// <param name="label"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Select AddOption(string label, string value)
        {
            Add<Option>(new Dictionary<string, string> { { "value", value } }).SetText(label);

            return this;
        }

        /// <summary>
        ///     Add an option to the select
        /// </summary>
        /// <param name="label"></param>
        /// <param name="value"></param>
        /// <param name="groupIdentifier"></param>
        /// <returns></returns>
        public Select AddOption(string label, string value, string groupIdentifier)
        {
            GetOptionGroup(groupIdentifier).AddOption(label, value);

            return this;
        }

        /// <summary>
        ///     Add options to the select
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Select AddOption(Dictionary<string, string> options)
        {
            foreach (var kvp in options)
            {
                AddOption(kvp.Key, kvp.Value);
            }

            return this;
        }
        /// <summary>
        ///     Add options to the select
        /// </summary>
        /// <param name="options"></param>
        /// <param name="groupIdentifier"></param>
        /// <returns></returns>
        public Select AddOption(Dictionary<string, string> options, string groupIdentifier)
        {
            var group = GetOptionGroup(groupIdentifier);
            foreach (var kvp in options)
            {
                group.AddOption(kvp.Key, kvp.Value);
            }

            return this;
        }

        /// <summary>
        ///     Add an option to the select
        /// </summary>
        /// <param name="label"></param>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Select AddOptionGroup(string label, string identifier)
        {
            Add<OptionGroup>(new Dictionary<string, string>
            {
                { "label", label },
                { "group-identifier", identifier },
            });

            return this;
        }

        /// <summary>
        ///     Get an OptionGroup by identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public OptionGroup GetOptionGroup(string identifier)
        {
            return GetChildrenOfType<OptionGroup>().Select(group => group.GetAttribute("group-identifier") == identifier ? group : null).First();
        }

        /// <summary>
        ///     Remove all options
        /// </summary>
        /// <returns></returns>
        public Select ClearOptions()
        {
            foreach (var kvp in GetChildren())
            {
                Remove(kvp.Value);
            }

            return this;
        }

        /// <summary>
        ///     Short way to clear and add a new option list
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Select ReplaceOption(Dictionary<string, string> options)
        {
            ClearOptions();
            AddOption(options);

            return this;
        }

        /// <summary>
        ///     Set Option with specific value as selected=true
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Select SetSelectedOption(string value)
        {
            GetChildrenOfType<Option>().ForEach(option =>
            {
                if (option.GetAttribute("value") == value)
                {
                    option.SetSelected();
                    return;
                }

                option.SetSelected(false);
            });

            return this;
        }
    }

    /// <summary>
    ///     Defines a group of related options in a selection list.
    /// </summary>
    public class OptionGroup : NodeElement
    {
        /// <inherited />
        protected override string TagName => "optgroup";

        /// <summary>
        ///     Add an option to the select
        /// </summary>
        /// <param name="label"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public OptionGroup AddOption(string label, string value)
        {
            Add<Option>(new Dictionary<string, string> { { "value", value } }).SetText(label);

            return this;
        }
    }

    /// <summary>
    ///     Defines an option in a selection list.
    /// </summary>
    public class Option : NodeElement
    {
        /// <inherited />
        protected override string TagName => "option";

        /// <summary>
        ///     Set Attribute selected as true or remove Attribute.
        /// </summary>
        /// <returns></returns>
        public Option SetSelected(bool selected = true)
        {
            return selected
                    ? SetAttribute("selected", "true") as Option
                    : RemoveAttribute("selected") as Option
                ;
        }
    }
}