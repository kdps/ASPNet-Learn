# Override Code Parameter

## ShouldRender

@code {
    private bool shouldRender = true;
    
    protected override bool ShouldRender()
    {
        return shouldRender;
    }
}


## OnParametersSetAsync

```
@code {
    protected override async Task OnParametersSetAsync()
    {
    }
}
```

## OnParameter

```
@code {
    protected override void OnParametersSet()
    {
    }
}
```

## OnInitialized

```
@code {
    protected override void OnInitialized()
    {
    }
}
```




# HTML Attribute

## bind

### Binding to Code Data

```
@bind:format
@bind-Password
```

```
<input @bind="InputValue"/>

@code {
    private string? InputValue { get; set; }
}
```

## oninput

### Add Event Listener On Input

```
@code {
    private async Task OnPasswordChanged(ChangeEventArgs e)
    {
    }
}
```

## onclick

### Add Event Listener On Click

```
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

```
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

```
@code {
}
```

## Annotation

```
StringLength *Attributes = ${Number} 'Minimum Length', ErrorMessage(String)
AllowNull
Parameter *Attributes = CaptureUnmatchedValues(Boolean)
EditorRequired
CascadingParameter *Attributes = Name(String)
```

```
StringLegnth(10, ErrorMessage = "Text is Too Short")
```

## onclick

### Add OnClick Event Listener

```
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

```
<button @onclick="@(e => heading = "New heading!!!")"></button>

@code {
    private string heading = "Initial heading";
}
```


# Header

## Layout

### Apply Layout

```
@layout BaseLayout
```

## Attribute

### Apply Attribute

```
Authorize
AllowAnonymous
```


```
@attribute [Authorize]
```

## inherits

### Set Base Class

```
@inherits BlazorRocksBase
```

## Page

### Indicates that template is blazor

```
@page
```

## Using

### Use Library

```
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

```
@using Microsoft.AspNetCore.Identity
```

## Model

### Send Model To Page

```
@model LoginViewModel
```

## inject

### Dependency Inject

```
SignInManager<IdentityUser> SignInManager
UserManager<IdentityUser> UserManager
ILogger<ReferenceChild> Logger
AuthenticationStateProvider AuthenticationStateProvider
```

```
@inject SignInManager<UserStore> SignInManager
```
