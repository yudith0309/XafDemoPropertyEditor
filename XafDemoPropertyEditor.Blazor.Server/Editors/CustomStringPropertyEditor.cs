﻿using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;

namespace XafDemoPropertyEditor.Blazor.Server.Editors;

[PropertyEditor(typeof(string), false)]
public class CustomStringPropertyEditor : BlazorPropertyEditorBase
{
    public CustomStringPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
    public override InputTextModel ComponentModel => (InputTextModel)base.ComponentModel;
    protected override IComponentModel CreateComponentModel()
    {
        var model = new InputTextModel();
        model.ValueExpression = () => model.Value;
        model.ValueChanged = EventCallback.Factory.Create<string>(this, value =>
        {
            model.Value = value;
            OnControlValueChanged();
            WriteValue();
        });
        return model;
    }
    protected override void ReadValueCore()
    {
        base.ReadValueCore();
        ComponentModel.Value = (string)PropertyValue;
    }
    protected override object GetControlValueCore() => ComponentModel.Value;
    protected override void ApplyReadOnly()
    {
        base.ApplyReadOnly();
        ComponentModel?.SetAttribute("readonly", !AllowEdit);
    }
}
