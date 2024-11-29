using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace XafDemoPropertyEditor.Blazor.Server.Editors;

public class InputTextModel : ComponentModelBase
{
    public string Value
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(value);
    }
    public EventCallback<string> ValueChanged
    {
        get => GetPropertyValue<EventCallback<string>>();
        set => SetPropertyValue(value);
    }
    public Expression<Func<string>> ValueExpression
    {
        get => GetPropertyValue<Expression<Func<string>>>();
        set => SetPropertyValue(value);
    }
    public override Type ComponentType => typeof(MyTexBox);
}


