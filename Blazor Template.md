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
Parameter *Attributes = CaptureUnmatchedValues(Boolean)
EditorRequired
CascadingParameter *Attributes = Name(String)
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
Microsoft.JSInterop
Microsoft.AspNetCore.Identity
Microsoft.AspNetCore.Authorization
Microsoft.AspNetCore.Components.Authorization;
Microsoft.AspNetCore.Components.Forms;
Microsoft.AspNetCore.Components.Routing;
Microsoft.AspNetCore.Components.Web;
Microsoft.AspNetCore.Components.Web.Virtualization;
RazorPagesIntro.Pages
BlazorSample.Components
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
```

```
@inject SignInManager<UserStore> SignInManager
```
