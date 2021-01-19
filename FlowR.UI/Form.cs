using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.RegularExpressions;
using FlowR.Core;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace FlowR.UI
{
    /// <summary>
    /// Tag Form
    /// </summary>
    /// <example>
    ///
    /// Form.BindControl(fldName);
    /// 
    /// Form.BindControls(fldSurname, fldAddress);
    ///
    /// Form.submit(); // for all binded controls, will be called Collect()
    /// to retrieve the actual value
    /// @todo add a loading or something during this type of operations 
    /// </example>
    public class Form : ComponentElement<Form>
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName => "form";
        
        private readonly List<IComponentControl> _controls = new();
        
        /// <inheritdoc />
        public override void Init()
        {
            base.Init();
            
            // remove default behaviour
            SetAttribute("onsubmit", "return false;");
        }

        public Form OnSubmit(Action<Dictionary<string,object>> callback, IComponentControl[] controls)
        {
            On("submit", (sender, args) =>
            {
                callback(CollectValues());
            });

            foreach (var control in controls)
            {
                this._controls.Add(control);
            }

            return this;
        }
        
        private Dictionary<string, object> CollectValues()
        {
            Dictionary<string, object> values = new();
            foreach (var control in _controls)
            {
                var key = control.GetControlName();
                var value = control.Collect();
                values[key] = value;
            }

            return values;
        }
    }
}