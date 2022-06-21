# Override Code Parameter

## ShouldRender

```razor
@code {
    private bool shouldRender = true;
    
    protected override bool ShouldRender()
    {
        return shouldRender;
    }
}
```

## OnParametersSetAsync

```razor
@code {
    protected override async Task OnParametersSetAsync()
    {
    }
}
```

## OnParameter

```razor
@code {
    protected override void OnParametersSet()
    {
    }
}
```

## OnInitialized

```razor
@code {
    protected override void OnInitialized()
    {
    }
}
```




# HTML Attribute

## bind

### Binding to Code Data

```razor
@bind:format
@bind-Password
```

```razor
<input @bind="InputValue"/>

@code {
    private string? InputValue { get; set; }
}
```

## oninput

### Add Event Listener On Input

```razor
@code {
    private async Task OnPasswordChanged(ChangeEventArgs e)
    {
    }
}
```

## onclick

### Add Event Listener On Click

```razor
<button @onclick="ClickEvent">
    Click
</button>

@code {
    private void ClickEvent(MouseEventArgs e)
    {
    }
}
```

## onchange

### Add Event Listener On Changed

```razor
<select @onchange="SelectedCarsChanged" multiple>
    <option value="audi">Audi</option>
    <option value="jeep">Jeep</option>
    <option value="opel">Opel</option>
    <option value="saab">Saab</option>
    <option value="volvo">Volvo</option>
</select>

@code {
    public string[] SelectedCars { get; set; } = new string[] { };

    void SelectedCarsChanged(ChangeEventArgs e)
    {
        if (e.Value is not null)
        {
            SelectedCars = (string[])e.Value;
        }
    }
}
```






# Code

```razor
@code {
}
```

## Annotation

```razor
StringLength *Attributes = ${Number} 'Minimum Length', ErrorMessage(String)
AllowNull
Parameter *Attributes = CaptureUnmatchedValues(Boolean)
EditorRequired
CascadingParameter *Attributes = Name(String)
```

```razor
StringLegnth(10, ErrorMessage = "Text is Too Short")
```

## onclick

### Add OnClick Event Listener

```razor
<a>@currentCount</a>
<a @onclick="IncrementCount">ClickEvent</a>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

Lambda

```razor
<button @onclick="@(e => heading = "New heading!!!")"></button>

@code {
    private string heading = "Initial heading";
}
```


# Header

## Layout

### Apply Layout

```razor
@layout BaseLayout
```

## Attribute

### Apply Attribute

```razor
Authorize
AllowAnonymous
```


```razor
@attribute [Authorize]
```

## inherits

### Set Base Class

```razor
@inherits BlazorRocksBase
```

## Page

### Indicates that template is blazor

```razor
@page
```

## Using

### Use Library

```razor
Microsoft.JSInteropl
Microsoft.AspNetCore.Identityl
Microsoft.AspNetCore.Authorizationl
Microsoft.AspNetCore.Components.Authorization;
Microsoft.AspNetCore.Components.Forms;
Microsoft.AspNetCore.Components.Routing;
Microsoft.AspNetCore.Components.Web;
Microsoft.AspNetCore.Components.Web.Virtualization;
System.Diagnostics.CodeAnalysisl
RazorPagesIntro.Pagesl
BlazorSample.Componentsl
```

```razor
@using Microsoft.AspNetCore.Identity
```

## Model

### Send Model To Page

```razor
@model LoginViewModel
```

## inject

### Dependency Inject

```razor
SignInManager<IdentityUser> SignInManager
UserManager<IdentityUser> UserManager
ILogger<ReferenceChild> Logger
AuthenticationStateProvider AuthenticationStateProvider
```

```razor
@inject SignInManager<UserStore> SignInManager
```
